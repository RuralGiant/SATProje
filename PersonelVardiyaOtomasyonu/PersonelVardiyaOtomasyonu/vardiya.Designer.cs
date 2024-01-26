namespace PersonelVardiyaOtomasyonu
{

	partial class vardiya
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
            this.vardiya_tablosu = new System.Windows.Forms.DataGridView();
            this.sicil_no = new System.Windows.Forms.Label();
            this.ad = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.ButtonEkle = new System.Windows.Forms.Button();
            this.ButtonGuncelle = new System.Windows.Forms.Button();
            this.ButtonSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Bolge_cmbbox = new System.Windows.Forms.ComboBox();
            this.otomasyon_button = new System.Windows.Forms.Button();
            this.gun_picker = new System.Windows.Forms.DateTimePicker();
            this.sicil_cmbbox = new System.Windows.Forms.ComboBox();
            this.vardiya_cmbbox = new System.Windows.Forms.ComboBox();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vardiya_tablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // vardiya_tablosu
            // 
            this.vardiya_tablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vardiya_tablosu.Location = new System.Drawing.Point(11, 195);
            this.vardiya_tablosu.Margin = new System.Windows.Forms.Padding(2);
            this.vardiya_tablosu.Name = "vardiya_tablosu";
            this.vardiya_tablosu.RowHeadersWidth = 51;
            this.vardiya_tablosu.RowTemplate.Height = 24;
            this.vardiya_tablosu.Size = new System.Drawing.Size(782, 236);
            this.vardiya_tablosu.TabIndex = 0;
            this.vardiya_tablosu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vardiyaDataTable_CellContentClick);
            // 
            // sicil_no
            // 
            this.sicil_no.AutoSize = true;
            this.sicil_no.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sicil_no.ForeColor = System.Drawing.Color.White;
            this.sicil_no.Location = new System.Drawing.Point(13, 70);
            this.sicil_no.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sicil_no.Name = "sicil_no";
            this.sicil_no.Size = new System.Drawing.Size(145, 22);
            this.sicil_no.TabIndex = 1;
            this.sicil_no.Text = "Personel Sicil No";
            // 
            // ad
            // 
            this.ad.AutoSize = true;
            this.ad.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ad.ForeColor = System.Drawing.Color.White;
            this.ad.Location = new System.Drawing.Point(37, 148);
            this.ad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(72, 22);
            this.ad.TabIndex = 1;
            this.ad.Text = "Vardiya";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.email.ForeColor = System.Drawing.Color.White;
            this.email.Location = new System.Drawing.Point(51, 109);
            this.email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(104, 22);
            this.email.TabIndex = 1;
            this.email.Text = "Görev Günü";
            // 
            // ButtonEkle
            // 
            this.ButtonEkle.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonEkle.Cursor = System.Windows.Forms.Cursors.Default;
            this.ButtonEkle.FlatAppearance.BorderSize = 0;
            this.ButtonEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEkle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonEkle.ForeColor = System.Drawing.Color.White;
            this.ButtonEkle.Location = new System.Drawing.Point(374, 159);
            this.ButtonEkle.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonEkle.Name = "ButtonEkle";
            this.ButtonEkle.Size = new System.Drawing.Size(75, 32);
            this.ButtonEkle.TabIndex = 7;
            this.ButtonEkle.Text = "Ekle";
            this.ButtonEkle.UseVisualStyleBackColor = false;
            this.ButtonEkle.Click += new System.EventHandler(this.ButtonEkle_Click);
            // 
            // ButtonGuncelle
            // 
            this.ButtonGuncelle.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonGuncelle.FlatAppearance.BorderSize = 0;
            this.ButtonGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGuncelle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonGuncelle.ForeColor = System.Drawing.Color.White;
            this.ButtonGuncelle.Location = new System.Drawing.Point(460, 159);
            this.ButtonGuncelle.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonGuncelle.Name = "ButtonGuncelle";
            this.ButtonGuncelle.Size = new System.Drawing.Size(81, 32);
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
            this.ButtonSil.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonSil.ForeColor = System.Drawing.Color.White;
            this.ButtonSil.Location = new System.Drawing.Point(557, 159);
            this.ButtonSil.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonSil.Name = "ButtonSil";
            this.ButtonSil.Size = new System.Drawing.Size(75, 32);
            this.ButtonSil.TabIndex = 9;
            this.ButtonSil.Text = "Sil";
            this.ButtonSil.UseVisualStyleBackColor = false;
            this.ButtonSil.Click += new System.EventHandler(this.ButtonSil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Görev Bölgesi";
            // 
            // Bolge_cmbbox
            // 
            this.Bolge_cmbbox.FormattingEnabled = true;
            this.Bolge_cmbbox.Items.AddRange(new object[] {
            "Kampüs İçi",
            "Kampüs Dışı"});
            this.Bolge_cmbbox.Location = new System.Drawing.Point(163, 39);
            this.Bolge_cmbbox.Name = "Bolge_cmbbox";
            this.Bolge_cmbbox.Size = new System.Drawing.Size(121, 21);
            this.Bolge_cmbbox.TabIndex = 13;
            // 
            // otomasyon_button
            // 
            this.otomasyon_button.BackColor = System.Drawing.Color.SlateGray;
            this.otomasyon_button.FlatAppearance.BorderSize = 0;
            this.otomasyon_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otomasyon_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.otomasyon_button.ForeColor = System.Drawing.Color.White;
            this.otomasyon_button.Location = new System.Drawing.Point(70, 452);
            this.otomasyon_button.Margin = new System.Windows.Forms.Padding(2);
            this.otomasyon_button.Name = "otomasyon_button";
            this.otomasyon_button.Size = new System.Drawing.Size(144, 32);
            this.otomasyon_button.TabIndex = 14;
            this.otomasyon_button.Text = "Vardiya Oluştur";
            this.otomasyon_button.UseVisualStyleBackColor = false;
            this.otomasyon_button.Click += new System.EventHandler(this.otomasyon_button_Click);
            // 
            // gun_picker
            // 
            this.gun_picker.Location = new System.Drawing.Point(160, 109);
            this.gun_picker.Name = "gun_picker";
            this.gun_picker.Size = new System.Drawing.Size(170, 20);
            this.gun_picker.TabIndex = 15;
            // 
            // sicil_cmbbox
            // 
            this.sicil_cmbbox.FormattingEnabled = true;
            this.sicil_cmbbox.Location = new System.Drawing.Point(163, 73);
            this.sicil_cmbbox.Name = "sicil_cmbbox";
            this.sicil_cmbbox.Size = new System.Drawing.Size(167, 21);
            this.sicil_cmbbox.TabIndex = 16;
            // 
            // vardiya_cmbbox
            // 
            this.vardiya_cmbbox.FormattingEnabled = true;
            this.vardiya_cmbbox.Location = new System.Drawing.Point(163, 148);
            this.vardiya_cmbbox.Name = "vardiya_cmbbox";
            this.vardiya_cmbbox.Size = new System.Drawing.Size(167, 21);
            this.vardiya_cmbbox.TabIndex = 17;
            // 
            // refresh_btn
            // 
            this.refresh_btn.BackColor = System.Drawing.Color.SlateGray;
            this.refresh_btn.FlatAppearance.BorderSize = 0;
            this.refresh_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refresh_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.refresh_btn.ForeColor = System.Drawing.Color.White;
            this.refresh_btn.Location = new System.Drawing.Point(726, 159);
            this.refresh_btn.Margin = new System.Windows.Forms.Padding(2);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(63, 32);
            this.refresh_btn.TabIndex = 18;
            this.refresh_btn.Text = "Yenile";
            this.refresh_btn.UseVisualStyleBackColor = false;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(638, 159);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 19;
            this.button1.Text = "Yazdır";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SlateGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(230, 452);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 32);
            this.button2.TabIndex = 20;
            this.button2.Text = "Vardiya Temizle";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // vardiya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.vardiya_cmbbox);
            this.Controls.Add(this.sicil_cmbbox);
            this.Controls.Add(this.gun_picker);
            this.Controls.Add(this.otomasyon_button);
            this.Controls.Add(this.Bolge_cmbbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sicil_no);
            this.Controls.Add(this.ad);
            this.Controls.Add(this.email);
            this.Controls.Add(this.ButtonSil);
            this.Controls.Add(this.ButtonGuncelle);
            this.Controls.Add(this.ButtonEkle);
            this.Controls.Add(this.vardiya_tablosu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "vardiya";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel";
            ((System.ComponentModel.ISupportInitialize)(this.vardiya_tablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.DataGridView vardiya_tablosu;
		private System.Windows.Forms.Label sicil_no;
		private System.Windows.Forms.Label ad;
		private System.Windows.Forms.Label email;
		private System.Windows.Forms.Button ButtonEkle;
		private System.Windows.Forms.Button ButtonGuncelle;
		private System.Windows.Forms.Button ButtonSil;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox Bolge_cmbbox;
		private System.Windows.Forms.Button otomasyon_button;
        private System.Windows.Forms.DateTimePicker gun_picker;
        private System.Windows.Forms.ComboBox sicil_cmbbox;
        private System.Windows.Forms.ComboBox vardiya_cmbbox;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
