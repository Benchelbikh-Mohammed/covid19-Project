using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diagramme_classe
{
    class Program
    {


        static void Main(string[] args)
        {
            Citoyen c = new Citoyen("D871624");

            Patient p = new Patient(c);

            Console.WriteLine(p.cin);
            Console.WriteLine(p.codeCouleur);
            
            //p.codeCouleur = Color.green;

            //c.codeCouleur = Color.green;

            //Console.WriteLine(p.codeCouleur == c.codeCouleur);


            //Console.WriteLine(c.GetType());
            //Citoyen c1 = new Citoyen("45127");
            
            
            

            

            Console.ReadKey();
        }
    

    } 
}
    

