using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafFeladat_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var graf = new Graf(6);

            graf.Hozzaad(0, 1);
            graf.Hozzaad(1, 2);
            graf.Hozzaad(0, 2);
            graf.Hozzaad(2, 3);
            graf.Hozzaad(3, 4);
            graf.Hozzaad(4, 5);
            graf.Hozzaad(2, 4);

            //graf.torol(2);
            Console.WriteLine("szélességi bejárás");
            foreach (var item in graf.selsegBejaras(0))
	        {
                Console.WriteLine(item);
	        }
            Console.WriteLine();

            Console.WriteLine("mélységi bejárás");
            foreach (var item in graf.mejsegibelyaras(0))
	        {
                Console.WriteLine(item);
	        }
            Console.WriteLine();
            Console.WriteLine((graf.bejarhato(0))? "a gráf bejárhtó" : "a gráf nem bejárhtó");
            Console.WriteLine();

            

            Console.WriteLine(graf);

            graf.feszitoFa();

            Console.WriteLine("fesziton fa");
            Console.WriteLine(graf);

            Console.ReadLine();
        }
    }
}
