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
            int kategoriak = 7;
            int resztvevok = 20;
            // el kell kezdeni
            int[] maxPont = new int[kategoriak]; //  kategóriánként hány pontot kaphatnak
            int[] alsoPont = new int[kategoriak]; // kategóriánként mennyi az alsó ponthatár
            
            int[,] kutyaSzepsegVerseny = new int[resztvevok, kategoriak]; // a résztvevő hány pontot kapott az adott kategóriában
            int[,] bentMaradtak = new int[resztvevok, kategoriak];
            for (int i = 0; i < maxPont.Length; i++)
            {
                maxPont[i] = r.Next(50,100);
            }
            for (int i = 0; i < alsoPont.Length; i++)
            {
                alsoPont[i] = r.Next(0,20);
            }
            for (int i = 0; i < alsoPont.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, alsoPont[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    kutyaSzepsegVerseny[i, j] = r.Next(0,maxPont[j]);
                }
            }

            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    Console.Write("({0}, {1}): {2};   ", i, j, kutyaSzepsegVerseny[i,j]);
                }
                Console.WriteLine();
            }
            //döntsük melyek estek ki
            int kiesett = -1;
            int[] kiesettek = new int[resztvevok];
            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    if(kiesett != i)
                    {
                        if (kutyaSzepsegVerseny[i, j] <= alsoPont[j])
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
            //döntsük el van-e döntetlen
            int[] legjobb = new int[resztvevok];
            int legeslegjobb = 0;
            //int hanyszorNyert = 0;
            int[] kinyert = new int[kategoriak];
            int dontetlenEgy = 0;
            int dontetlenKetto = 0;
            bool dontetlen = false;
            for (int j = 0; j < kategoriak; j++)
            {
                legeslegjobb = 0;
                dontetlenKetto = -1;
                dontetlenEgy = -1;
                for (int i = 0; i < resztvevok; i++)
                {
                    if (legeslegjobb < bentMaradtak[i, j])
                    {
                        legeslegjobb = bentMaradtak[i, j];
                        dontetlenEgy = i;
                        //hanyszorNyert++;
                        kinyert[j] = i;
                    }
                    else if(legeslegjobb == bentMaradtak[i, j])
                    {
                        dontetlenKetto = i;
                    }
                }
                if(dontetlenEgy != dontetlenKetto && dontetlenKetto != -1)
                {
                    Console.WriteLine("Itt van egy holtverseny az első helyért: a {0} és a {1} " +
                        "versenyző között. Ebben a kategóriában: {2}", dontetlenEgy, dontetlenKetto, j);
                    dontetlen = true;
                }
                else
                {
                    Console.WriteLine("Nincsen döntetlen.");
                }
                //legjobb[j]++;
            }
            //döntsük el van-e olyan aki minden kategóriában nyert
            int gyoztes = kinyert[0];
            int gyozelmekSzama = 0;
            
            for (int i = 0; i < kinyert.Length; i++)
            {
                if(gyoztes == kinyert[i])
                {
                    gyozelmekSzama++;
                }
            }
            if (gyozelmekSzama == kategoriak && dontetlen == false)
            {
                Console.WriteLine("{0}. résztvevő nyert minden kategóriában.", kinyert[0]);
            }
            else
            {
                Console.WriteLine("Nincsen olyan, aki minden kategóriában a legjobb.");
            }
            
            Console.ReadLine();
        }
    }
}
