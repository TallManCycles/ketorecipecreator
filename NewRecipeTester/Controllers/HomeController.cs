using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewRecipeTester.Models;

namespace NewRecipeTester.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Document d = new Document();
            return View(d);
        }

        [HttpPost]
        public ActionResult CreateDocument(Document d)
        {
            if (d != null)
            {
                Document a = d;
                a.CompletedText = CreateDocumentFromFile(d);
                return View("Complete", a);
            }
            else
            {
                return View("Error");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string CreateDocumentFromFile(Document d)
        {
            string document = @"[TITLE]
            [SEO KEYWORD 1] is a fantastic keto recipe, perfectly [TEXTURE], and can be eaten during [SEASON], or all year round. You are going to love making this [SEO KEYWORD 2] recipe, especially since its [ADVANTAGE 1].
            ";

            document = document.Replace("[TITLE]", d.Title);
            document = document.Replace("[SEO KEYWORD 1]", d.Keyword1);
            document = document.Replace("[SEO KEYWORD 2]", d.Keyword2);
            document = document.Replace("[SEO KEYWORD 3]", d.Keyword3);
            document = document.Replace("[TITLE]", d.Title);
            document = document.Replace("[TEXTURE]", d.Texture);
            document = document.Replace("[SEASON]", d.Season);
            document = document.Replace("[ADVANTAGE 1]", d.Advantage1);
            document = document.Replace("[ADVANTAGE 2]", d.Advantage2);
            document = document.Replace("[QUESTION 1]", d.Question1);
            document = document.Replace("[QUESTION 2]", d.Question2);

            d.CompletedText = document;

            return d.CompletedText;

        }
    }
}
