using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Location
    {
        public Properties properties = new Properties();
        

        public string type = "Feature";

        public Geometry geometry;

        public Location(string adress, double lat, double lon , string icon) { 
            properties.adresse = adress;
            properties.icon = icon;
            geometry = new Geometry(lat, lon);
        }
        
    }

    public class Properties
    {
        public string adresse { get; set; }
        
        public string icon { get; set; }
    }

    public class Geometry
    {
        public string type = "Point";
        public List<double> coordinates = new List<double>();

        public Geometry(double lat , double longi)
        {
            coordinates.Add(lat);
            coordinates.Add(longi);
        } 

    }
}
