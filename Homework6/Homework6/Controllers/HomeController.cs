using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework6.Models;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Receive the data coming from the browser
        [HttpPost]
        public IActionResult SendCardForm(Models.Response cardSentResponse)
        {
            return View(new Response());
        }
    }
}
