using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using QcaugmenteBackend.Models;
using System.IO;

namespace QcaugmenteBackend.Controllers
{
    public class ZapController : ApiController
    {
        public List<Zap> get()
        {
            var lstZap = new List<Zap>();
            var request = WebRequest.CreateHttp("https://www.donneesquebec.ca/recherche/dataset/5cc3989e-442b-4f25-8049-d39d44421d6f/resource/0106c060-9559-4ce7-9987-41ec051a1df8/download/nodes.csv");

            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseText = reader.ReadToEnd();
            var tousTexte = responseText.Split('\n');
            for(int i = 0; i < tousTexte.Length;i++)
            {
                tousTexte[i] = tousTexte[i].Replace("\"", "");
            }
            bool ignoreFisrt = false;
            foreach (var v in tousTexte)
            {
                if (ignoreFisrt)
                {
                    Zap zap = new Zap(v);
                    lstZap.Add(zap);
                }
                else
                {
                    ignoreFisrt = true;
                }

            }
            return lstZap;
        }
    }
}
