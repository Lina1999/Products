using MVCProduct.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace MVCProduct.Controllers
{
    /// <summary>
    /// Home Controller for MVCProduct
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Showing all the products from DB
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var info = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54005/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/Product").Result;
                var product = response.Content.ReadAsAsync<List<Product>>().Result;
                return View(product);
            }
        }

        /// <summary>
        /// About page
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "This page shows all products from data base.";
            return View();
        }
        
    }
}