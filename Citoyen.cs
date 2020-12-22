using diagramme_classe;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Reflection;

public enum Color
{
    red,
    green,
    orange,
    blue,
    gray
}

namespace diagramme_classe
{
    public class Citoyen
    {
        private static Dictionary<string, Citoyen> citoyens = new Dictionary<string, Citoyen>();
        private static Dictionary<string, List<Citoyen>> graph = new Dictionary<string, List<Citoyen>>();

     

        public List<Citoyen> cotoye
        {
            get
            {
                List<Citoyen> _cotoye;
                if (graph.TryGetValue(cin, out _cotoye))
                {
                    return _cotoye;
                }
                return new List<Citoyen>();
            }
        }
        public Citoyen(string cin)
        {


            try
            {
                graph.Add(cin, new List<Citoyen>());
                _cin = cin;
                _isSuspect = false;
                codeCouleur = Color.green;
                estVaccine = false;
                enQuarantaine = false;

                
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = {0} already exists.", cin);
            }


        }


        protected Citoyen(Citoyen c)
        {
            foreach (var cit in c.cotoye)
            {
                cit._isSuspect = true;
            }

            _cin = c.cin;
            codeCouleur = c.codeCouleur;
            estVaccine = c.estVaccine;
            enQuarantaine = c.enQuarantaine;
        }

        //public T Clone<T>() where T : Citoyen, new()
        //{
        //    return new T() { cin = this.cin, codeCouleur = this.codeCouleur , estVaccine = estVaccine , enQuarantaine = enQuarantaine };
        //}



        public void SetCotoye(List<Citoyen> newCitoyenB)
        {
            RemoveAllBeenInContactWith();
            foreach (Citoyen oCitoyen in newCitoyenB)
                AddCotoye(oCitoyen);
        }

        public void beenTo(Location l)
        {
            if (!locations.Contains(l))
                locations.Add(l);

        }

        public void AddCotoye(Citoyen newCitoyen)
        {
            if (newCitoyen == null)
                return;

            if (cotoye != null)
            {
                cotoye.Add(newCitoyen);
                if (newCitoyen.cotoye != null)
                {
                    newCitoyen.cotoye.Add(this);
                }
            }
            else
            {
                Console.WriteLine($"Key = {cin} is not found.");
            }

        }

        public void RemoveBeenInContact(Citoyen oldCitoyen)
        {
            if (oldCitoyen == null)
                return;

            graph[cin].Remove(oldCitoyen);
        }

        public void RemoveAllBeenInContactWith()
        {
            graph[cin].Clear();
        }

        private string _cin;
        public string cin { get => _cin; }
        private Color _codeCouleur;

        public Color codeCouleur
        {
            get => _codeCouleur;
            set
            {
                if (value.GetType() != typeof(Color)) return;

                _codeCouleur = value;
            }
        }

        private bool _estVaccine;
        public bool estVaccine { get => _estVaccine; set { _estVaccine = value; } }
        private bool _enQuarantaine;
        public bool enQuarantaine { get => _enQuarantaine; set { _enQuarantaine = value; } }
        private bool _isSuspect;
        public bool isSuspect { get => _isSuspect; }
        private List<Location> locations = new List<Location>();

        public void printLocations()
        {
            foreach (var l in locations)
            {
                Console.WriteLine(l);
            }
        }



    }

}

