using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace QcaugmenteBackend.Models
{
    [DataContract]
    public class Position
    {

        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lon { get; set; }

        public Position(string lat, string lon)
        {
            try
            {
                lat = lat.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                lon = lon.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                lat = lat.Replace(",", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                lon = lon.Replace(",", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);

                this.lat = double.Parse(lat);
                this.lon = double.Parse(lon);
            }
            catch (Exception e) //Met des données clairement erronées pour éviter qu'elles soient considérées
            {
                try
                {
                    this.lat = double.Parse(lat.Replace('.', ','));
                    this.lon = double.Parse(lon.Replace('.', ','));
                }
                catch
                {
                    this.lat = -500;
                    this.lon = -500;
                }
            }
        }

        public double distance(Position p)
        {
            return calcDistance(lat, lon, p.lat, p.lon);
        }
        public Position()
        {
            this.lat = -500;
            this.lon = -500;
        }
        //Code pour calculer la distance pris sur http://www.movable-type.co.uk/scripts/latlong.html
        private static double calcDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371000; // metres
            var φ1 = toRadians(lat1);
            var φ2 = toRadians(lat2);
            var Δφ = toRadians(lat2 - lat1);
            var Δλ = toRadians(lon2 - lon1);

            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                    Math.Cos(φ1) * Math.Cos(φ2) *
                    Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private static double toRadians(double v)
        {
            return Math.PI / 180 * v;
        }

        public static Position PositionWTF(string lat, string lon)
        {
            return (new Position(lat.Replace('.', ','), lon.Replace('.', ',')));
        }

    }
}