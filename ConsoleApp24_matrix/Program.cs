using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            //1. feladat
            int kategoriak = 10;
            int resztvevok = 30;
            // el kell kezdeni
            int[] maxPont = new int[10]; //  kategóriánként hány pontot kaphatnak
            int[] alsoPont = new int[10]; // kategóriánként mennyi az alsó ponthatár
            
            int[,] kutyaSzepsegVerseny = new int[resztvevok, kategoriak]; // a résztvevő hány pontot kapott az adott kategóriában

            for (int i = 0; i < maxPont.Length; i++)
            {
                maxPont[i] = r.Next(25, 50);
            }
            for (int i = 0; i < alsoPont.Length; i++)
            {
                alsoPont[i] = r.Next(0, 25);
            }

            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    kutyaSzepsegVerseny[i, j] = r.Next(0,50);
                }
            }
           
            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    if(kutyaSzepsegVerseny[i,j] < alsoPont[j])
                    {
                        Console.WriteLine("Ez a kutya kiesett, mert valamely kategóriát" + 
                            "nem tudta teljesíteni: {0}.", i);
                    }                   
                }
            }
            int[] legjobb = new int[resztvevok];
            int legeslegjobb = 0;
            //int hanyszorNyert = 0;
            int kinyert = 0;
            for (int j = 0; j < kategoriak; j++)
            {
                for (int i = 0; i < resztvevok; i++)
                {
                    if (legeslegjobb < kutyaSzepsegVerseny[i + 1, j]&& i !=resztvevok-2 && j!= kategoriak-2)
                    {
                        legeslegjobb = kutyaSzepsegVerseny[i + 1, j];
                        //hanyszorNyert++;
                        kinyert = i;
                    }
                }
                legjobb[kinyert]++;
            }
            for (int i = 0; i < legjobb.Length; i++)
            {
                if(legjobb[i] == kategoriak)
                {
                    Console.WriteLine("{0}. résztvevő nyert minden kategóriában.", legjobb[i]);
                }
            }
            
            Console.ReadLine();
        }
    }
}
