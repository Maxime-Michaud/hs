using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string SiteWeb { get; set; }
        [DataMember]
        public string NumeroCivique { get; set; }
        [DataMember]
        public string Rue { get; set; }
        [DataMember]
        public string CodePostal { get; set; }
        [DataMember]
        public string Arrondissement { get; set; }
        [DataMember]
        public string Ville { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string NumeroTelephone { get; set; }
        [DataMember]
        public string Categories { get; set; }
        [DataMember]
        public List<string> Offres { get; set; }
        [DataMember]
        public string EchellePrix { get; set; }
        [DataMember]
        public string DescriptionCourte { get; set; }
        [DataMember]
        public string FichierImage { get; set; }

        public Restaurant(string s)
        {
            ID = int.Parse(get("ID", s));
            Nom = get("Nom", s);
            SiteWeb = get("SiteWeb", s);
            NumeroCivique = get("NumeroCivique", s);
            Rue = get("Rue", s);
            CodePostal = get("CodePostal", s);
            Arrondissement = get("Arrondissement", s);
            Ville = get("Ville", s);
            Latitude = get("Latitude", s);
            Longitude = get("Longitude", s);
            NumeroTelephone = get("NumeroTelephone", s);
            Categories = get("Categories", s);
            Offres = offres("Offres", s);
            EchellePrix = get("EchellePrix", s);
            DescriptionCourte = get("DescriptionCourte", s);
            FichierImage = get("FichierImage", s);

        }

        private string get(string prop, string s)
        {
            var match = Regex.Match(s, $"\"{prop}\":\\s?(?<prop>.*?,)");
            string value = match.Groups["prop"].Value;

            if (value.Contains("\\"))
            {
                value = value.Replace("\\u00e9", "é");
                value = value.Replace("\\u00c9", "É");
                value = value.Replace("\\u00ea", "ê");
                value = value.Replace("\\u00e8", "è");
                value = value.Replace("\\u2022", "");
                value = value.Replace("\\u2019", "'");
                value = value.Replace("\\u00fb", "û");
                value = value.Replace("\\u00e0", "à");
                value = value.Replace("<br \\/>", "");
                value = value.Replace("\\u00e2", "â");
                value = Regex.Replace(value, "<.*?>", "");
            }
            value = value.Trim(',', '"');
            if (prop == "ID")
            {
                return value.Split('.')[0];
            }
            if (prop == "Categories")
            {
                    switch (int.Parse(value))
                    {
                        case 0:
                        return "Non disponible";
                        case 1:
                        return "Chefs créateurs";
                        case 2:
                        return "Pubs et microbrasseries";
                        case 3:
                        return "Délices d'ici";
                        case 4:
                        return "Restaurants";
                        case 5:
                        return "Bonnes tables";
                        case 6:
                        return "Cafés & Bistros";
                        case 7:
                        return "Saveurs du monde";
                        case 8:
                        return "Brasseries";
                        case 9:
                        return "Cuisine familiale";
                        case 10:
                        return "Restauration rapide";
                    default:
                            break;
                    }
            }
            return value;
        }

        private List<string> offres(string prop, string s)
        {
            List<int> lstInt = new List<int>();
            if (s != "")
            {
                var match = Regex.Match(s, $"\"{prop}\":\\s?(?<prop>.*?Echelle)");
                string value = match.Groups["prop"].Value;
                var arrayValue = value.Split(',');
                foreach (var v in arrayValue)
                {
                    if (v != arrayValue.Last())
                    {
                        var tempo = v.Trim('"', '\\');
                        if (tempo != "")
                            lstInt.Add(int.Parse(tempo));
                    }
                }
                    
            }
            List<string> lstString = new List<string>();
            foreach(var v in lstInt)
            {
                switch (v)
                {
                    case 0:
                        lstString.Add("Non disponible");
                        break;
                    case 1:
                        lstString.Add("Déjeuner");
                        break;
                    case 2:
                        lstString.Add("Brunch");
                        break;
                    case 3:
                        lstString.Add("Dîner");
                        break;
                    case 4:
                        lstString.Add("Souper");
                        break;
                    default:
                        break;
                }

            }
            return lstString;
        }
    }
}