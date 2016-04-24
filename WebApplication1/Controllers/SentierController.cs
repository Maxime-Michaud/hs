using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QcaugmenteBackend.Models;
using System.IO;
using System.Text;

namespace QcaugmenteBackend.Controllers
{
    public class Sentier2Controller : ApiController
    {
        public List<Sentier> get()
        {
            var lstSentier = new List<Sentier>();
            var request = WebRequest.CreateHttp("https://www.donneesquebec.ca/recherche/dataset/2c7dbb3b-d37a-4e1e-be4b-e50bdd2ed7cf/resource/123474ef-91ea-47cf-8aca-8b7da5f9fac9/download/sentierpedestre.csv");
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252));
            var responseText = reader.ReadToEnd();
            var tousTexte = responseText.Split('\n');
            bool ignoreFisrt = false;
            foreach (var v in tousTexte)
            {
                if (ignoreFisrt)
                {
                    var test = v.Split(',');
                    var arrayDeGeometry = new List<string>();
                    bool first = true;
                    for (int i = 5; i < test.Length; i++)
                    {
                        if (first)
                        {
                            test[i] = test[i].Replace("LINESTRING (", "");
                            first = false;
                        }
                        if (i == test.Length - 1)
                        {
                            test[i] = test[i].Trim(')', '\r');
                        }
                        arrayDeGeometry.Add(test[i]);
                    }
                    Sentier sentier = new Sentier(v, arrayDeGeometry);
                    lstSentier.Add(sentier);

                }
                else
                {
                    ignoreFisrt = true;
                }

            }
            return lstSentier;
        }
    }
}
