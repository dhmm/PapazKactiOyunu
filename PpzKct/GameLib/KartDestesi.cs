using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PpzKct.GameLib
{
    /// <summary>
    /// Kart destesi
    /// Tum kartlarin tutuldugu deste
    /// </summary>
    static class KartDestesi
    {
        static Random R = new Random();
        static Dictionary<int, Kart> Deste {set;get;}       

        /// <summary>
        /// Desteyi sirali bir sekilde olusturur 
        /// </summary>
        static internal void DesteyiOlustur()
        {
            Deste = new Dictionary<int, Kart>();
            SinekleriOlustur();
            ValeleriOlustur();
            KupalariOlustur();
            MacalariOlustur();
            SinekPapaziEkle();

            
        }
        static void SinekleriOlustur()
        {
            KartTipiOlustur(1, KartTipi.Sinek);
        }
        static void ValeleriOlustur()
        {
            KartTipiOlustur(13, KartTipi.Karo);
        }
        static void KupalariOlustur()
        {
            KartTipiOlustur(25, KartTipi.Kupa);
        }
        static void MacalariOlustur()
        {
            KartTipiOlustur(37, KartTipi.Maca);
        }
        /// <summary>
        /// Tek olan papazi sona ekliyoruz
        /// </summary>
        static void SinekPapaziEkle()
        {            
            Deste.Add(49,new Kart(KartTipi.Sinek,13));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Dictionary de key gerekli </param>
        /// <param name="kartTipi"></param>
        static void KartTipiOlustur(int key, KartTipi kartTipi)
        {
            int startKey = key;
            for (int i = 1; i <= 12; i++)
            {
                Kart kart = new Kart(kartTipi,i);
                Deste.Add(key, kart);
                key++;
            }
        }
        static internal void KartlariKaristir()
        {            
            List<int> rasgeleNumaralar = new List<int>();
            for (int i = 1; i <= 49; i++)
            {
                bool olmayanNumaraBulunduMu = false;
                while (!olmayanNumaraBulunduMu)
                {
                    int rasgeleNumara = R.Next(1, 50);
                    if (!rasgeleNumaralar.Contains(rasgeleNumara))
                    {
                        rasgeleNumaralar.Add(rasgeleNumara);
                        olmayanNumaraBulunduMu = true;
                    }
                }
            }

            Dictionary<int, Kart> rastgeleDeste = new Dictionary<int, Kart>();
            int anahtar = 1;
            foreach (int numara in rasgeleNumaralar)
            {
                rastgeleDeste.Add(anahtar, Deste[numara]);
                anahtar++;
            }
            Deste = rastgeleDeste;


            
            foreach (Kart k in Deste.Values)
            {
                Debug.WriteLine(k.KartTipi + "-" + k.KartNo + " , ");
               
            }
        }

        //Kartlari oyunculara dagit
        internal static void Dagit(Dictionary<int, Oyuncu> oyuncular, int baslayanOyuncu)
        {
            int destedekiVerilenAktifKagit = 1;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    oyuncular[i].Kartlar.Add(j, Deste[destedekiVerilenAktifKagit]);
                    destedekiVerilenAktifKagit++;
                }
            }
            //Baslayan oyuncuun onundeki oyuncuya ibr kart fazla ver
            oyuncular[OyuncuNoBul.Onceki(baslayanOyuncu)].Kartlar.Add(13, Deste[49]);            
        }
    }
}
