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

        // Display the view (empty form)
        [HttpGet]
        public IActionResult CardSent()
        {
            return View(new Response());
        }

        // Receive the data coming from the browser
        [HttpPost]
        public IActionResult CardSent(Models.Response cardSentResponse)
        {
            return View(cardSentResponse);
        }
    }
}
