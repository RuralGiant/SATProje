namespace PersonelVardiyaOtomasyonu
{
    partial class personel_profil
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
            this.tc_label = new System.Windows.Forms.Label();
            this.tc = new System.Windows.Forms.Label();
            this.sicil_no_label = new System.Windows.Forms.Label();
            this.sicil_no = new System.Windows.Forms.Label();
            this.personel_bilgi_tablosu = new System.Windows.Forms.DataGridView();
            this.btncikis = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.personel_bilgi_tablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // tc_label
            // 
            this.tc_label.AutoSize = true;
            this.tc_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tc_label.ForeColor = System.Drawing.Color.White;
            this.tc_label.Location = new System.Drawing.Point(299, -31);
            this.tc_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tc_label.Name = "tc_label";
            this.tc_label.Size = new System.Drawing.Size(65, 17);
            this.tc_label.TabIndex = 45;
            this.tc_label.Text = "tc_label";
            // 
            // tc
            // 
            this.tc.AutoSize = true;
            this.tc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tc.ForeColor = System.Drawing.Color.White;
            this.tc.Location = new System.Drawing.Point(248, -31);
            this.tc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tc.Name = "tc";
            this.tc.Size = new System.Drawing.Size(38, 17);
            this.tc.TabIndex = 44;
            this.tc.Text = "TC :";
            // 
            // sicil_no_label
            // 
            this.sicil_no_label.AutoSize = true;
            this.sicil_no_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sicil_no_label.ForeColor = System.Drawing.Color.White;
            this.sicil_no_label.Location = new System.Drawing.Point(97, -31);
            this.sicil_no_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sicil_no_label.Name = "sicil_no_label";
            this.sicil_no_label.Size = new System.Drawing.Size(107, 17);
            this.sicil_no_label.TabIndex = 34;
            this.sicil_no_label.Text = "sicil_no_label";
            // 
            // sicil_no
            // 
            this.sicil_no.AutoSize = true;
            this.sicil_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sicil_no.ForeColor = System.Drawing.Color.White;
            this.sicil_no.Location = new System.Drawing.Point(14, -31);
            this.sicil_no.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sicil_no.Name = "sicil_no";
            this.sicil_no.Size = new System.Drawing.Size(78, 17);
            this.sicil_no.TabIndex = 31;
            this.sicil_no.Text = " Sicil No :";
            // 
            // personel_bilgi_tablosu
            // 
            this.personel_bilgi_tablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personel_bilgi_tablosu.Location = new System.Drawing.Point(5, 123);
            this.personel_bilgi_tablosu.Margin = new System.Windows.Forms.Padding(2);
            this.personel_bilgi_tablosu.Name = "personel_bilgi_tablosu";
            this.personel_bilgi_tablosu.RowHeadersWidth = 51;
            this.personel_bilgi_tablosu.RowTemplate.Height = 24;
            this.personel_bilgi_tablosu.Size = new System.Drawing.Size(360, 316);
            this.personel_bilgi_tablosu.TabIndex = 29;
            // 
            // btncikis
            // 
            this.btncikis.BackColor = System.Drawing.Color.DarkGray;
            this.btncikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncikis.FlatAppearance.BorderSize = 0;
            this.btncikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncikis.Font = new System.Drawing.Font("Monotype Corsiva", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btncikis.ForeColor = System.Drawing.Color.White;
            this.btncikis.Location = new System.Drawing.Point(287, 454);
            this.btncikis.Margin = new System.Windows.Forms.Padding(0);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(75, 32);
            this.btncikis.TabIndex = 55;
            this.btncikis.Text = "Çıkış";
            this.btncikis.UseVisualStyleBackColor = false;
            this.btncikis.Click += new System.EventHandler(this.btncikis_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Monotype Corsiva", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 454);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 56;
            this.button1.Text = "Yazdır";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(105, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 27);
            this.label1.TabIndex = 57;
            this.label1.Text = "Vardiya Bilgileri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(5, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(759, 22);
            this.label2.TabIndex = 58;
            this.label2.Text = "{DataBinding!ConnectionMemory:SoliteraxLibrary.SoliteraxConnection:personeller:ad" +
    "&soyad}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(4, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(765, 22);
            this.label3.TabIndex = 59;
            this.label3.Text = "{DataBinding!ConnectionMemory:SoliteraxLibrary.SoliteraxConnection:mesailer:mesai" +
    "_saati}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(95, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 27);
            this.label4.TabIndex = 60;
            this.label4.Text = "Personel Bilgileri";
            // 
            // personel_profil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(371, 495);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btncikis);
            this.Controls.Add(this.tc_label);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.sicil_no_label);
            this.Controls.Add(this.sicil_no);
            this.Controls.Add(this.personel_bilgi_tablosu);
            this.Name = "personel_profil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calisan_Profil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.personel_profil_FormClosed);
            this.Load += new System.EventHandler(this.personel_profil_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.personel_bilgi_tablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tc_label;
        private System.Windows.Forms.Label tc;
        private System.Windows.Forms.Label sicil_no_label;
        private System.Windows.Forms.Label sicil_no;
        private System.Windows.Forms.DataGridView personel_bilgi_tablosu;
        private System.Windows.Forms.Button btncikis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}