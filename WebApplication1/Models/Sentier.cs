using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class Sentier
    {
        [DataMember]
        public string SENTIERPEDESTRE_IDG { get; set; }
        [DataMember]
        public string NOM { get; set; }
        [DataMember]
        public string METHODECAPTAGEID_resolved { get; set; }
        [DataMember]
        public string SHAPE_len { get; set; }
        [DataMember]
        public List<string> _geometry { get; set; }

        public Sentier(string s, List<String> arstr)
        {
            if (s.Length > 3)
            {
                var texteSplit = s.Split(',');
                SENTIERPEDESTRE_IDG = texteSplit[0];
                NOM = "Sentier pedestre";
                METHODECAPTAGEID_resolved = texteSplit[3];
                SHAPE_len = texteSplit[4];
                _geometry = arstr;
            }
            else
            {
                return;
            }
        }
    }
}
