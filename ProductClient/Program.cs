using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

/// <summary>
/// Console app: Client for product
/// </summary>
namespace ProductClient
{
    /// <summary>
    ///  class Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54005/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/Product").Result;
                var products = response.Content.ReadAsAsync<List<Product>>().Result;
                foreach (var elem in products)
                {
                    Console.WriteLine("ID = {0}, Name = {1}, Price = {2}, Group = {3}",
                                       elem.ID, elem.Name, elem.Price, elem.Group);
                }
                Console.ReadKey();
            }
        }
    }
}

