using System;

public class Patient : Citoyen
{
    public Patient(string cin)
        : base(cin) { } 

    public Patient(Citoyen c): this(c.cin) { }
    

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