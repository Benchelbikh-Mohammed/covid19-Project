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

            Citoyen c1 = new Citoyen("D77921");
            Citoyen c2 = new Citoyen("890766");

            c2.AddCotoye(c);


            c.AddCotoye(c1);

            foreach (var cinn in Citoyen.citoyenGraph.DFSRecursive(c1.cin) )
            {
                Console.WriteLine(cinn);
            }
            
            

            

            Console.ReadKey();
        }
    

    } 
}
    

