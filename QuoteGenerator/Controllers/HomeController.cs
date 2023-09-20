using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using QuoteGenerator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace QuoteGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

         
         


            // Initialize the current quote
            CurrentQuote = GetRandomQuote();

        }


        private static List<Quote> Quotess = new List<Quote>
        {
            new Quote { Id = 1, Text = "Life comes from the earth and life returns to the earth."},
            new Quote { Id = 2, Text = "We are here to add what we can to life, not to get what we can from life."},
            new Quote {Id = 3, Text = "The art of life is to know how to enjoy a little and to endure very much."},
            new Quote {Id = 4, Text = "If you change the way you look at things, the things you look at change."},
            new Quote { Id = 5, Text = "For the great doesn't happen through impulse alone, and is a succession of little things that are brought together."},
            new Quote {Id = 6, Text = "Perfection is not attainable. But if we chase perfection we can catch excellence."},
            new Quote {Id = 7, Text = "You have succeeded in life when all you really want is only what you really need."},
            new Quote {Id  = 8,  Text = "Believe you can and you're halfway there."},
            new Quote {Id = 9, Text = "To do the useful thing, to say the courageous thing, to contemplate the beautiful thing: that is enough for one man's life."},
            new Quote { Id = 10, Text = "You do You"}

        };

        private static Random Randomss = new Random();
        
        private Quote CurrentQuote;


        

        //private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    CurrentQuote = GetRandomQuote();
        //    ViewData["RandomQuote"] = CurrentQuote;
        //    PartialView("_RandomQuotePartial", CurrentQuote);
        //}

        public Quote GetRandomQuote()
        {
          int randomIndex = Randomss.Next(Quotess.Count);
           var randomQuote = Quotess[randomIndex];
          return randomQuote;
        }
        public IActionResult Index()
        {

            Quote randomQuote = ViewData["RandomQuote"] as Quote;
            if (randomQuote == null)
            {
                randomQuote = GetRandomQuote();
                ViewData["RandomQuote"] = randomQuote;
            }
            //GetRandomQuote();
            return View(randomQuote);

        }

        public IActionResult GetRandomQuoteAction()
        {
            Quote randomQuote = GetRandomQuote();
            return Json(randomQuote);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}