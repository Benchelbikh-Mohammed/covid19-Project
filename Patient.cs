using System;

public class Patient : Citoyen
{
    public Patient(Citoyen c)
        : base(c) { } 


    
    

   public void RepasserTest()
   {
      // TODO: implement
   }
   
   public void PasserTestCategorique()
   {
      // TODO: implement
   }

   public DossierMedical dossierMedical;

   private int NbrJoursHopital;

}