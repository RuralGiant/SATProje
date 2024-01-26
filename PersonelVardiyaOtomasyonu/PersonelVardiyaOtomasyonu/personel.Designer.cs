namespace PersonelVardiyaOtomasyonu
{

    partial class personel
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
            this.personel_tablo = new System.Windows.Forms.DataGridView();
            this.kadro_tipi = new System.Windows.Forms.Label();
            this.ekle_btn = new System.Windows.Forms.Button();
            this.guncelle_btn = new System.Windows.Forms.Button();
            this.sil_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.izin_gun_2cmbbox = new SoliteraxControlLibrary.CustomComboBox();
            this.izin_gun_1cmbbox = new SoliteraxControlLibrary.CustomComboBox();
            this.kadro_tur_cmbbox = new SoliteraxControlLibrary.CustomComboBox();
            this.sicil_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            this.unvan_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            this.ad_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            this.soyad_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            this.TC_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            this.tel_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            this.mail_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            this.sifre_txtbox = new SoliteraxControlLibrary.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.personel_tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // personel_tablo
            // 
            this.personel_tablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personel_tablo.Location = new System.Drawing.Point(7, 144);
            this.personel_tablo.Margin = new System.Windows.Forms.Padding(2);
            this.personel_tablo.Name = "personel_tablo";
            this.personel_tablo.RowHeadersWidth = 51;
            this.personel_tablo.RowTemplate.Height = 24;
            this.personel_tablo.Size = new System.Drawing.Size(782, 236);
            this.personel_tablo.TabIndex = 0;
            this.personel_tablo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.personel_tablo_CellContentClick);
            // 
            // kadro_tipi
            // 
            this.kadro_tipi.AutoSize = true;
            this.kadro_tipi.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kadro_tipi.ForeColor = System.Drawing.Color.White;
            this.kadro_tipi.Location = new System.Drawing.Point(489, 16);
            this.kadro_tipi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.kadro_tipi.Name = "kadro_tipi";
            this.kadro_tipi.Size = new System.Drawing.Size(81, 18);
            this.kadro_tipi.TabIndex = 1;
            this.kadro_tipi.Text = "Kadro Tipi";
            // 
            // ekle_btn
            // 
            this.ekle_btn.BackColor = System.Drawing.Color.SlateGray;
            this.ekle_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ekle_btn.FlatAppearance.BorderSize = 0;
            this.ekle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ekle_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ekle_btn.ForeColor = System.Drawing.Color.White;
            this.ekle_btn.Location = new System.Drawing.Point(188, 399);
            this.ekle_btn.Margin = new System.Windows.Forms.Padding(0);
            this.ekle_btn.Name = "ekle_btn";
            this.ekle_btn.Size = new System.Drawing.Size(75, 32);
            this.ekle_btn.TabIndex = 7;
            this.ekle_btn.Text = "Ekle";
            this.ekle_btn.UseVisualStyleBackColor = false;
            this.ekle_btn.Click += new System.EventHandler(this.ButtonEkle_Click);
            // 
            // guncelle_btn
            // 
            this.guncelle_btn.BackColor = System.Drawing.Color.SlateGray;
            this.guncelle_btn.FlatAppearance.BorderSize = 0;
            this.guncelle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guncelle_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guncelle_btn.ForeColor = System.Drawing.Color.White;
            this.guncelle_btn.Location = new System.Drawing.Point(278, 399);
            this.guncelle_btn.Margin = new System.Windows.Forms.Padding(0);
            this.guncelle_btn.Name = "guncelle_btn";
            this.guncelle_btn.Size = new System.Drawing.Size(86, 32);
            this.guncelle_btn.TabIndex = 8;
            this.guncelle_btn.Text = "Güncelle";
            this.guncelle_btn.UseVisualStyleBackColor = false;
            this.guncelle_btn.Click += new System.EventHandler(this.ButtonGuncelle_Click);
            // 
            // sil_btn
            // 
            this.sil_btn.BackColor = System.Drawing.Color.SlateGray;
            this.sil_btn.FlatAppearance.BorderSize = 0;
            this.sil_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sil_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sil_btn.ForeColor = System.Drawing.Color.White;
            this.sil_btn.Location = new System.Drawing.Point(379, 399);
            this.sil_btn.Margin = new System.Windows.Forms.Padding(0);
            this.sil_btn.Name = "sil_btn";
            this.sil_btn.Size = new System.Drawing.Size(75, 32);
            this.sil_btn.TabIndex = 9;
            this.sil_btn.Text = "Sil";
            this.sil_btn.UseVisualStyleBackColor = false;
            this.sil_btn.Click += new System.EventHandler(this.ButtonSil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(489, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "1. İzin Günü";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(489, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "2. İzin Günü";
            this.label2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(469, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 17;
            this.button1.Text = "Çıktı";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // izin_gun_2cmbbox
            // 
            this.izin_gun_2cmbbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.izin_gun_2cmbbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.izin_gun_2cmbbox.BorderSize = 1;
            this.izin_gun_2cmbbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.izin_gun_2cmbbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.izin_gun_2cmbbox.ForeColor = System.Drawing.Color.DimGray;
            this.izin_gun_2cmbbox.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.izin_gun_2cmbbox.Items.AddRange(new object[] {
            "Pazartesi",
            "Salı",
            "Çarşamba",
            "Perşembe",
            "Cuma",
            "Cumartesi",
            "Pazar"});
            this.izin_gun_2cmbbox.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.izin_gun_2cmbbox.ListTextColor = System.Drawing.Color.DimGray;
            this.izin_gun_2cmbbox.Location = new System.Drawing.Point(589, 109);
            this.izin_gun_2cmbbox.Margin = new System.Windows.Forms.Padding(2);
            this.izin_gun_2cmbbox.MinimumSize = new System.Drawing.Size(200, 30);
            this.izin_gun_2cmbbox.Name = "izin_gun_2cmbbox";
            this.izin_gun_2cmbbox.Padding = new System.Windows.Forms.Padding(1);
            this.izin_gun_2cmbbox.PlaceHolderColor = System.Drawing.Color.Empty;
            this.izin_gun_2cmbbox.PlaceHolderText = null;
            this.izin_gun_2cmbbox.Size = new System.Drawing.Size(200, 30);
            this.izin_gun_2cmbbox.TabIndex = 15;
            this.izin_gun_2cmbbox.Visible = false;
            // 
            // izin_gun_1cmbbox
            // 
            this.izin_gun_1cmbbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.izin_gun_1cmbbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.izin_gun_1cmbbox.BorderSize = 1;
            this.izin_gun_1cmbbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.izin_gun_1cmbbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.izin_gun_1cmbbox.ForeColor = System.Drawing.Color.DimGray;
            this.izin_gun_1cmbbox.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.izin_gun_1cmbbox.Items.AddRange(new object[] {
            "Pazartesi",
            "Salı",
            "Çarşamba",
            "Perşembe",
            "Cuma",
            "Cumartesi",
            "Pazar"});
            this.izin_gun_1cmbbox.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.izin_gun_1cmbbox.ListTextColor = System.Drawing.Color.DimGray;
            this.izin_gun_1cmbbox.Location = new System.Drawing.Point(589, 80);
            this.izin_gun_1cmbbox.Margin = new System.Windows.Forms.Padding(2);
            this.izin_gun_1cmbbox.MinimumSize = new System.Drawing.Size(200, 30);
            this.izin_gun_1cmbbox.Name = "izin_gun_1cmbbox";
            this.izin_gun_1cmbbox.Padding = new System.Windows.Forms.Padding(1);
            this.izin_gun_1cmbbox.PlaceHolderColor = System.Drawing.Color.Empty;
            this.izin_gun_1cmbbox.PlaceHolderText = null;
            this.izin_gun_1cmbbox.Size = new System.Drawing.Size(200, 30);
            this.izin_gun_1cmbbox.TabIndex = 14;
            this.izin_gun_1cmbbox.Visible = false;
            // 
            // kadro_tur_cmbbox
            // 
            this.kadro_tur_cmbbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kadro_tur_cmbbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.kadro_tur_cmbbox.BorderSize = 1;
            this.kadro_tur_cmbbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.kadro_tur_cmbbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.kadro_tur_cmbbox.ForeColor = System.Drawing.Color.DimGray;
            this.kadro_tur_cmbbox.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.kadro_tur_cmbbox.Items.AddRange(new object[] {
            "İşçi",
            "Memur",
            "Yönetici"});
            this.kadro_tur_cmbbox.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.kadro_tur_cmbbox.ListTextColor = System.Drawing.Color.DimGray;
            this.kadro_tur_cmbbox.Location = new System.Drawing.Point(589, 14);
            this.kadro_tur_cmbbox.MinimumSize = new System.Drawing.Size(200, 30);
            this.kadro_tur_cmbbox.Name = "kadro_tur_cmbbox";
            this.kadro_tur_cmbbox.Padding = new System.Windows.Forms.Padding(1);
            this.kadro_tur_cmbbox.PlaceHolderColor = System.Drawing.Color.Black;
            this.kadro_tur_cmbbox.PlaceHolderText = "Kadro Tipi";
            this.kadro_tur_cmbbox.Size = new System.Drawing.Size(200, 30);
            this.kadro_tur_cmbbox.TabIndex = 11;
            // 
            // sicil_txtbox
            // 
            this.sicil_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.sicil_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.sicil_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.sicil_txtbox.BorderRadius = 0;
            this.sicil_txtbox.BorderSize = 2;
            this.sicil_txtbox.CausesValidation = false;
            this.sicil_txtbox.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.sicil_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sicil_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sicil_txtbox.LeftImage = null;
            this.sicil_txtbox.Location = new System.Drawing.Point(36, 14);
            this.sicil_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.sicil_txtbox.Multiline = false;
            this.sicil_txtbox.Name = "sicil_txtbox";
            this.sicil_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.sicil_txtbox.PasswordChar = false;
            this.sicil_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.sicil_txtbox.PlaceholderText = "Sicil No";
            this.sicil_txtbox.RightImage = null;
            this.sicil_txtbox.Size = new System.Drawing.Size(210, 31);
            this.sicil_txtbox.TabIndex = 4;
            this.sicil_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.sicil_txtbox.UnderlinedStyle = false;
            // 
            // unvan_txtbox
            // 
            this.unvan_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.unvan_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.unvan_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.unvan_txtbox.BorderRadius = 0;
            this.unvan_txtbox.BorderSize = 2;
            this.unvan_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unvan_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.unvan_txtbox.LeftImage = null;
            this.unvan_txtbox.Location = new System.Drawing.Point(589, 45);
            this.unvan_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.unvan_txtbox.Multiline = false;
            this.unvan_txtbox.Name = "unvan_txtbox";
            this.unvan_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.unvan_txtbox.PasswordChar = false;
            this.unvan_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.unvan_txtbox.PlaceholderText = "Görev Ünvanı";
            this.unvan_txtbox.RightImage = null;
            this.unvan_txtbox.Size = new System.Drawing.Size(200, 31);
            this.unvan_txtbox.TabIndex = 4;
            this.unvan_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.unvan_txtbox.UnderlinedStyle = false;
            // 
            // ad_txtbox
            // 
            this.ad_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.ad_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.ad_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.ad_txtbox.BorderRadius = 0;
            this.ad_txtbox.BorderSize = 2;
            this.ad_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ad_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ad_txtbox.LeftImage = null;
            this.ad_txtbox.Location = new System.Drawing.Point(36, 46);
            this.ad_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.ad_txtbox.Multiline = false;
            this.ad_txtbox.Name = "ad_txtbox";
            this.ad_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.ad_txtbox.PasswordChar = false;
            this.ad_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ad_txtbox.PlaceholderText = "Ad";
            this.ad_txtbox.RightImage = null;
            this.ad_txtbox.Size = new System.Drawing.Size(210, 31);
            this.ad_txtbox.TabIndex = 4;
            this.ad_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ad_txtbox.UnderlinedStyle = false;
            // 
            // soyad_txtbox
            // 
            this.soyad_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.soyad_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.soyad_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.soyad_txtbox.BorderRadius = 0;
            this.soyad_txtbox.BorderSize = 2;
            this.soyad_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soyad_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.soyad_txtbox.LeftImage = null;
            this.soyad_txtbox.Location = new System.Drawing.Point(278, 46);
            this.soyad_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.soyad_txtbox.Multiline = false;
            this.soyad_txtbox.Name = "soyad_txtbox";
            this.soyad_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.soyad_txtbox.PasswordChar = false;
            this.soyad_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.soyad_txtbox.PlaceholderText = "Soyad";
            this.soyad_txtbox.RightImage = null;
            this.soyad_txtbox.Size = new System.Drawing.Size(200, 31);
            this.soyad_txtbox.TabIndex = 4;
            this.soyad_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.soyad_txtbox.UnderlinedStyle = false;
            // 
            // TC_txtbox
            // 
            this.TC_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.TC_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.TC_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TC_txtbox.BorderRadius = 0;
            this.TC_txtbox.BorderSize = 2;
            this.TC_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TC_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TC_txtbox.LeftImage = null;
            this.TC_txtbox.Location = new System.Drawing.Point(278, 16);
            this.TC_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.TC_txtbox.Multiline = false;
            this.TC_txtbox.Name = "TC_txtbox";
            this.TC_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TC_txtbox.PasswordChar = false;
            this.TC_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TC_txtbox.PlaceholderText = "Kimlik No";
            this.TC_txtbox.RightImage = null;
            this.TC_txtbox.Size = new System.Drawing.Size(200, 31);
            this.TC_txtbox.TabIndex = 4;
            this.TC_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TC_txtbox.UnderlinedStyle = false;
            // 
            // tel_txtbox
            // 
            this.tel_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.tel_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tel_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tel_txtbox.BorderRadius = 0;
            this.tel_txtbox.BorderSize = 2;
            this.tel_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tel_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tel_txtbox.LeftImage = null;
            this.tel_txtbox.Location = new System.Drawing.Point(36, 107);
            this.tel_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.tel_txtbox.Multiline = false;
            this.tel_txtbox.Name = "tel_txtbox";
            this.tel_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tel_txtbox.PasswordChar = false;
            this.tel_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tel_txtbox.PlaceholderText = "Telefon";
            this.tel_txtbox.RightImage = null;
            this.tel_txtbox.Size = new System.Drawing.Size(210, 31);
            this.tel_txtbox.TabIndex = 4;
            this.tel_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tel_txtbox.UnderlinedStyle = false;
            // 
            // mail_txtbox
            // 
            this.mail_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.mail_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.mail_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mail_txtbox.BorderRadius = 0;
            this.mail_txtbox.BorderSize = 2;
            this.mail_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mail_txtbox.LeftImage = null;
            this.mail_txtbox.Location = new System.Drawing.Point(36, 78);
            this.mail_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.mail_txtbox.Multiline = false;
            this.mail_txtbox.Name = "mail_txtbox";
            this.mail_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.mail_txtbox.PasswordChar = false;
            this.mail_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.mail_txtbox.PlaceholderText = "Mail";
            this.mail_txtbox.RightImage = null;
            this.mail_txtbox.Size = new System.Drawing.Size(210, 31);
            this.mail_txtbox.TabIndex = 4;
            this.mail_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mail_txtbox.UnderlinedStyle = false;
            // 
            // sifre_txtbox
            // 
            this.sifre_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.sifre_txtbox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.sifre_txtbox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.sifre_txtbox.BorderRadius = 0;
            this.sifre_txtbox.BorderSize = 2;
            this.sifre_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sifre_txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sifre_txtbox.LeftImage = null;
            this.sifre_txtbox.Location = new System.Drawing.Point(278, 78);
            this.sifre_txtbox.Margin = new System.Windows.Forms.Padding(2);
            this.sifre_txtbox.Multiline = false;
            this.sifre_txtbox.Name = "sifre_txtbox";
            this.sifre_txtbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.sifre_txtbox.PasswordChar = false;
            this.sifre_txtbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.sifre_txtbox.PlaceholderText = "Şifre";
            this.sifre_txtbox.RightImage = null;
            this.sifre_txtbox.Size = new System.Drawing.Size(200, 31);
            this.sifre_txtbox.TabIndex = 4;
            this.sifre_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.sifre_txtbox.UnderlinedStyle = false;
            // 
            // personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.izin_gun_2cmbbox);
            this.Controls.Add(this.izin_gun_1cmbbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kadro_tur_cmbbox);
            this.Controls.Add(this.sicil_txtbox);
            this.Controls.Add(this.kadro_tipi);
            this.Controls.Add(this.unvan_txtbox);
            this.Controls.Add(this.ad_txtbox);
            this.Controls.Add(this.soyad_txtbox);
            this.Controls.Add(this.TC_txtbox);
            this.Controls.Add(this.tel_txtbox);
            this.Controls.Add(this.mail_txtbox);
            this.Controls.Add(this.sifre_txtbox);
            this.Controls.Add(this.personel_tablo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sil_btn);
            this.Controls.Add(this.guncelle_btn);
            this.Controls.Add(this.ekle_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "personel";
            this.ShowIcon = false;
            this.Text = "Personel";
            ((System.ComponentModel.ISupportInitialize)(this.personel_tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView personel_tablo;
        private System.Windows.Forms.Label kadro_tipi;
        private SoliteraxControlLibrary.CustomTextBox unvan_txtbox;
        private SoliteraxControlLibrary.CustomTextBox ad_txtbox;
        private SoliteraxControlLibrary.CustomTextBox soyad_txtbox;
        private SoliteraxControlLibrary.CustomTextBox TC_txtbox;
        private SoliteraxControlLibrary.CustomTextBox tel_txtbox;
        private SoliteraxControlLibrary.CustomTextBox mail_txtbox;
        private SoliteraxControlLibrary.CustomTextBox sifre_txtbox;
        private System.Windows.Forms.Button ekle_btn;
        private System.Windows.Forms.Button guncelle_btn;
        private System.Windows.Forms.Button sil_btn;
        private SoliteraxControlLibrary.CustomTextBox sicil_txtbox;
        private SoliteraxControlLibrary.CustomComboBox kadro_tur_cmbbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SoliteraxControlLibrary.CustomComboBox izin_gun_1cmbbox;
        private SoliteraxControlLibrary.CustomComboBox izin_gun_2cmbbox;
        private System.Windows.Forms.Button button1;
    }
}
