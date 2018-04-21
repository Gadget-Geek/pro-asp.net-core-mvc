using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;
using System;
using System.Text;
using System.Linq;

namespace LanguageFeatures.Controllers {
    public class HomeController : Controller {

        public ViewResult FindProducts() {

            var products = new[] {
                new { Name = "Kayak", Category = "Watersports", Price = 275M },
                new { Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
                new { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
                new { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
            };

            var foundProducts = from match in products
                                orderby match.Price descending
                                select new { match.Name, match.Price };
            
            // create the result
            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts) {
                result.AppendFormat("Price: {0} ", p.Price);
                if (++count == 3) {
                    break;
                }
            }
            
            return View("Result", (object)result.ToString());
        }
    }
}
