using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using BusinessLayer.Model;
using EscapeFromTheWoods;

namespace ExportLayer
{
    public class BitmapExport
    {
        public void TekenElips(List<Aap> apen, List<Boom> bomen, Bos bos1)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + bos1.ID + "_escapeRoute.jpg";
            Bitmap bm = new Bitmap((bos1.XMax - bos1.XMin), (bos1.YMax - bos1.YMin));

            Graphics g = Graphics.FromImage(bm);
            Pen PenTree = new Pen(Color.Green, 1);


            //alle bomen tekenen
            foreach (Boom element in bomen)
            {
                g.DrawEllipse(PenTree, element.X, element.Y, 10, 10);
            }

            //tekenen van de eerste aap
            foreach (Aap element in apen)
            {
                Pen mijnPen = new Pen(Color.Red, 1);
                Brush mijnBrush = new SolidBrush(Color.Red);
                switch (element.ID)
                {
                    case 0:
                        mijnPen = new Pen(Color.Red, 1);
                        mijnBrush = new SolidBrush(Color.Red);
                        break;
                    case 1:
                        mijnPen = new Pen(Color.Blue, 1);
                        mijnBrush = new SolidBrush(Color.Blue);
                        break;
                    case 2:
                        mijnPen = new Pen(Color.Yellow, 1);
                        mijnBrush = new SolidBrush(Color.Yellow);
                        break;
                    case 3:
                        mijnPen = new Pen(Color.Orange, 1);
                        mijnBrush = new SolidBrush(Color.Orange);
                        break;
                    case 4:
                        mijnPen = new Pen(Color.White, 1);
                        mijnBrush = new SolidBrush(Color.White);
                        break;
                    default:
                        mijnPen = new Pen(Color.Red, 1);
                        mijnBrush = new SolidBrush(Color.Red);
                        break;
                }

                for (int i = 0; i < element.BoomLijst.Count - 1; i++)
                {
                    Console.Write(" T-START ");
                    if (i == 0)
                    {
                        g.FillEllipse(mijnBrush, element.BoomLijst[i].X, element.BoomLijst[i].Y, 10, 10);
                    }
                        

                    if (element.BoomLijst[i + 1].X != -1)
                    {
                        g.DrawLine(mijnPen, element.BoomLijst[i].X, element.BoomLijst[i].Y, element.BoomLijst[i + 1].X, element.BoomLijst[i + 1].Y);
                    }
                        
                Console.Write(" T-STOP ");
            }
        }
            bm.Save(path, ImageFormat.Jpeg);
        }
    }
}
