using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Text;
using QcaugmenteBackend.Models;
namespace QcaugmenteBackend.Controllers
{
    public class Parc2Controller : ApiController
    {
        public List<Parc> get()
        {
            var pc = new List<Parc>();
            var request = WebRequest.CreateHttp("https://www.donneesquebec.ca/recherche/dataset/16c35d06-a3c2-499c-a910-8365818d9267/resource/6f254286-6ff9-4076-b7f4-96b1e45cbf09/download/siteinteret.csv");

            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252));
            var responseText = reader.ReadToEnd();
            var tousTexte = responseText.Split('\n');
            bool ignoreFisrt = false;
            foreach (var v in tousTexte)
            {
                if (ignoreFisrt)
                {
                    Parc parcs = new Parc(v);
                    pc.Add(parcs);
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
