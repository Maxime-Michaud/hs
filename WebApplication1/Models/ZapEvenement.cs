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
        bool Disponible
        {
            get
            {
                using (var DB = new DB())
                {
                    this.endroit.pos = (from e in DB.Endroits where e.id == this.EndroitId select e.pos).FirstOrDefault();
                    foreach(var v in new ZapController().get())
                    {
                        double longitude = double.Parse(v.longitude);
                        double latitude = double.Parse(v.latitude);
                        double distance = pos.distance(this.endroit.pos);
                        return distance < 20;
                    }
                }
                return false;
            }
            
        }
            Position pos = new Position();

    }
}
