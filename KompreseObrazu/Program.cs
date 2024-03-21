using System;
using System.Collections.Generic;

namespace Komprese
{
    public class KompreseObrazu
    {
        public static void Main(string[] args)
        {
            // Cesta k testovacímu souboru
            string testFilePath = @"C:\Users\MatyášMagera\github-classroom\Vitkovicka-stredni-prumyslova-skola\cv-komprese-obrazu-v2-matyasmagera\KompreseObrazu\CSV\obr1-10.csv";

            // Vytvoření instance třídy Obrazek
            Obrazek inputCSV = new Obrazek(testFilePath);

            // Vytvoření 2D pole obsahujícího hodnoty barev obrázku
            int[,] imageArray = inputCSV.ZískatObrazekArray();

            // Test metody, která spočítá počet řádků vstupního obrázku
            Console.WriteLine("Počet vertikálních řádků {0}", inputCSV.PocitejRadky(testFilePath));

            // Test metody, která spočítá počet symbolů vstupního obrázku v prvním řádku
            Console.WriteLine("Počet horizontálních symbolů {0}", inputCSV.Pocetsymboluvrade(testFilePath));

            // Výpis načteného obrázku
            inputCSV.vypisobrázku();

            // Seznam unikátních barev
            List<int> uniqueColors = inputCSV.PaletaBarevObrazku();

            // Vytvoření slovníku pro ukládání počtu výskytů jednotlivých barev v obrázku
            Dictionary<int, int> colorCounts = new Dictionary<int, int>();

            // Spočítat počty výskytů jednotlivých barev v obrázku
            foreach (int color in uniqueColors)
            {
                int count = inputCSV.Pocitejbarevnechvyskyty(color);
                colorCounts.Add(color, count);
            }

            // Výpis jednotlivých barev a jejich počtu výskytů
            Console.WriteLine("Barev v obrázku:");
            foreach (var kvp in colorCounts)
            {
                Console.WriteLine($"Barva: {kvp.Key}, Počet výskytů: {kvp.Value}");
            }
        }
    }
}