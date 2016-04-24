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
    public class ZapParc : Parc
    {
        [DataMember]
        bool ZapDisponible
        {
            get
            {
                foreach (var v in (new Zap2Controller()).get())
                {
                    if (new Position(v.latitude, v.longitude).distance(new Position(this.y, this.x)) < 100)
                    {
                        return true;
                    }
                }
                return false;
            }
            set
            {

            }

        }


        public ZapParc()
        {

        }

        public ZapParc(Parc evt)
        {

            id = evt.id;
            NOM = evt.NOM;
            x = evt.x;
            y = evt.y;
        }
    }
}
