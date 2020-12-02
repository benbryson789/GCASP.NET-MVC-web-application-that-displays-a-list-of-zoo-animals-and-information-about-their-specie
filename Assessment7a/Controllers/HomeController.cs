using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assessment7a.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assessment7a.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // 1600+Amphitheatre+Parkway,+Mountain+View,+CA
        // 1600 Amphitheatre Parkway, Mountain View, CA

        public async Task<IActionResult> Index()
        {
            //collection of animals
            var client = new HttpClient();
            var httpResponse = await client.GetAsync($"https://gc-zoo.surge.sh/api/animals");
            // https://maps.googleapis.com/maps/api/geocode/json?address=zipcode&key=YOUR_API_KEY
            // replace zipcode with original code
            // replace YOUR_API_KEY with the api key from google
            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(content);

            var animals = response.Results;

            return View(animals);
        }


        [HttpPost]
        public async Task<IActionResult> Species (string AnimalSpecies)
        {
            var model = new Animal2();
            if (AnimalSpecies != null && AnimalSpecies != "")
            {
                var client = new HttpClient();
                var response = await client.GetAsync($"https://gc-zoo.surge.sh/api/species/{AnimalSpecies}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<Animal2>(content);
                //model.Name = result["name"].ToObject<string>();
                //model.Diet = result["diet"].ToObject<string>();
                //model.Habitat = result["habitat"].ToObject<string>();             
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
