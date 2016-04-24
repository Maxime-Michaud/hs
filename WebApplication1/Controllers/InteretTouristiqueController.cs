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
using WebApplication1.Models;
namespace QcaugmenteBackend.Controllers
{
    public class InteretTouristiqueController : ApiController
    {
        public IEnumerable<ZapInteretTouristique> get(string Latitude, string Longitude, string Rayon)
        {
            Position userPos = new Position(Latitude, Longitude);
            double maxDist = double.Parse(Rayon);
            List<ZapInteretTouristique> evts;
            evts = new List<ZapInteretTouristique>();
            foreach (var evt in get())
            {
                if (userPos.distance(new Position(evt.Latitude, evt.Longitude)) < maxDist)
                {
                    evts.Add(new ZapInteretTouristique(evt));
                }
            }
            return evts;
        }

        [Route("api/InteretTouristique/{Latitude}/{Longitude}/{Rayon}/{Categorie}")]
        public IEnumerable<ZapInteretTouristique> get(string Latitude, string Longitude, string Rayon, string Categorie)
        {
            var interet = get(Latitude, Longitude, Rayon);
            return from i in interet where Categorie == i.Categories select i;
        }
        public IEnumerable<InteretTouristique> get()
        {
            var evenements = new List<InteretTouristique>();
            var request = WebRequest.CreateHttp("https://www.donneesquebec.ca/recherche/dataset/c3f0a3db-2f74-4a70-a766-ecc0a2f5d5a1/resource/d4cf027d-8bea-4f81-9a14-73f585999036/download/attraits.json");

            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseText = reader.ReadToEnd();

            foreach (var s in Regex.Split(responseText, @"},\s*{"))
            {
                evenements.Add(new InteretTouristique(s));
                Console.Write(evenements.Last().ID);
            }

            return evenements;
        }
    }
}
