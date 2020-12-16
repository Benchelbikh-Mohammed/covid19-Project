using System;
using System.Collections;
using System.Collections.Generic;

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

    public Citoyen(string cin) {

        listBeenInContactWith = new List<Citoyen>();
        _cin = cin; 
    }


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

      if (listBeenInContactWith == null)
         listBeenInContactWith = new List<Citoyen>();

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
   public string cin { get => _cin; }
   private Color _codeCouleur;
    
   public Color codeCouleur { 
        get => _codeCouleur; 
        set {
            if (value.GetType() != typeof(Color)) return;

            _codeCouleur = value;
        } 
   }

   

   private bool estVaccine;
   private bool enQuarantaine;

}