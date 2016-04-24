using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    [DataContract]
    public class InteretTouristique
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
        public string DescriptionCourte { get; set; }
        [DataMember]
        public string FichierImage { get; set; }

        public InteretTouristique()
        {

        }

        public InteretTouristique(string s)
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
                        return "Culture et patrimoine";
                    case 2:
                        return "Sport et plein air";
                    case 3:
                        return "Activités familiales";
                    case 4:
                        return "Agrotourisme";
                    case 5:
                        return "Où sortir?";
                    case 6:
                        return "Non disponible";
                    case 7:
                        return "Musées et galeries d'art";
                    case 8:
                        return "Circuits et tours guidés";
                    case 9:
                        return "Divertissement";
                    case 10:
                        return "Patrimoine religieux";
                    case 11:
                        return "Interprétation de la nature";
                    case 12:
                        return "Réseau cyclable";
                    case 13:
                        return "Golf";
                    case 14:
                        return "Marche et randonnée";
                    case 15:
                        return "Activités nautiques";
                    case 16:
                        return "Plaisirs d'hiver";
                    case 17:
                        return "Activités récréatives";
                    case 18:
                        return "Virée magasinage";
                    case 19:
                        return "Détente";
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
            foreach (var v in lstInt)
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
