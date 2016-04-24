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
    public class ZapRestaurant : Restaurant
    {
        [DataMember]
        bool ZapDisponible
        {
            get
            {
                foreach(var v in (new Zap2Controller()).get())
                {
                    if (new Position(v.latitude, v.longitude).distance(new Position(this.Latitude, this.Longitude)) < 100)
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

        
        public ZapRestaurant()
        {

        }

        public ZapRestaurant(Restaurant evt)
        {
            ID = evt.ID;
            Nom = evt.Nom;
            SiteWeb = evt.SiteWeb;
            NumeroCivique = evt.NumeroCivique;
            Rue = evt.Rue;
            CodePostal = evt.CodePostal;
            Arrondissement = evt.Arrondissement;
            Ville = evt.Ville;
            Latitude = evt.Latitude;
            Longitude = evt.Longitude;
            NumeroTelephone = evt.NumeroTelephone;
            Categories = evt.Categories;
            Offres = evt.Offres;
            EchellePrix = evt.EchellePrix;
            DescriptionCourte = evt.DescriptionCourte;
            FichierImage = evt.FichierImage;
        }
    }
}
