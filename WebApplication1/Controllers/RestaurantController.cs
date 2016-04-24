using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QcaugmenteBackend.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

namespace QcaugmenteBackend.Controllers
{
    public class RestaurantController : ApiController
    {
        public IEnumerable<Restaurant> get()
        {
            var evenements = new List<Restaurant>();
            var request = WebRequest.CreateHttp("https://www.donneesquebec.ca/recherche/dataset/61b5b4e9-d038-4995-b85a-de039dc1b06b/resource/386e62b2-47ae-43bc-a85a-efbcaf3130ba/download/restaurants.json");

            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseText = reader.ReadToEnd();

            foreach (var s in Regex.Split(responseText, @"},\s*{"))
            {
                evenements.Add(new Restaurant(s));
                Console.Write(evenements.Last().ID);
            }

            return evenements;
        }
    }
}
