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
            /*
            kutyaSzepsegVerseny[0, 0] = 40;
            kutyaSzepsegVerseny[0, 1] = 40;
            kutyaSzepsegVerseny[0, 2] = 0;
            kutyaSzepsegVerseny[0, 3] = 40;
            kutyaSzepsegVerseny[1, 0] = 50;
            kutyaSzepsegVerseny[1, 1] = 50;
            kutyaSzepsegVerseny[1, 2] = 50;
            kutyaSzepsegVerseny[1, 3] = 50;
            kutyaSzepsegVerseny[2, 0] = 29;
            kutyaSzepsegVerseny[2, 1] = 29;
            kutyaSzepsegVerseny[2, 2] = 29;
            kutyaSzepsegVerseny[2, 3] = 40;
            kutyaSzepsegVerseny[3, 0] = 40;
            kutyaSzepsegVerseny[3, 1] = 40;
            kutyaSzepsegVerseny[3, 2] = 40;
            kutyaSzepsegVerseny[3, 3] = 40;
            */
            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    Console.Write("({0}, {1}): {2};   ", i, j, kutyaSzepsegVerseny[i,j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //döntsük melyek estek ki és 
            //döntsük el van-e olyan aki minden kategóriában kiesett
            int kiesett = -1;
            int[] kiesettek = new int[resztvevok];
            int kiesesekSzama = 0;
            
            for (int i = 0; i < resztvevok; i++)
            {
                kiesesekSzama = 0;
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
                    if (kutyaSzepsegVerseny[i, j] <= alsoPont[j])
                    {
                        kiesesekSzama++;
                    }
                }
                if (kiesesekSzama == kategoriak)
                {
                    Console.WriteLine("{0}. résztvevő vesztett minden kategóriában.", i);
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
            //döntsük el van-e olyan kategória, ahol nem esett ki senki

            Console.WriteLine();

            int nemestekkiKategoria = 0;
            for (int i = 0; i < kategoriak; i++)
            {
                nemestekkiKategoria = 0;
                for (int j = 0; j < resztvevok; j++)
                {
                    if (kutyaSzepsegVerseny[j, i] > alsoPont[i])
                    {
                        nemestekkiKategoria++;
                    }
                }
                if(nemestekkiKategoria == resztvevok)
                {
                    Console.WriteLine("A {0}. kategóriában nem volt kieső kutya.", i);
                }
            }

            Console.WriteLine();

            for (int i = 0; i < resztvevok; i++)
            {
                if (kiesettek[i] == 0)
                {
                    //Console.Write("{0} :",i);
                    for (int j = 0; j < kategoriak; j++)
                    {
                        
                        bentMaradtak[i, j] = kutyaSzepsegVerseny[i, j];
                        Console.Write("({0}, {1}): {2};   ", i, j, bentMaradtak[i,j]);

                    }
                   
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            //döntsük el van-e döntetlen
            int[] legjobb = new int[resztvevok];
            
            int legeslegjobb = 0;
            int hanyszorNyert = 0;
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
                        kinyert[j] = i;
                        
                    }
                    else if(legeslegjobb == bentMaradtak[i, j])
                    {
                        dontetlenKetto = i;
                    }
                    
                    
                }
                if (dontetlenEgy != dontetlenKetto && 
                   dontetlenKetto > dontetlenEgy &&
                   dontetlenKetto != -1)
                {
                    Console.WriteLine("Itt van egy holtverseny az első helyért: a {0} és a {1} " +
                        "versenyző között. Ebben a kategóriában: {2}", dontetlenEgy, dontetlenKetto, j);
                    dontetlen = true;
                }
                else
                {
                    Console.WriteLine("Nincsen döntetlenaz első helyért.");
                }
            }
            




            
            Console.WriteLine();

            //döntsük el, hogy van –e olyan, aki abszolút győztes (összpontszám), de minden kategóriában volt nála jobb!
            //Console.WriteLine("Anyád");
            int[] legjobbEredmenyek = new int[kategoriak];
            legeslegjobb = 0;
            for (int j = 0; j < kategoriak; j++)
            {
                legeslegjobb = 0;
                for (int i = 0; i < resztvevok; i++)
                {
                    if (legeslegjobb < kutyaSzepsegVerseny[i, j])
                    {
                        legeslegjobb = kutyaSzepsegVerseny[i, j];
                        legjobbEredmenyek[j] = kutyaSzepsegVerseny[i, j];

                    }
                }

                Console.WriteLine("itt " + legjobbEredmenyek[j]);
            }


            int[] osszpontszam = new int[resztvevok];
            for (int i = 0; i < resztvevok; i++)
            {
                for (int j = 0; j < kategoriak; j++)
                {
                    osszpontszam[i] += kutyaSzepsegVerseny[i, j];
                }
                Console.WriteLine("{0}. résztvevő osszpontszáma: {1}", i, osszpontszam[i]);
            }

            Console.WriteLine();

            int abszolutGyoztes = osszpontszam[0];
            int abszolutNyertes = 0;
            for (int i = 0; i < resztvevok; i++)
            {
                if (abszolutGyoztes < osszpontszam[i])
                {
                    //Console.WriteLine("Anyád" + i);
                    abszolutGyoztes = osszpontszam[i];
                    abszolutNyertes = i;
                }
            }
            Console.WriteLine("{0}. résztvevő az abszolút győztes (összpontszám)", abszolutNyertes);
            int nalajobb = 0;
            for (int j = 0; j < kategoriak; j++)
            {
                if (kutyaSzepsegVerseny[abszolutNyertes, j] < legjobbEredmenyek[j])
                {
                    nalajobb++;
                }
            }
            if (nalajobb == kategoriak)
            {
                Console.WriteLine("{0}. résztvevő az abszolút győztes (összpontszám), de minden kategóriában volt nála jobb!", abszolutNyertes);
            }


            //döntsük el van-e olyan aki több kategóriában nyert
            for (int i = 0; i < kinyert.Length; i++)
            {
                Console.WriteLine(kinyert[i]);
            }
            hanyszorNyert = 0;
            for (int i = 0; i < resztvevok; i++)
            {
                hanyszorNyert = 0;
                for (int j = 0; j < kinyert.Length; j++)
                {
                    if (i == kinyert[j])
                    {
                        hanyszorNyert++;
                    }
                }
                if (hanyszorNyert < kategoriak && hanyszorNyert>0)
                {
                    Console.WriteLine("{0}: nyert {1}-szer", i, hanyszorNyert);
                }

                Console.WriteLine();

                //döntsük el van-e olyan aki minden kategóriában nyert
                if (hanyszorNyert == kategoriak && dontetlen == false)
                {
                    Console.WriteLine("{0}. résztvevő nyert minden kategóriában.", kinyert[i]);
                }
            }
         
            Console.ReadLine();
        }
    }
}
