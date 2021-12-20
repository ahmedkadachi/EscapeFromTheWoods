using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model;
using EscapeFromTheWoods;

namespace ExportLayer
{
    public class TextFileExport
    {
        public void MaakTextBestandAan(List<Aap> aap, List<Boom> boom)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\apen.txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                int meesteStappen = 0;
                foreach (Aap element in aap)
                {
                    if (meesteStappen < element.BoomLijst.Count)
                        meesteStappen = element.BoomLijst.Count;
                }

                for (int i = 0; i < meesteStappen; i++)
                {
                    foreach (Aap element in aap)
                    {
                        Console.Write(" L-START ");
                        if (element.BoomLijst.Count > i)
                            if (element.BoomLijst[i].X != -1)
                                sw.WriteLine(element.Naam + " is in tree " + element.BoomLijst[i].ID + " at (" + element.BoomLijst[i].X + "," + element.BoomLijst[i].Y + ")");
                            else
                                sw.WriteLine(element.Naam + " is out the woods");
                        Console.Write(" L-STOP ");
                    }
                }
            }
        }
    }
}
