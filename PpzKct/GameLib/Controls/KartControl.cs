using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PpzKct.GameLib.Controls
{
    public partial class KartControl : UserControl
    {
        internal Oyun IcindeBulunduguOyun { set; get; }
        internal int OyuncuNo { set; get; }

        int kartKey = 0;
        internal int KartKey
        {
            set
            {
                kartKey = value;
            }
            get
            {
                return kartKey;
            }
        }

        int _kartNo = 0;
        int _kartTipi = 0;
        internal Kart Kart
        {
            set
            {
                lblKartNo.Text = value.KartNo.ToString();
                lblKartTipi.Text = value.KartTipi.ToString();

                _kartNo = value.KartNo;
                _kartTipi = (int)value.KartTipi;
            }
        }
        
        public KartControl()
        {
            InitializeComponent();
            Close();
        }
        public void Close()
        {
            lblKartNo.Hide();
            lblKartTipi.Hide();
            this.BackColor = Color.Gray;
        }
        public void Show()
        {
            lblKartNo.Show();
            lblKartTipi.Show();
            this.BackColor = Color.White;
        }

        private void KartControl_Click(object sender, EventArgs e)
        {
            if (IcindeBulunduguOyun.AktifOyuncu == 1 && OyuncuNo == 4)
            {
                Kart kart = new Kart();
                
                kart.KartNo = this._kartNo;
                kart.KartTipi = (KartTipi)this._kartTipi;
                IcindeBulunduguOyun.Oyuncular[1].InsanOyna(kart);
            }
        }

        Color ActiveColor = new Color();
        private void KartControl_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (IcindeBulunduguOyun.AktifOyuncu == 1 && OyuncuNo == 4 && this.lblKartNo.Visible == false)
                {
                    this.BackColor = Color.Blue;
                }
            }
            catch (Exception)
            {
            }
        }

        private void KartControl_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (IcindeBulunduguOyun.AktifOyuncu == 1 && OyuncuNo == 4 && this.lblKartNo.Visible == false)
                {
                    this.BackColor = Color.Gray;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
