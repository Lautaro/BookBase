using BookBase.Services.BookSearch;
using BookBase.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookBase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return BookSearch("");
        }

        public ActionResult BookSearch(string searchString)
        {
            SearchResult searchResult = new SearchResult();
            if (!string.IsNullOrEmpty(searchString))
            {
                searchResult = BookSearchService.SearchForBooks(searchString);
                Session["searchString"] = searchString;
            }

            var model = new BookSearchViewModel()
            {
                SearchResult = searchResult
            };

            return View("BookSearch", model);
        }

        public ActionResult FibonacciCheck(int fibonacciNr)
        {
            var isFibonacci = ExtraFunctions.API.IsFibonacci(fibonacciNr);

            var model = new BookSearchViewModel()
            {
                SearchResult = CheckForCahedBookSearchResult(),
                FibonacciAnswer = isFibonacci,
                FibonacciQuestion = fibonacciNr

            };

            return View("BookSearch", model);
        }

        public ActionResult EasterCheck(int easterYear)
        {
            var easterDate = ExtraFunctions.API.EasterDateSearch(easterYear);

            var model = new BookSearchViewModel()
            {
                SearchResult = CheckForCahedBookSearchResult(),
                EasterQuestion = easterYear,
                EasterAnswer = easterDate.ToShortDateString()
            };

            return View("BookSearch", model);

        }

        private SearchResult CheckForCahedBookSearchResult()
        {
            if (Session["searchString"] != null)
            {
                var searchString = Session["searchString"].ToString();
                var searchResult = new SearchResult();
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchResult = BookSearchService.SearchForBooks(searchString);
                    return searchResult;
                }
            }
            return new SearchResult();
        }
    }
}