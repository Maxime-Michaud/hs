using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using QcaugmenteBackend.Controllers;

namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class ZapEvenement : Evenement
    {
        [DataMember]
        bool ZapDisponible
        {
            get
            {
                using (var DB = new DB())
                {
                    this.endroit.pos = (from e in DB.Endroits where e.id == this.EndroitId select e.pos).FirstOrDefault();
                    foreach (var v in new ZapController().get())
                    {
                        double distance = new Position(v.latitude, v.longitude).distance(this.endroit.pos);
                        return distance < 50;
                    }
                }
                return false;
            }
            set
            {

            }

        }

        public ZapEvenement()
        {

        }

        public ZapEvenement(Evenement evt)
        {
            AD_GEN = evt.AD_GEN;
            AD_LIEN = evt.AD_LIEN;
            AD_MUN = evt.AD_MUN;
            AD_NO = evt.AD_NO;
            CATEG = evt.CATEG;
            CO = evt.CO;
            DESCRIP = evt.DESCRIP;
            DT01 = evt.DT01;
            DT02 = evt.DT02;
            endroit = evt.endroit;
            EndroitId = evt.EndroitId;
            HOR = evt.HOR;
            HR01 = evt.HR01;
            HR02 = evt.HR02;
            ID = evt.ID;
            LOC = evt.LOC;
            MUNID = evt.MUNID;
            TEL1 = evt.TEL1;
            TITRE = evt.TITRE;
            URL = evt.URL;
        }
    }
}
