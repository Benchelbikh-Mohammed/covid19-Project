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
            p.AddCotoye(new Citoyen("45127"));


            Console.WriteLine(p.listBeenInContactWith.Count);
            

            Console.ReadKey();
        }
    

    } 
}
    

