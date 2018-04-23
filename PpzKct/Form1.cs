using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PpzKct.GameLib;

namespace PpzKct
{
    public partial class Form1 : Form
    {
        Oyun oyun = new Oyun();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni oyun baslatiliyor bol sans");
            oyun.YeniOyunBaslat(
                pnl1Open,pnl1Close,
                pnl2Open, pnl2Close,
                pnl3Open, pnl3Close,
                pnl4Open,pnl4Close);   
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
