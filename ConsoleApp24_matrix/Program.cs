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
            int[,] bentMaradtak = new int[resztvevok, kategoriak];
            for (int i = 0; i < maxPont.Length; i++)
            {
                maxPont[i] = 50;
            }
            for (int i = 0; i < alsoPont.Length; i++)
            {
                alsoPont[i] = r.Next(0, 2);
            }

            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    kutyaSzepsegVerseny[i, j] = 2;
                }
            }
            int kiesett = -1;
            int[] kiesettek = new int[resztvevok];
            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    if(kiesett != i)
                    {
                        if (kutyaSzepsegVerseny[i, j] < alsoPont[j])
                        {
                            kiesett = i;
                            kiesettek[i] = i;
                        }
                    }
                }
                if (kiesett == i)
                {
                    Console.WriteLine("Ez a kutya kiesett, mert valamely kategóriát" +
                            "nem tudta teljesíteni: {0}.", i);
                }
                else
                {
                    Console.WriteLine("Bent maradt: {0}", i);
                }
            }
            for (int i = 0; i < resztvevok; i++)
            {
                //Console.Write("{0} :",i);
                for (int j = 0; j < kategoriak; j++)
                {
                    if (kiesettek[i] == 0)
                    {
                        bentMaradtak[i, j] = kutyaSzepsegVerseny[i, j];
                        //Console.Write("{0} ({1}), ", j, bentMaradtak[i,j]);
                    }
                }
                //Console.WriteLine();
            }

            int[] legjobb = new int[resztvevok];
            int legeslegjobb = 0;
            //int hanyszorNyert = 0;
            int kinyert = 0;
            int dontetlenEgy = 0;
            int dontetlenKetto = 0;
            for (int j = 0; j < kategoriak-1; j++)
            {
                legeslegjobb = 0;
                dontetlenKetto = 0;
                dontetlenEgy = 0;
                for (int i = 0; i < resztvevok-1; i++)
                {
                    if (legeslegjobb < bentMaradtak[i, j])
                    {
                        legeslegjobb = bentMaradtak[i, j];
                        dontetlenEgy = i;
                        //hanyszorNyert++;
                        kinyert = i;
                    }
                    else if(legeslegjobb == bentMaradtak[i, j])
                    {
                        dontetlenKetto = i;
                    }
                }
                if(dontetlenEgy == dontetlenKetto)
                {
                    Console.WriteLine("Itt van egy holtverseny az első helyért: a {0} és a {1} " +
                        "versenyző között. Ebben a kategóriában: {2}", dontetlenEgy, dontetlenKetto, j);
                }
                else
                {
                    Console.WriteLine("Nincsen döntetlen.");
                }
                legjobb[kinyert]++;
            }
            int gyoztes = 0;
            
            for (int i = 0; i < legjobb.Length; i++)
            {
                if(legjobb[i] == kategoriak)
                {
                    gyoztes = legjobb[i];
                    
                }
                //if(legjobb[i] == kategoriak)
            }
            if (gyoztes != 0)
            {
                Console.WriteLine("{0}. résztvevő nyert minden kategóriában.", gyoztes);
            }
            else
            {
                Console.WriteLine("Nincsen olyan, aki minden kategóriában a legjobb.");
            }
            
            Console.ReadLine();
        }
    }
}
