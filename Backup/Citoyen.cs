/***********************************************************************
 * Module:  Citoyen.cs
 * Author:  HP
 * Purpose: Definition of the Class Citoyen
 ***********************************************************************/

using System;

public abstract class Citoyen
{
   public abstract void SetCodeCouleur();

   public System.Collections.ArrayList citoyenB;
   
   /// <pdGenerated>default getter</pdGenerated>
   public System.Collections.ArrayList GetCitoyenB()
   {
      if (citoyenB == null)
         citoyenB = new System.Collections.ArrayList();
      return citoyenB;
   }
   
   /// <pdGenerated>default setter</pdGenerated>
   public void SetCitoyenB(System.Collections.ArrayList newCitoyenB)
   {
      RemoveAllCitoyenB();
      foreach (Citoyen oCitoyen in newCitoyenB)
         AddCitoyenB(oCitoyen);
   }
   
   /// <pdGenerated>default Add</pdGenerated>
   public void AddCitoyenB(Citoyen newCitoyen)
   {
      if (newCitoyen == null)
         return;
      if (this.citoyenB == null)
         this.citoyenB = new System.Collections.ArrayList();
      if (!this.citoyenB.Contains(newCitoyen))
         this.citoyenB.Add(newCitoyen);
   }
   
   /// <pdGenerated>default Remove</pdGenerated>
   public void RemoveCitoyenB(Citoyen oldCitoyen)
   {
      if (oldCitoyen == null)
         return;
      if (this.citoyenB != null)
         if (this.citoyenB.Contains(oldCitoyen))
            this.citoyenB.Remove(oldCitoyen);
   }
   
   /// <pdGenerated>default removeAll</pdGenerated>
   public void RemoveAllCitoyenB()
   {
      if (citoyenB != null)
         citoyenB.Clear();
   }

   protected string Cin;
   protected Color CodeCouleur;

   private bool EstVaccine;
   private bool EnQuarantaine;

}