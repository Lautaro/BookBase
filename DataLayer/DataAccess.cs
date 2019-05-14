using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataAccess
    {
        static internal Container _dependecyContainer;

        static public void Main()
        {
            InitializeDependencyContainer();
        }

        public static IBookRepository GetRepository()
        {
            if (_dependecyContainer == null)
            {
                InitializeDependencyContainer();
            }

            return _dependecyContainer.GetInstance<IBookRepository>();
           
        }

        private static void InitializeDependencyContainer()
        {
            _dependecyContainer = new Container();
            _dependecyContainer.Register<IBookRepository, BookRepository>();
            _dependecyContainer.Register<IXMLReader, XMLReader>();

            _dependecyContainer.Verify();
        }
    }
}
