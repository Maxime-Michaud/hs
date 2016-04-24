using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QcaugmenteBackend.Models;
using System.IO;

namespace QcaugmenteBackend.Controllers
{
    public class PisteCyclableController : ApiController
    {
        public List<PisteCyclable> get()
        {
            var pc = new List<PisteCyclable>();
            var request = WebRequest.CreateHttp("https://www.donneesquebec.ca/recherche/dataset/1fef3d64-45c3-40bf-986f-a07688c97e9f/resource/5dd006e8-237d-4127-ae97-54de4597e09f/download/pistecyclable.csv");

            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseText = reader.ReadToEnd();
            var tousTexte = responseText.Split('\n');
            bool ignoreFisrt = false;
            foreach(var v in tousTexte)
            {
                if (ignoreFisrt)
                {
                    var test = v.Split(',');
                    var arrayDeGeometry = new List<string>();
                    bool first = true;
                    for(int i = 15; i< test.Length;i++)
                    {
                        if(first)
                        {
                            test[i] = test[i].Replace("LINESTRING (", "");
                            first = false;
                        }
                       if(i== test.Length - 1)
                       {
                            test[i] = test[i].Trim(')','\r');
                       }
                        arrayDeGeometry.Add(test[i]);
                    }
                    PisteCyclable piste = new PisteCyclable(v, arrayDeGeometry);
                    pc.Add(piste);
                    
                }
                else
                {
                    ignoreFisrt = true;
                }

            }
            return pc;
        }
    }
}
