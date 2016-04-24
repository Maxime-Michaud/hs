using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class Zap
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string civic_number { get; set; }
        [DataMember]
        public string street_name { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string province { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string postal_code { get; set; }
        [DataMember]
        public string public_phone_number { get; set; }
        [DataMember]
        public string public_email { get; set; }
        [DataMember]
        public string latitude { get; set; }
        [DataMember]
        public string longitude { get; set; }


        public Zap(string s)
        {
            if (s.Contains("\\"))
            {
                s = s.Replace("\\u00e9", "é");
                s = s.Replace("\\u00c9", "É");
                s = s.Replace("\\u00ea", "ê");
                s = s.Replace("\\u00e8", "è");
                s = s.Replace("\\u2022", "");
                s = s.Replace("\\u2019", "'");
                s = s.Replace("\\u00fb", "û");
                s = s.Replace("\\u00e0", "à");
                s = s.Replace("<br \\/>", "");
                s = s.Replace("\\u00e2", "â");
                s = Regex.Replace(s, "<.*?>", "");
            }
            var texteSplit = s.Split(',');
            if (texteSplit.Length > 11)
            {

                id = texteSplit[0];
                name = texteSplit[1];
                description = texteSplit[2];
                civic_number = texteSplit[3];
                street_name = texteSplit[4];
                city = texteSplit[5];
                province = texteSplit[6];
                country = texteSplit[7];
                postal_code = texteSplit[8];
                public_phone_number = texteSplit[9];
                public_email = texteSplit[10];
                latitude = texteSplit[11];
                longitude = texteSplit[12];
            }
            else
            {
                return;
            }
        }
    }
}
