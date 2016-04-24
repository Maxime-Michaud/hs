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
    public class EventController : ApiController
    {
        public IEnumerable<Evenement> get()
        {
            var evenements = new List<Evenement>();
            var request = WebRequest.CreateHttp("https://calendrier.ville.sherbrooke.qc.ca/?type=1454364096");

            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseText = reader.ReadToEnd();

            foreach (var s in Regex.Split(responseText, @"},\s*{"))
            {
                evenements.Add(new Evenement(s));
                Console.Write(evenements.Last().ID);
            }

            return evenements;
        }
        public IEnumerable<ZapEvenement> get(string Latitude, string Longitude, string Rayon)
        {
            Position userPos = new Position(Latitude, Longitude);
            double maxDist = double.Parse(Rayon);
            List<ZapEvenement> evts;
            using (var db = new DB())
            {
                evts = new List<ZapEvenement>();

                foreach(var evt in db.Evenements)
                {
                    using (var db2 =new DB()) { 
                        evt.endroit = (from e in db2.Endroits where e.id == evt.EndroitId select e).FirstOrDefault();
                        if (userPos.distance(evt.endroit.pos) < maxDist)
                        {
                            evts.Add((ZapEvenement)evt);
                        }
                    }
                }
            }
            
            
            return evts;
        }
    }
}
