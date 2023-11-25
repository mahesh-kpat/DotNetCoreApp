using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookStoreApp.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfiguration;
        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration)
        {
            _newBookAlertConfiguration = newBookAlertconfiguration.Value;
        }
        public ViewResult Index()
        {
            bool isDisplay= _newBookAlertConfiguration.DisplayNewBookAlert;


            //var newBook = configuration.GetSection("NewBookAlert");
            //var result = newBook.GetValue<bool>("DisplayNewBookAlert");
            //var bookName = newBook.GetValue<string>("BookName");
            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3Obj1"];
            return View();
        }

       
       
        public ViewResult AboutUs(string name)
        {
        
            return View();
        }

        
        public ViewResult ContactUs()
        {
            
            return View();
        }


    }
}
