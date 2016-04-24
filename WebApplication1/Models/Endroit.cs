using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class Endroit
    {
        public int id { get; set; }
        public enum categories
        {
            Resto = 0,
            Evenement = 1,
            Parc = 2,
            Mural = 3,
            Musee = 4,
            Biblio = 5,
            RenseignementTouristique = 6,
            Arret = 7
        }

        public enum prix
        {
            Gratuit = 1,
            Cheap = 2,
            Moyen = 3,
            Cher = 4
        }

        [DataMember]
        public Position pos { get; set; }

        [DataMember]
        public categories Categorie { get; set; }

        [DataMember]
        public prix Prix { get; set; }

        public Endroit(string lat, string lon)
        {
            pos = new Position(lat, lon);
        }
        public Endroit()
        {
            pos = new Position("-500", "-500");
        }
    }
}