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
            if (ModelState.IsValid) // show success view.
            {
                return View("CardSent", cardSentResponse);
            }
            else // update the form submission view with the missing fields user must enter.
            {
                return View("Index", cardSentResponse);
            }
        }
    }
}
