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

public class Citoyen
{

    static Graph CitoyenCotoiment = new Graph();



    public Citoyen(string cin) {

        listBeenInContactWith = new List<Citoyen>();
        _cin = cin;
        codeCouleur = Color.green;
        estVaccine = false;
        enQuarantaine = false;
    }

    public Citoyen(Citoyen c)
    {
        cin = c.cin;
        codeCouleur = c.codeCouleur;
        estVaccine = c.estVaccine;
        enQuarantaine = c.enQuarantaine;
    }

    //public T Clone<T>() where T : Citoyen, new()
    //{
    //    return new T() { cin = this.cin, codeCouleur = this.codeCouleur , estVaccine = estVaccine , enQuarantaine = enQuarantaine };
    //}


    public virtual void SetCodeCouleur()
    {

    }

   public List<Citoyen> listBeenInContactWith;
    
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

        if (!listBeenInContactWith.Contains(newCitoyen))
         listBeenInContactWith.Add(newCitoyen);


   }
   
   public void RemoveBeenInContact(Citoyen oldCitoyen)
   {
      if (oldCitoyen == null)
         return;
      if (listBeenInContactWith != null)
         if (listBeenInContactWith.Contains(oldCitoyen))
            listBeenInContactWith.Remove(oldCitoyen);
   }
   
   public void RemoveAllBeenInContactWith()
   {
      if (listBeenInContactWith != null)
         listBeenInContactWith.Clear();
   }

   private string _cin;
   public string cin { get => _cin; set { _cin = value; } }
   private Color _codeCouleur;
    
   public Color codeCouleur { 
        get => _codeCouleur; 
        set {
            if (value.GetType() != typeof(Color)) return;

            _codeCouleur = value;
        } 
   }

   private bool _estVaccine;
    public bool estVaccine { get => _estVaccine; set { _estVaccine = value; } }
   private bool _enQuarantaine;
    public bool enQuarantaine { get => _enQuarantaine; set { _enQuarantaine = value; } }

}