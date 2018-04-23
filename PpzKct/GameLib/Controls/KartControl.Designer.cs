namespace PpzKct.GameLib.Controls
{
    partial class KartControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblKartNo = new System.Windows.Forms.Label();
            this.lblKartTipi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKartNo
            // 
            this.lblKartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblKartNo.Location = new System.Drawing.Point(3, 6);
            this.lblKartNo.Name = "lblKartNo";
            this.lblKartNo.Size = new System.Drawing.Size(64, 23);
            this.lblKartNo.TabIndex = 0;
            this.lblKartNo.Text = "-";
            this.lblKartNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKartNo.Click += new System.EventHandler(this.KartControl_Click);
            // 
            // lblKartTipi
            // 
            this.lblKartTipi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblKartTipi.Location = new System.Drawing.Point(3, 29);
            this.lblKartTipi.Name = "lblKartTipi";
            this.lblKartTipi.Size = new System.Drawing.Size(64, 25);
            this.lblKartTipi.TabIndex = 0;
            this.lblKartTipi.Text = "-";
            this.lblKartTipi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKartTipi.Click += new System.EventHandler(this.KartControl_Click);
            // 
            // KartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblKartTipi);
            this.Controls.Add(this.lblKartNo);
            this.Name = "KartControl";
            this.Size = new System.Drawing.Size(70, 60);
            this.Click += new System.EventHandler(this.KartControl_Click);
            this.MouseLeave += new System.EventHandler(this.KartControl_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.KartControl_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblKartNo;
        private System.Windows.Forms.Label lblKartTipi;
    }
}
