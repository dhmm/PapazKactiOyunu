using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PpzKct.GameLib
{
    /// <summary>
    /// Oyuncularda sonraki ve oncekini kolay bulabilmek icin
    /// olsuturulmus yardimci class
    /// </summary>
    static class OyuncuNoBul
    {
        static internal int Sonraki(int aktif)
        {
            if (aktif == 4)
            {
                return 1;
            }
            else
            {
                return aktif+1;
            }
        }
        static internal int Onceki(int aktif)
        {
            if (aktif == 1)
            {
                return 4;
            }
            else
            {
                return aktif-1;
            }
        }
    }
}
