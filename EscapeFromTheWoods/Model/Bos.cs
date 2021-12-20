using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeFromTheWoods;

namespace BusinessLayer.Model
{
    public class Bos
    {
        public int XMin { get; set; }
        public int XMax { get; set; }
        public int YMin { get; set; }
        public int YMax { get; set; }
        public int ID { get; set; }


        public Bos(int id, int xmin, int xmax, int ymin, int ymax)
        {
            this.XMax = xmax;
            this.XMin = xmin;
            this.YMin = ymin;
            this.YMax = ymax;
            this.ID = id;
        }

        public List<Boom> MaakBoomAan(int aantal)
        {
            Random r = new Random();
            List<Boom> bomen = new List<Boom>();

            while(bomen.Count < aantal + 1)
            {
                Boom b = new Boom(r.Next(this.XMin, this.YMax), r.Next(this.YMin, this.YMax), bomen.Count);
                bool isOK = true;
                foreach (Boom element in bomen)
                    if (b.X == element.X && b.Y == element.Y)
                        isOK = false;

                if (isOK)
                    bomen.Add(b);
            }
            return bomen;
        }
        public void PlaatsApenOpBomen(List<Aap> apenLijst, List<Boom> bomenLijst)
        {
            foreach(Aap element in apenLijst)
            {
                Random r = new Random();
                int boomId = r.Next(0, bomenLijst.Count);
                bool allesOk = true;
                foreach(Aap el in apenLijst)
                {
                    if(el.BoomLijst == null)
                    {
                        if(boomId == el.BoomLijst[0].ID)
                        {
                            allesOk = false;
                        }
                    }
                }
                if (allesOk)
                    element.BoomLijst.Add(bomenLijst[boomId]);
            }
        }

        public void Spring(List<Aap> apen, List<Boom> bomen)
        {
            int aantalUitHetBos = 0;
            while(aantalUitHetBos < apen.Count)
            {
                foreach (Aap element in apen)
                {
                    int huidigeX = element.BoomLijst[element.BoomLijst.Count - 1].X;
                    int huidigeY = element.BoomLijst[element.BoomLijst.Count - 1].Y;
                    if (huidigeX != -1)
                    {
                        double tijdelijkeAfstand = 2000000000;
                        Boom gekozenBoom = null;

                        //checken welke boom het dichtste is
                        foreach (Boom ele in bomen)
                        {
                            //check voor niet dezelfde boom te pakken
                            if (ele != element.BoomLijst[element.BoomLijst.Count - 1])
                            {

                                //checken voor niet een van de vorige bomen te pakken
                                bool isOK = true;
                                foreach (Boom elementEigenAap in element.BoomLijst)
                                {
                                    if (elementEigenAap.ID == ele.ID)
                                        isOK = false;
                                }
                                foreach (Aap c in apen)
                                    foreach (Boom d in c.BoomLijst)
                                        if (d == ele)
                                            isOK = false;
                                if (isOK)
                                {
                                    double werkelijkeAfstand = Math.Sqrt(Math.Pow(huidigeX - ele.X, 2) + Math.Pow(huidigeY - ele.Y, 2));
                                    if (werkelijkeAfstand < tijdelijkeAfstand)
                                    {
                                        tijdelijkeAfstand = werkelijkeAfstand;
                                        gekozenBoom = ele;
                                    }
                                }
                            }
                        }

                        //de afstand van de dichtste muur berekenen
                        double distanceToBorder = (new List<double>() { this.YMax - huidigeY, this.XMax - huidigeX, huidigeY - this.YMin, huidigeX - this.XMin }).Min();

                        //de afstand tussen de dichtste muur en de afstand tussen de dichtste boom vergelijken
                        if (tijdelijkeAfstand < distanceToBorder)
                        {
                            element.BoomLijst.Add(gekozenBoom);
                            Console.WriteLine("Aap " + element.Naam + " is op boom: " + gekozenBoom.ID);
                        }
                        else
                        {
                            //aap gaat weg
                            element.BoomLijst.Add(new Boom(-1, -1, -1));
                            aantalUitHetBos++;
                            Console.WriteLine("Aap " + element.Naam + " is uit het bos met " + element.BoomLijst.Count+" stappen");
                        }
                    }

                }
            }
        }
    }
}
