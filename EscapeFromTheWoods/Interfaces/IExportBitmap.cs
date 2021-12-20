using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model;
using EscapeFromTheWoods;

namespace BusinessLayer.Interfaces
{
    public interface IExportBitmap
    {
        public void TekenElips(List<Aap> apen, List<Boom> bomen, Bos bos1);
    }
}
