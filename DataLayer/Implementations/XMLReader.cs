using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    class XMLReader : IXMLReader
    {
        public XDocument GetXMLDocument()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"BookSource\books.xml";
            var doc = XDocument.Load(path);            //@"BookSource\books.xml");
            return doc;
        }


    }
}
