using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace PpzKct.GameLib
{
    class Oyun
    {
        /// <summary>
        /// 1 -> Insan oyuncu
        /// 2,3,4 - > Bilgisayar oyuncular
        /// </summary>
        internal Dictionary<int, Oyuncu> Oyuncular;
        
        internal int AktifOyuncu {set;get;}
        int BaslayanOyuncu { set; get; }
        Random R  = new Random();

        internal Oyun()
        {
            InitYap();
        }

        void InitYap()
        {
            Oyuncular = new Dictionary<int, Oyuncu>();
            OyunculariOlustur();
            BaslayanOyuncu = R.Next(1, 5);
            AktifOyuncu = BaslayanOyuncu; 
        }
        void OyunculariOlustur()
        {
            for (int i = 1; i <= 4; i++)
            {
                Oyuncu oyuncu = new Oyuncu(this,i);
                Oyuncular.Add(i, oyuncu);
            }
        }
        internal void YeniOyunBaslat(Panel pnl1Acik,Panel pnl1Kapali,
                                     Panel pnl2Acik, Panel pnl2Kapali,
                                     Panel pnl3Acik, Panel pnl3Kapali,
                                     Panel pnl4Acik, Panel pnl4Kapali)
        {
            InitYap();
            Oyuncular[1].acikPanel = pnl1Acik;
            Oyuncular[2].acikPanel = pnl2Acik;
            Oyuncular[3].acikPanel = pnl3Acik;
            Oyuncular[4].acikPanel = pnl4Acik;
            Oyuncular[1].kapaliPanel = pnl1Kapali;
            Oyuncular[2].kapaliPanel = pnl2Kapali;
            Oyuncular[3].kapaliPanel = pnl3Kapali;
            Oyuncular[4].kapaliPanel = pnl4Kapali;
            pnl1Acik.Controls.Clear();
            pnl2Acik.Controls.Clear();
            pnl3Acik.Controls.Clear();
            pnl4Acik.Controls.Clear();
            pnl1Kapali.Controls.Clear();
            pnl2Kapali.Controls.Clear();
            pnl3Kapali.Controls.Clear();
            pnl4Kapali.Controls.Clear();


            KartDestesi.DesteyiOlustur();
            KartDestesi.KartlariKaristir();
            KartDestesi.Dagit(Oyuncular,BaslayanOyuncu);
            Oyuncular[1].KapaliKartlariDiz(Oyuncular[1].kapaliPanel);
            Oyuncular[2].KapaliKartlariDiz(Oyuncular[2].kapaliPanel);
            Oyuncular[3].KapaliKartlariDiz(Oyuncular[3].kapaliPanel);
            Oyuncular[4].KapaliKartlariDiz(Oyuncular[4].kapaliPanel);
            AktifOyuncuOyna();      
        }
        internal void SonrakiOyuncuOyna()
        {            
            KartlarYazdir(); //DEBUG
            AktifOyuncu = OyuncuNoBul.Sonraki(AktifOyuncu);          
            AktifOyuncuOyna();
        }
        void AktifOyuncuOyna()
        {
            Oyuncular[AktifOyuncu].Oyna();
            
        }
        //DEBUG
        void KartlarYazdir()
        {
            for (int i = 1; i <= 4; i++)
            {
                Debug.Write("Oyuncu = " + i.ToString() + " ");
                foreach(Kart k in Oyuncular[i].Kartlar.Values)
                {                    
                    Debug.Write(k.KartNo.ToString() + k.KartTipi.ToString() + " , ");
                }
                Debug.WriteLine("");
            }
        }
    }
}
