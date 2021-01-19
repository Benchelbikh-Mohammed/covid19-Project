using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public enum Color
    {
        red,
        green,
        orange,
        blue,
        gray
    }

    public class Citoyen
    {
        
        public string cin { get; set; }
        
        
        private Color codeCouleur
        {
            get {
                if (CheckType() == "Patient") return Color.red;
                if (isSuspect) return Color.orange;
                return Color.green;
            }
        }        
        
        public bool isSuspect { get; set; }
        public string type { get; set; }

        public string CheckType()
        {
            return GetType().ToString();
        }

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
                this.cin = cin;
                isSuspect = false;
                

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
                cit.isSuspect = true;
            }

            cin = c.cin;
        }
        //public T Clone<T>() where T : Citoyen, new()
        //{
        //    return new T() { cin = this.cin, codeCouleur = this.codeCouleur , isVaccinated = isVaccinated , inQuarantine = inQuarantine };
        //}
        public void SetCitoyenB(List<Citoyen> newCitoyenB)
        {
            RemoveAllBeenInContactWith();
            foreach (Citoyen oCitoyen in newCitoyenB)
                AddCotoye(oCitoyen);
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

        

        private static Dictionary<string, List<Citoyen>> graph = new Dictionary<string, List<Citoyen>>();
    }
}
