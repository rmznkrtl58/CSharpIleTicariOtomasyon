namespace R_Ticari_Otomasyon
{
    partial class frmmail
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmail));
            this.label1 = new System.Windows.Forms.Label();
            this.txtmailadresi = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkonu = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmesaj = new System.Windows.Forms.RichTextBox();
            this.btngönder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtmailadresi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkonu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngönder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(62, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail Adresi:";
            // 
            // txtmailadresi
            // 
            this.txtmailadresi.Location = new System.Drawing.Point(175, 161);
            this.txtmailadresi.Name = "txtmailadresi";
            this.txtmailadresi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtmailadresi.Properties.Appearance.Options.UseFont = true;
            this.txtmailadresi.Size = new System.Drawing.Size(187, 26);
            this.txtmailadresi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(109, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Konu:";
            // 
            // txtkonu
            // 
            this.txtkonu.Location = new System.Drawing.Point(175, 199);
            this.txtkonu.Name = "txtkonu";
            this.txtkonu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkonu.Properties.Appearance.Options.UseFont = true;
            this.txtkonu.Size = new System.Drawing.Size(187, 26);
            this.txtkonu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(106, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "İçerik:";
            // 
            // txtmesaj
            // 
            this.txtmesaj.Location = new System.Drawing.Point(175, 241);
            this.txtmesaj.Name = "txtmesaj";
            this.txtmesaj.Size = new System.Drawing.Size(291, 195);
            this.txtmesaj.TabIndex = 5;
            this.txtmesaj.Text = "";
            // 
            // btngönder
            // 
            this.btngönder.BackColor = System.Drawing.Color.Transparent;
            this.btngönder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btngönder.Image = ((System.Drawing.Image)(resources.GetObject("btngönder.Image")));
            this.btngönder.Location = new System.Drawing.Point(261, 442);
            this.btngönder.Name = "btngönder";
            this.btngönder.Size = new System.Drawing.Size(101, 73);
            this.btngönder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btngönder.TabIndex = 6;
            this.btngönder.TabStop = false;
            this.btngönder.Click += new System.EventHandler(this.btngönder_Click);
            // 
            // frmmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(682, 567);
            this.Controls.Add(this.btngönder);
            this.Controls.Add(this.txtmesaj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtkonu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmailadresi);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmmail";
            this.Load += new System.EventHandler(this.frmmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtmailadresi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkonu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngönder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtmailadresi;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtkonu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtmesaj;
        private System.Windows.Forms.PictureBox btngönder;
    }
}