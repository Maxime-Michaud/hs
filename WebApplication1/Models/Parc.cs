using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class Parc
    {
        public int id { get; set; }
        [DataMember]
        public string NOM { get; set; }
        [DataMember]
        public string x { get; set; }
        [DataMember]
        public string y { get; set; }

        public Parc(string s)
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
            if (texteSplit.Length > 2)
            {
                
                NOM = texteSplit[0];
                x = texteSplit[1];
                y = texteSplit[2];
            }
            else
            {
                return;
            }
        }

        public Parc()
        {

        }
    }
}