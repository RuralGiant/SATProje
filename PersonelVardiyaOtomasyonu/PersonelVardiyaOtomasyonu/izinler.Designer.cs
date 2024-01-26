namespace PersonelVardiyaOtomasyonu
{

	partial class izinler
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.izinler_tablo = new System.Windows.Forms.DataGridView();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.ButtonGuncelle = new System.Windows.Forms.Button();
            this.ButtonSil = new System.Windows.Forms.Button();
            this.izin_baslangic_picker = new System.Windows.Forms.DateTimePicker();
            this.izin_bitis_picker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sicil_lbl = new System.Windows.Forms.Label();
            this.Sicil_cmbbox = new System.Windows.Forms.ComboBox();
            this.ad_lbl = new System.Windows.Forms.Label();
            this.Soyad_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.izinler_tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // izinler_tablo
            // 
            this.izinler_tablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.izinler_tablo.Location = new System.Drawing.Point(3, 202);
            this.izinler_tablo.Margin = new System.Windows.Forms.Padding(2);
            this.izinler_tablo.Name = "izinler_tablo";
            this.izinler_tablo.RowHeadersWidth = 51;
            this.izinler_tablo.RowTemplate.Height = 24;
            this.izinler_tablo.Size = new System.Drawing.Size(616, 176);
            this.izinler_tablo.TabIndex = 0;
            this.izinler_tablo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.izinlerDataTable_CellContentClick);
            // 
            // btn_ekle
            // 
            this.btn_ekle.BackColor = System.Drawing.Color.SlateGray;
            this.btn_ekle.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_ekle.FlatAppearance.BorderSize = 0;
            this.btn_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ekle.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ekle.ForeColor = System.Drawing.Color.White;
            this.btn_ekle.Location = new System.Drawing.Point(539, 115);
            this.btn_ekle.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(80, 32);
            this.btn_ekle.TabIndex = 7;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = false;
            this.btn_ekle.Click += new System.EventHandler(this.ButtonEkle_Click);
            // 
            // ButtonGuncelle
            // 
            this.ButtonGuncelle.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonGuncelle.FlatAppearance.BorderSize = 0;
            this.ButtonGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGuncelle.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonGuncelle.ForeColor = System.Drawing.Color.White;
            this.ButtonGuncelle.Location = new System.Drawing.Point(539, 71);
            this.ButtonGuncelle.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonGuncelle.Name = "ButtonGuncelle";
            this.ButtonGuncelle.Size = new System.Drawing.Size(80, 32);
            this.ButtonGuncelle.TabIndex = 8;
            this.ButtonGuncelle.Text = "Güncelle";
            this.ButtonGuncelle.UseVisualStyleBackColor = false;
            this.ButtonGuncelle.Click += new System.EventHandler(this.ButtonGuncelle_Click);
            // 
            // ButtonSil
            // 
            this.ButtonSil.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonSil.FlatAppearance.BorderSize = 0;
            this.ButtonSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSil.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonSil.ForeColor = System.Drawing.Color.White;
            this.ButtonSil.Location = new System.Drawing.Point(539, 163);
            this.ButtonSil.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonSil.Name = "ButtonSil";
            this.ButtonSil.Size = new System.Drawing.Size(80, 32);
            this.ButtonSil.TabIndex = 9;
            this.ButtonSil.Text = "Sil";
            this.ButtonSil.UseVisualStyleBackColor = false;
            this.ButtonSil.Click += new System.EventHandler(this.ButtonSil_Click);
            // 
            // izin_baslangic_picker
            // 
            this.izin_baslangic_picker.Location = new System.Drawing.Point(203, 83);
            this.izin_baslangic_picker.Margin = new System.Windows.Forms.Padding(2);
            this.izin_baslangic_picker.Name = "izin_baslangic_picker";
            this.izin_baslangic_picker.Size = new System.Drawing.Size(151, 20);
            this.izin_baslangic_picker.TabIndex = 13;
            // 
            // izin_bitis_picker
            // 
            this.izin_bitis_picker.Location = new System.Drawing.Point(203, 119);
            this.izin_bitis_picker.Margin = new System.Windows.Forms.Padding(2);
            this.izin_bitis_picker.Name = "izin_bitis_picker";
            this.izin_bitis_picker.Size = new System.Drawing.Size(151, 20);
            this.izin_bitis_picker.TabIndex = 16;
            this.izin_bitis_picker.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "İzin Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(53, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "İzin Bitiş Tarihi";
            this.label4.Visible = false;
            // 
            // sicil_lbl
            // 
            this.sicil_lbl.AutoSize = true;
            this.sicil_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sicil_lbl.ForeColor = System.Drawing.Color.White;
            this.sicil_lbl.Location = new System.Drawing.Point(7, 12);
            this.sicil_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sicil_lbl.Name = "sicil_lbl";
            this.sicil_lbl.Size = new System.Drawing.Size(165, 18);
            this.sicil_lbl.TabIndex = 1;
            this.sicil_lbl.Text = "Personel Sicil Numarası";
            // 
            // Sicil_cmbbox
            // 
            this.Sicil_cmbbox.FormattingEnabled = true;
            this.Sicil_cmbbox.Location = new System.Drawing.Point(203, 12);
            this.Sicil_cmbbox.Name = "Sicil_cmbbox";
            this.Sicil_cmbbox.Size = new System.Drawing.Size(151, 21);
            this.Sicil_cmbbox.TabIndex = 19;
            // 
            // ad_lbl
            // 
            this.ad_lbl.AutoSize = true;
            this.ad_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(150)))));
            this.ad_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ad_lbl.ForeColor = System.Drawing.Color.White;
            this.ad_lbl.Location = new System.Drawing.Point(424, 12);
            this.ad_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ad_lbl.Name = "ad_lbl";
            this.ad_lbl.Size = new System.Drawing.Size(77, 22);
            this.ad_lbl.TabIndex = 38;
            this.ad_lbl.Text = "ad_label";
            this.ad_lbl.Visible = false;
            // 
            // Soyad_lbl
            // 
            this.Soyad_lbl.AutoSize = true;
            this.Soyad_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(150)))));
            this.Soyad_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Soyad_lbl.ForeColor = System.Drawing.Color.White;
            this.Soyad_lbl.Location = new System.Drawing.Point(448, 49);
            this.Soyad_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Soyad_lbl.Name = "Soyad_lbl";
            this.Soyad_lbl.Size = new System.Drawing.Size(56, 22);
            this.Soyad_lbl.TabIndex = 39;
            this.Soyad_lbl.Text = "Soyad";
            this.Soyad_lbl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(150)))));
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(381, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "Soyad :";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(150)))));
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(377, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 22);
            this.label2.TabIndex = 41;
            this.label2.Text = "Ad :";
            this.label2.Visible = false;
            // 
            // izinler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Soyad_lbl);
            this.Controls.Add(this.ad_lbl);
            this.Controls.Add(this.Sicil_cmbbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.izin_bitis_picker);
            this.Controls.Add(this.izin_baslangic_picker);
            this.Controls.Add(this.sicil_lbl);
            this.Controls.Add(this.ButtonSil);
            this.Controls.Add(this.ButtonGuncelle);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.izinler_tablo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "izinler";
            this.ShowIcon = false;
            this.Text = "Personel";
            ((System.ComponentModel.ISupportInitialize)(this.izinler_tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.DataGridView izinler_tablo;
		private System.Windows.Forms.Button btn_ekle;
		private System.Windows.Forms.Button ButtonGuncelle;
		private System.Windows.Forms.Button ButtonSil;
		private System.Windows.Forms.DateTimePicker izin_baslangic_picker;
		private System.Windows.Forms.DateTimePicker izin_bitis_picker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sicil_lbl;
        private System.Windows.Forms.ComboBox Sicil_cmbbox;
        private System.Windows.Forms.Label ad_lbl;
        private System.Windows.Forms.Label Soyad_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
