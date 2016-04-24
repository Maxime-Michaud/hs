using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QcaugmenteBackend.Models;
using System.Xml.Linq;

namespace QcaugmenteBackend.Controllers
{
    public class testeeController : ApiController
    {
        [HttpGet]
        public string test()
        {

            using (var db = new DB())
            {
                var test = new EventController();
                var test2 = test.get();
                //foreach (var e in db.Evenements)
                //{
                //    db.Evenements.Remove(e);
                //}

                foreach (var e in test2)
                {
                    if ("".Equals(e.LOC) || "endroits multiples".Equals(e.LOC))
                        continue;   //Fuck you données écrites comme ca

                    var request = WebRequest.CreateHttp($"https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyBuSP7bcjOagRY7yRL8Gowcoqy9AnTTaxg&address={e.LOC.Replace(' ', '+')}");
                    var responseText = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                    var xdoc = XDocument.Parse(responseText);

                    if (xdoc.Descendants("status").First().Value.Equals("ZERO_RESULTS"))
                        continue;

                    var result = xdoc.Descendants("result").First();
                    var geometry = result.Descendants().Where(x => x.Name.ToString().Equals("geometry")).First();
                    var location = geometry.Descendants().Where(x => x.Name.ToString().Equals("location")).First();
                    var lat = location.Descendants().Where(x => x.Name.ToString().Equals("lat")).First().Value;
                    var lng = location.Descendants().Where(x => x.Name.ToString().Equals("lng")).First().Value;

                    lat = lat.Trim('"');
                    lng = lng.Trim('"');

                    e.endroit = new Endroit(lat, lng);
                    db.Evenements.Add(e);
                }



                db.SaveChanges();
                return db.Evenements.Count().ToString();
            }
            

        }
    }
}
