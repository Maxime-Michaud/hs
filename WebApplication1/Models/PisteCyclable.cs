using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class PisteCyclable
    {
        [DataMember]
        public string PISTECYCLABLE_IDG { get; set; }
        [DataMember]
        public string NOMVILLE { get; set; }
        [DataMember]
        public string NOMDESTINATIONSHERBROOKE { get; set; }
        [DataMember]
        public string NOMMTQ { get; set; }
        [DataMember]
        public string REMARQUE { get; set; }
        [DataMember]
        public string LARGEUR { get; set; }
        [DataMember]
        public string TYPE_resolved { get; set; }
        [DataMember]
        public string TYPEREVETEMENT_resolved { get; set; }
        [DataMember]
        public string TYPEMTQ1_resolved { get; set; }
        [DataMember]
        public string TYPEMTQ2_resolved { get; set; }
        [DataMember]
        public string METHODECAPTAGEID_resolved { get; set; }
        [DataMember]
        public string Shape_len00 { get; set; }
        [DataMember]
        public List<string> _geometry { get; set; }

        public PisteCyclable(string s, List<String> arstr)
        {
            if(s.Length > 11)
            {
                var texteSplit = s.Split(',');
                PISTECYCLABLE_IDG = texteSplit[0];
                NOMVILLE = texteSplit[1];
                NOMDESTINATIONSHERBROOKE = texteSplit[2];
                NOMMTQ = texteSplit[3];
                REMARQUE = texteSplit[4];
                LARGEUR = texteSplit[5];
                TYPE_resolved = texteSplit[6];
                TYPEREVETEMENT_resolved = texteSplit[7];
                TYPEMTQ1_resolved = texteSplit[8];
                TYPEMTQ2_resolved = texteSplit[9];
                METHODECAPTAGEID_resolved = texteSplit[10];
                Shape_len00 = texteSplit[11];
                _geometry = arstr;
            }
            else
            {
                return;
            }
        }
    }
}