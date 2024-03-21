using System;
using System.Collections.Generic;
using System.IO;

namespace Komprese
{
    public class Obrazek
    {
        private int[,] obrazek = null;

        public Obrazek(string filePath)
        {
            readImg(filePath);
        }

        private void readImg(string filePath)
        {
            StreamReader sr = null;
            string[] line = null;
            string row;
            obrazek = new int[Pocetsymboluvrade(filePath), PocitejRadky(filePath)];

            try
            {
                using (sr = new StreamReader(filePath))
                {
                    int j = 0;

                    while ((row = sr.ReadLine()) != null)
                    {
                        line = row.Split(";", StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < obrazek.GetLength(0); i++)
                        {
                            obrazek[i, j] = Int32.Parse(line[i]);
                        }
                        j++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Soubor nelze načíst:");
                Console.WriteLine(e.Message);
            }
        }

        public int PocitejRadky(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                int i = 0;
                while (sr.ReadLine() != null) { i++; }
                return i;
            }
        }
        public int Pocetsymboluvrade(string filePath)
        {
            using (StreamReader sr = new StreamReader(path: filePath))
            {
                string[] line = sr.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                return line.Length;
            }
        }
        public List<int> PaletaBarevObrazku()
        {
            List<int> result = new List<int>();

            for (int j = 0; j < obrazek.GetLength(1); j++)
            {
                for (int i = 0; i < obrazek.GetLength(0); i++)
                {
                    if (!result.Contains(obrazek[i, j]))
                    {
                        result.Add(obrazek[i, j]);
                    }
                }
            }
            return result;
        }

        public int Pocitejbarevnechvyskyty(int color)
        {
            int count = 0;

            for (int j = 0; j < obrazek.GetLength(1); j++)
            {
                for (int i = 0; i < obrazek.GetLength(0); i++)
                {
                    if (obrazek[i, j] == color)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int[,] ZískatObrazekArray()
        {
            return obrazek;
        }

        public void vypisobrázku()
        {
            for (int j = 0; j < obrazek.GetLength(1); j++)
            {
                for (int i = 0; i < obrazek.GetLength(0); i++)
                {
                    Console.Write("{0}, ", obrazek[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}