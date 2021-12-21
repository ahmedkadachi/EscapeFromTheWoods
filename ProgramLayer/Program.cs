using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            DbExport dbexport = new DbExport();

            List<Task> tasks = new List<Task>();

            bomen = bos1.MaakBoomAan(aantalBomen);
            apen.Add(new Aap(apen.Count, "Ahmed"));
            apen.Add(new Aap(apen.Count, "Walid"));
            apen.Add(new Aap(apen.Count, "Tom"));
            apen.Add(new Aap(apen.Count, "Bert"));
            apen.Add(new Aap(apen.Count, "Miguel"));

            bos1.PlaatsApenOpBomen(apen, bomen);
            bos1.Spring(apen, bomen);

            tasks.Add(Task.Run(() => bmex.TekenElips(apen, bomen, bos1)));
            tasks.Add(Task.Run(() =>txtfilex.MaakTextBestandAan(apen, bomen)));


            //tabel woodRecords opvullen
            tasks.Add(Task.Run(() => dbexport.VerwijderAlleBomen()));
            tasks.Add(Task.Run(() => dbexport.VoegBoomToe(bomen, bos1)));

            //tabel monkeyRecords opvullen
            tasks.Add(Task.Run(() => dbexport.VerwijderAlleApenGegevens()));
            tasks.Add(Task.Run(() => dbexport.VoegAapGegevens(apen, bomen, bos1)));

            //tabel logs opvullen
            tasks.Add(Task.Run(() => dbexport.VerwijderAlleLogGegevens()));
            tasks.Add(Task.Run(() => dbexport.VoegLogGegevens(apen, bos1)));
            Task.WaitAll(tasks.ToArray());

        }
    }
}
