using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using PpzKct.GameLib.Controls;

namespace PpzKct.GameLib
{
    internal class Oyuncu
    {
        Oyun KatildigiOyun;
        internal Panel acikPanel = null;
        internal Panel kapaliPanel = null;

        private int _oyuncuNo = 0;
        int OyuncuNo 
        {
            set
            {
                //Eger oyuncu no 1 ise bu insan oyuncu
                if (value == 1)
                {                    
                    InsanOyuncu = true;
                }
                _oyuncuNo = value;
            }
            get
            {
                return _oyuncuNo;
            }
        }
        internal Dictionary<int, Kart> Kartlar;
        bool InsanOyuncu { set; get; }

        Random R = new Random();

        internal Oyuncu(Oyun oyun, int oyuncuNo)
        {
            KatildigiOyun = oyun;
            Kartlar = new Dictionary<int, Kart>();
            InsanOyuncu = false;
            OyuncuNo = oyuncuNo;
        }

        internal void Oyna()
        {
            KapaliKartlariDiz(kapaliPanel);
            if (this.Kartlar.Count == 0)
            {
                MessageBox.Show("Kartlar bitti kazanan oyuncu "+OyuncuNo);
            }
            else
            {
                if (!InsanOyuncu)
                {
                    BilgisayarOyna();
                }
                else
                {                    
                    return;
                }
                if (this.Kartlar.Count == 0)
                {
                    MessageBox.Show("Kartlar bitti  kazanan oyuncu " + OyuncuNo);
                }
                else
                {
                    KatildigiOyun.SonrakiOyuncuOyna();
                }
            }            
        }

        void BilgisayarOyna()
        {
            Debug.WriteLine("Bilgisayar oynuyor " + OyuncuNo);

            Kart cekilenKart = OncekiOyuncudanKartCek(KatildigiOyun.Oyuncular[OyuncuNoBul.Onceki(OyuncuNo)]);
            AynisiVarsaCiftOlarakAtVeyaElindeTut(cekilenKart);
            Debug.WriteLine("Oyuncu " + OyuncuNo + " kalan kart sayisi = " + Kartlar.Count);

        }
        internal void InsanOyna(Kart kart)
        {
           Debug.WriteLine("Insan oynuyor " + OyuncuNo);           
           Kart cekilenKart = kart;
           AynisiVarsaCiftOlarakAtVeyaElindeTut(cekilenKart);
           Debug.WriteLine("Oyuncu " + OyuncuNo + " kalan kart sayisi = " + Kartlar.Count);

           KatildigiOyun.SonrakiOyuncuOyna();
        }

        Kart OncekiOyuncudanKartCek(Oyuncu oncekiOyuncu)
        {
            if (oncekiOyuncu.Kartlar.Count > 0)
            {
                int rastgeleKart = R.Next(1, oncekiOyuncu.Kartlar.Count);
                Kart kart = oncekiOyuncu.KartAl(rastgeleKart);
                return kart;
            }
            else
            {
                return null;
            }
        
        }

        internal Kart KartAl(int rastgeleKart)
        {
            int i = 1;
            foreach (int key in Kartlar.Keys)
            {
                if (i == rastgeleKart)
                {
                    Kart verilenKart = Kartlar[key];
                    Kartlar.Remove(key);
                    return verilenKart;
                }
                i++;
            }
            return null;
        }
        internal void AynisiVarsaCiftOlarakAtVeyaElindeTut(Kart cekilenKart)
        {
            bool bulundu = false;
            int bulunanKey = -1;
            foreach (int key in this.Kartlar.Keys)
            {
                Kart destedekiKart = this.Kartlar[key];
                //Ayni kart var
                //at
                if (destedekiKart.KartNo == cekilenKart.KartNo)
                {
                    bulunanKey = key;
                    bulundu = true;                    
                    continue;
                }
            }
            //eger cfit bulunmadiysa desteye ekle
            if (bulundu)
            {                
                Debug.WriteLine("Oyuncu " + OyuncuNo + " cektigi  " + cekilenKart.KartNo + "-" + cekilenKart.KartTipi + " kartini "+Kartlar[bulunanKey].KartNo+"-"+Kartlar[bulunanKey].KartTipi+" ile atti ");
                KartAt(cekilenKart,acikPanel);
                KartAt(Kartlar[bulunanKey],acikPanel);
                Application.DoEvents();
                this.Kartlar.Remove(bulunanKey);                
            }
            else
            {
                this.Kartlar.Add(this.Kartlar.Keys.Max() + 1, cekilenKart);
                Debug.WriteLine("Oyuncu " + OyuncuNo + " cektigi karti " + cekilenKart.KartNo + "-" + cekilenKart.KartTipi + " elinde tuttu ");
            }
        }

        internal void KapaliKartlariDiz(Panel panel)
        {
            panel.Controls.Clear();
            int aktifLeft = 0;
            foreach (int key in this.Kartlar.Keys)
            {
                Kart k = this.Kartlar[key];

                KartControl kartControl = new KartControl();
                kartControl.KartKey = key;
                kartControl.Kart = k;
                kartControl.Left = aktifLeft;
                kartControl.OyuncuNo = this.OyuncuNo;
                kartControl.IcindeBulunduguOyun = this.KatildigiOyun;
                     
                if (OyuncuNo != 1)
                {
                    kartControl.Close();
                }
                else
                {
                    kartControl.Show();
                }
                panel.Controls.Add(kartControl);
                kartControl.BringToFront();
                if (OyuncuNo != 1)
                {
                    aktifLeft += 20;
                }
                else
                {
                    aktifLeft += kartControl.Width;
                }
            }
            Application.DoEvents();
        }
        internal void KartAt(Kart kart, Panel panel)
        {
            Kart k = kart;

            KartControl kartControl = new KartControl();            
            kartControl.Kart = k;
            kartControl.Left = panel.Controls.Count * (kartControl.Width-10);
            kartControl.Show();
            panel.Controls.Add(kartControl);
            kartControl.BringToFront();            
        }
        
    }
}
