using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PpzKct.GameLib
{
    internal class Kart
    {
        /// <summary>
        /// Kart numaralari 1-13 arasindadir
        /// 1-10 normal numaralar
        /// 11,12,13 Vale , Kiz ,Papaz sirasiyla
        /// </summary>
        internal int KartNo { set; get; }
        internal KartTipi KartTipi { set; get; }

        internal Kart(KartTipi kartTipi , int kartNo)
        {
            KartNo = kartNo;
            KartTipi = kartTipi;
        }

        public Kart()
        {
            // TODO: Complete member initialization
        }
    }
}
