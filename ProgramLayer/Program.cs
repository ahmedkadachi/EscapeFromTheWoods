using System;
using System.Collections.Generic;
using BusinessLayer.Model;
using EscapeFromTheWoods;
using ExportLayer;

namespace ProgramLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int aantalBomen = 700;
            List<Boom> bomen = new List<Boom>();
            List<Aap> apen = new List<Aap>();
            Bos bos1 = new Bos(1, 0, 1000, 0, 1000);
            BitmapExport bmex = new BitmapExport();
            TextFileExport txtfilex = new TextFileExport();

            bomen = bos1.MaakBoomAan(aantalBomen);
            apen.Add(new Aap(apen.Count, "Ahmed"));
            apen.Add(new Aap(apen.Count, "Walid"));
            apen.Add(new Aap(apen.Count, "Tom"));
            apen.Add(new Aap(apen.Count, "Bert"));
            apen.Add(new Aap(apen.Count, "Miguel"));

            bos1.PlaatsApenOpBomen(apen, bomen);
            bos1.Spring(apen, bomen);

            bmex.TekenElips(apen, bomen, bos1);
            Console.WriteLine("Tekenen van de bitmap is klaar");
            txtfilex.MaakTextBestandAan(apen, bomen);
            Console.WriteLine("Scrhijven van de textbestand is klaar");


        }
    }
}
