namespace PersonelVardiyaOtomasyonu
{

	partial class giris
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
            this.ad = new System.Windows.Forms.Label();
            this.telefon = new System.Windows.Forms.Label();
            this.girissifretxtbox = new System.Windows.Forms.TextBox();
            this.giristxtbox = new System.Windows.Forms.TextBox();
            this.btncikis = new System.Windows.Forms.Button();
            this.btngiris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ad
            // 
            this.ad.AutoSize = true;
            this.ad.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ad.ForeColor = System.Drawing.Color.White;
            this.ad.Location = new System.Drawing.Point(39, 132);
            this.ad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(40, 18);
            this.ad.TabIndex = 1;
            this.ad.Text = "Şifre";
            // 
            // telefon
            // 
            this.telefon.AutoSize = true;
            this.telefon.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.telefon.ForeColor = System.Drawing.Color.White;
            this.telefon.Location = new System.Drawing.Point(39, 84);
            this.telefon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.telefon.Name = "telefon";
            this.telefon.Size = new System.Drawing.Size(39, 18);
            this.telefon.TabIndex = 1;
            this.telefon.Text = "Mail";
            // 
            // girissifretxtbox
            // 
            this.girissifretxtbox.Location = new System.Drawing.Point(105, 129);
            this.girissifretxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.girissifretxtbox.Name = "girissifretxtbox";
            this.girissifretxtbox.PasswordChar = '*';
            this.girissifretxtbox.Size = new System.Drawing.Size(92, 20);
            this.girissifretxtbox.TabIndex = 2;
            // 
            // giristxtbox
            // 
            this.giristxtbox.Location = new System.Drawing.Point(105, 81);
            this.giristxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.giristxtbox.Name = "giristxtbox";
            this.giristxtbox.Size = new System.Drawing.Size(92, 20);
            this.giristxtbox.TabIndex = 1;
            // 
            // btncikis
            // 
            this.btncikis.BackColor = System.Drawing.Color.SlateGray;
            this.btncikis.FlatAppearance.BorderSize = 0;
            this.btncikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncikis.Font = new System.Drawing.Font("Monotype Corsiva", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btncikis.ForeColor = System.Drawing.Color.White;
            this.btncikis.Location = new System.Drawing.Point(105, 229);
            this.btncikis.Margin = new System.Windows.Forms.Padding(0);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(75, 32);
            this.btncikis.TabIndex = 4;
            this.btncikis.Text = "Çıkış";
            this.btncikis.UseVisualStyleBackColor = false;
            this.btncikis.Click += new System.EventHandler(this.cikisbtn);
            // 
            // btngiris
            // 
            this.btngiris.BackColor = System.Drawing.Color.SlateGray;
            this.btngiris.Cursor = System.Windows.Forms.Cursors.Default;
            this.btngiris.FlatAppearance.BorderSize = 0;
            this.btngiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngiris.Font = new System.Drawing.Font("Monotype Corsiva", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngiris.ForeColor = System.Drawing.Color.White;
            this.btngiris.Location = new System.Drawing.Point(105, 177);
            this.btngiris.Margin = new System.Windows.Forms.Padding(0);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(75, 32);
            this.btngiris.TabIndex = 3;
            this.btngiris.Text = "Giriş";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.girisbtn);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(87, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Giriş Yap";
            // 
            // giris
            // 
            this.AcceptButton = this.btngiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(280, 280);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.girissifretxtbox);
            this.Controls.Add(this.ad);
            this.Controls.Add(this.giristxtbox);
            this.Controls.Add(this.telefon);
            this.Controls.Add(this.btncikis);
            this.Controls.Add(this.btngiris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "giris";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private System.Windows.Forms.Label ad;
		private System.Windows.Forms.TextBox girissifretxtbox;
		private System.Windows.Forms.Label telefon;
		private System.Windows.Forms.TextBox giristxtbox;
		private System.Windows.Forms.Button btncikis;
		private System.Windows.Forms.Button btngiris;
		private System.Windows.Forms.Label label1;
	}
}
