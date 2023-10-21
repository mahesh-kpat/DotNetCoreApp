using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            // return View("~/TempView/other.cshtml");
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }


    }
}
