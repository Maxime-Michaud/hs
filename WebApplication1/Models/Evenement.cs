using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class Evenement
    {
        [DataMember]
        public int MUNID { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string DT01 { get; set; }
        [DataMember]
        public string DT02 { get; set; }
        [DataMember]
        public string HR01 { get; set; }
        [DataMember]
        public string HR02 { get; set; }
        [DataMember]
        public string HOR { get; set; }
        [DataMember]
        public string TITRE { get; set; }
        [DataMember]
        public string TEL1 { get; set; }
        [DataMember]
        public string DESCRIP { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public string CATEG { get; set; }
        [DataMember]
        public string LOC { get; set; }
        [DataMember]
        public string AD_NO { get; set; }
        [DataMember]
        public string AD_GEN { get; set; }
        [DataMember]
        public string AD_LIEN { get; set; }
        [DataMember]
        public string AD_MUN { get; set; }
        [DataMember]
        public string CO { get; set; }
        
        public Endroit endroit { get; set; }
        [ForeignKey("endroit")]
        public int EndroitId { get; set; }

        public Evenement()
        {

        }

        public Evenement(string s)
        {

            ID = get("CODEID", s);
            MUNID = int.Parse(get("MUNID", s));
            DT01 = get("DT01", s);
            DT02 = get("DT02", s);
            HR01 = get("HR01", s);
            HR02 = get("HR02", s);
            HOR = get("HOR", s);
            TITRE = get("TITRE", s);
            TEL1 = get("TEL1", s);
            DESCRIP = get("DESCRIP", s);
            URL = get("URL", s);
            CATEG = get("CATEG", s);
            LOC = get("LOC", s);
            AD_NO = get("AD_NO", s);
            AD_GEN = get("AD_GEN", s);
            AD_LIEN = get("AD_LIEN", s);
            AD_MUN = get("AD_MUN", s);
            CO = get("CO", s);

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

            return value.Trim(',');
        }
    }
}