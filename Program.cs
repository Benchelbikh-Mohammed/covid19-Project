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

            Console.WriteLine(c1.isSuspect);
            Console.WriteLine(c2.isSuspect);

            Patient p = new Patient(c);

            Console.WriteLine(c1.isSuspect);
            Console.WriteLine(c2.isSuspect);


            foreach (var cit in p.cotoye)
            {
                Console.WriteLine(cit.cin);

            }

            p.RemoveBeenInContact(c1);

            Console.WriteLine("*****************************");

            foreach (var cit in p.cotoye)
            {
                Console.WriteLine(cit.cin);

            }





            Console.ReadKey();
        }
    

    } 
}
    

