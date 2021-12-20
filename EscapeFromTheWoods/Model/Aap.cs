using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeFromTheWoods;

namespace BusinessLayer.Model
{
    public class Aap
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public List<Boom> BoomLijst = new List<Boom>();
        public Aap(int id, string naam)
        {
            this.ID = id;
            this.Naam = naam;
        }
    }
}
