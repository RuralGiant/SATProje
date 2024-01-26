namespace PersonelVardiyaOtomasyonu
{

	partial class otomasyon
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
            this.baslangic_tarihi = new System.Windows.Forms.Label();
            this.cikis_btn = new System.Windows.Forms.Button();
            this.olustur_btn = new System.Windows.Forms.Button();
            this.bitis_tarihi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vardiya_baslangic_picker = new System.Windows.Forms.DateTimePicker();
            this.vardiya_bitis_picker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // baslangic_tarihi
            // 
            this.baslangic_tarihi.AutoSize = true;
            this.baslangic_tarihi.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslangic_tarihi.ForeColor = System.Drawing.Color.White;
            this.baslangic_tarihi.Location = new System.Drawing.Point(39, 109);
            this.baslangic_tarihi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.baslangic_tarihi.Name = "baslangic_tarihi";
            this.baslangic_tarihi.Size = new System.Drawing.Size(139, 22);
            this.baslangic_tarihi.TabIndex = 1;
            this.baslangic_tarihi.Text = "Başlangıç Tarihi";
            // 
            // cikis_btn
            // 
            this.cikis_btn.BackColor = System.Drawing.Color.SlateGray;
            this.cikis_btn.FlatAppearance.BorderSize = 0;
            this.cikis_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cikis_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cikis_btn.ForeColor = System.Drawing.Color.White;
            this.cikis_btn.Location = new System.Drawing.Point(431, 145);
            this.cikis_btn.Margin = new System.Windows.Forms.Padding(0);
            this.cikis_btn.Name = "cikis_btn";
            this.cikis_btn.Size = new System.Drawing.Size(75, 32);
            this.cikis_btn.TabIndex = 9;
            this.cikis_btn.Text = "Çıkış";
            this.cikis_btn.UseVisualStyleBackColor = false;
            this.cikis_btn.Click += new System.EventHandler(this.ButtonSil_Click);
            // 
            // olustur_btn
            // 
            this.olustur_btn.BackColor = System.Drawing.Color.SlateGray;
            this.olustur_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.olustur_btn.FlatAppearance.BorderSize = 0;
            this.olustur_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.olustur_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.olustur_btn.ForeColor = System.Drawing.Color.White;
            this.olustur_btn.Location = new System.Drawing.Point(431, 89);
            this.olustur_btn.Margin = new System.Windows.Forms.Padding(0);
            this.olustur_btn.Name = "olustur_btn";
            this.olustur_btn.Size = new System.Drawing.Size(75, 32);
            this.olustur_btn.TabIndex = 7;
            this.olustur_btn.Text = "Oluştur";
            this.olustur_btn.UseVisualStyleBackColor = false;
            this.olustur_btn.Click += new System.EventHandler(this.ButtonEkle_Click);
            // 
            // bitis_tarihi
            // 
            this.bitis_tarihi.AutoSize = true;
            this.bitis_tarihi.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bitis_tarihi.ForeColor = System.Drawing.Color.White;
            this.bitis_tarihi.Location = new System.Drawing.Point(73, 160);
            this.bitis_tarihi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bitis_tarihi.Name = "bitis_tarihi";
            this.bitis_tarihi.Size = new System.Drawing.Size(101, 22);
            this.bitis_tarihi.TabIndex = 1;
            this.bitis_tarihi.Text = "Bitiş Tarihi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(118, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vardiya Oluşturma";
            // 
            // vardiya_baslangic_picker
            // 
            this.vardiya_baslangic_picker.Location = new System.Drawing.Point(181, 106);
            this.vardiya_baslangic_picker.Name = "vardiya_baslangic_picker";
            this.vardiya_baslangic_picker.Size = new System.Drawing.Size(200, 20);
            this.vardiya_baslangic_picker.TabIndex = 11;
            // 
            // vardiya_bitis_picker
            // 
            this.vardiya_bitis_picker.Location = new System.Drawing.Point(181, 157);
            this.vardiya_bitis_picker.Name = "vardiya_bitis_picker";
            this.vardiya_bitis_picker.Size = new System.Drawing.Size(200, 20);
            this.vardiya_bitis_picker.TabIndex = 12;
            // 
            // otomasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(535, 250);
            this.Controls.Add(this.vardiya_bitis_picker);
            this.Controls.Add(this.vardiya_baslangic_picker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bitis_tarihi);
            this.Controls.Add(this.baslangic_tarihi);
            this.Controls.Add(this.cikis_btn);
            this.Controls.Add(this.olustur_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "otomasyon";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private System.Windows.Forms.Label baslangic_tarihi;
		private System.Windows.Forms.Button cikis_btn;
		private System.Windows.Forms.Button olustur_btn;
		private System.Windows.Forms.Label bitis_tarihi;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker vardiya_baslangic_picker;
		private System.Windows.Forms.DateTimePicker vardiya_bitis_picker;
	}
}
