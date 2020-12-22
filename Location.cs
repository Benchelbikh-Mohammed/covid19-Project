using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diagramme_classe
{
    public class Location
    {
        private string _name;
        public string name { get => _name; set { _name = value; } }


        public Location(string n) => name = n;

        public override string ToString() => $"location : {name}";


    }
}
