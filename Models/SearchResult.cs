using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class SearchResult
    {
        public string SearchString { get; set; }
        public List<SearchResultBook> BookResults { get; set; }
    }
}
