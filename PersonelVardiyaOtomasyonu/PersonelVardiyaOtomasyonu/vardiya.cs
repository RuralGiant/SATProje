using PersonelVardiyaOtomasyonu.Tablolar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using System.ComponentModel.Design;

namespace PersonelVardiyaOtomasyonu
{
    //çıktı kütüphanesi
    using Excel = Microsoft.Office.Interop.Excel;
    public partial class vardiya : Form
    {
        private DataTable _dataTable;
        private SqlConnection connection;

        public vardiya()
        {
            connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo());
            InitializeComponent();
            ListVardiyalar();
            FillSicilComboBox();
            FillVardiyaComboBox();
        }

        //Sicil no listesi ComboBox
        private void FillSicilComboBox()
        {
            try
            {
                List<string> sicilNumaralari = new List<string>();

                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    string sqlCommand = "SELECT sicil_no FROM personeller WHERE kadro_turu <> 'Yönetici'";

                    using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string sicilNo = reader["sicil_no"].ToString();
                                sicilNumaralari.Add(sicilNo);
                            }
                        }
                    }
                }


                sicilNumaralari.Insert(0, "Seçiniz");


                sicil_cmbbox.DataSource = sicilNumaralari;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sicil numaralarını listelerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillVardiyaComboBox()
        {
            try
            {
                List<string> sicilNumaralari = new List<string>();

                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    string sqlCommand = "SELECT id,vardiya FROM vardiya";

                    using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string sicilNo = reader["vardiya"].ToString();
                                sicilNumaralari.Add(sicilNo);
                            }
                        }
                    }
                }

                vardiya_cmbbox.DataSource = sicilNumaralari;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sicil numaralarını listelerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Vardiya Listeleme functionu 
        public void ListVardiyalar()
        {
            try
            {
                string query = "WITH IzinliSicilNoRank AS (\r\n    SELECT\r\n        vk.ID,\r\n        vk.Sicil_No,\r\n        vk.Gün_Bilgisi,\r\n        izinli.sicil_no AS IzinliSicilNo,\r\n        ROW_NUMBER() OVER (PARTITION BY vk.ID, vk.Sicil_No, vk.Gün_Bilgisi ORDER BY izinli.sicil_no) AS RowNum\r\n    FROM\r\n        vardiya_kayit AS vk\r\n    LEFT JOIN\r\n        vardiya_izin AS izinli ON vk.Gün_Bilgisi = izinli.gün_bilgisi\r\n),\r\nIzinliSicilAdSoyad AS (\r\n    SELECT\r\n        isr.ID,\r\n        isr.Sicil_No,\r\n        isr.Gün_Bilgisi,\r\n        isr.IzinliSicilNo,\r\n        isr.RowNum,\r\n        ISNULL(p.ad, '') AS IzinliAd,\r\n        ISNULL(p.soyad, '') AS IzinliSoyad\r\n    FROM\r\n        IzinliSicilNoRank isr\r\n    LEFT JOIN\r\n        personeller p ON isr.IzinliSicilNo = p.sicil_no\r\n)\r\nSELECT\r\n    vk.ID,\r\n    vk.Sicil_No,\r\n    vk.Gün_Bilgisi,\r\n    FORMAT(vk.Gün_Bilgisi, 'dddd', 'tr-TR') AS HaftaninGunleri,\r\n    vk.Saat_Bilgisi,\r\n    vk.Gorev_Bolgesi,\r\n    p.ad,\r\n    p.soyad,\r\n    STUFF((\r\n        SELECT ' - ' + ISNULL(CAST(izinliAdSoyad.IzinliAd + ' ' + izinliAdSoyad.IzinliSoyad + ' (' + CAST(izinliAdSoyad.IzinliSicilNo AS NVARCHAR(MAX)) + ')' AS NVARCHAR(MAX)), '')\r\n        FROM IzinliSicilAdSoyad izinliAdSoyad\r\n        WHERE izinliAdSoyad.ID = vk.ID\r\n        FOR XML PATH('')), 1, 3, '') AS IzinliAdSoyad,\r\n    ISNULL(p_izin_yonetimi.ad + ' ' + p_izin_yonetimi.soyad + ' (' + CAST(izin_yonetimi.sicil_numarasi AS NVARCHAR(MAX)) + ')', '') AS Ek_Izinli_Personel\r\nFROM\r\n    vardiya_kayit AS vk\r\nINNER JOIN\r\n    personeller AS p ON vk.Sicil_No = p.sicil_no\r\nLEFT JOIN\r\n    IzinliSicilNoRank AS izinli ON vk.ID = izinli.ID AND vk.Sicil_No = izinli.Sicil_No AND vk.Gün_Bilgisi = izinli.Gün_Bilgisi\r\nLEFT JOIN\r\n    IzinliSicilAdSoyad AS izinliAdSoyad ON izinli.ID = izinliAdSoyad.ID AND izinli.Sicil_No = izinliAdSoyad.Sicil_No AND izinli.Gün_Bilgisi = izinliAdSoyad.Gün_Bilgisi AND izinli.RowNum = izinliAdSoyad.RowNum\r\nLEFT JOIN\r\n    izin_yonetimi ON vk.Gün_Bilgisi = izin_yonetimi.izin_tarihi\r\nLEFT JOIN\r\n    personeller AS p_izin_yonetimi ON p_izin_yonetimi.sicil_no = izin_yonetimi.sicil_numarasi\r\nGROUP BY\r\n    vk.ID,\r\n    vk.Sicil_No,\r\n    vk.Gün_Bilgisi,\r\n    FORMAT(vk.Gün_Bilgisi, 'dddd', 'tr-TR'),\r\n    vk.Saat_Bilgisi,\r\n    vk.Gorev_Bolgesi,\r\n    p.ad,\r\n    p.soyad,\r\n    p_izin_yonetimi.ad,\r\n    p_izin_yonetimi.soyad,\r\n    izin_yonetimi.sicil_numarasi\r\nORDER BY\r\n    vk.Gün_Bilgisi ASC, p.ad, p.soyad;\r\n";

                using (SqlConnection con = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Eğer DataSource null değilse, sıfırla
                        if (vardiya_tablosu.DataSource != null)
                        {
                            vardiya_tablosu.DataSource = null;
                        }

                        vardiya_tablosu.DataSource = dataTable;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void vardiyaDataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < vardiya_tablosu.Rows.Count)
            {
                vardiya_tablosu.ClearSelection();
                vardiya_tablosu.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = vardiya_tablosu.Rows[e.RowIndex];

                string pers_sicil = selectedRow.Cells["Sicil_no"].Value?.ToString();
                sicil_cmbbox.Text = pers_sicil;

                string vard_bas_saat = selectedRow.Cells["Gün_Bilgisi"].Value?.ToString();
                gun_picker.Text = vard_bas_saat;

                string vard_bit_saat = selectedRow.Cells["Saat_Bilgisi"].Value?.ToString();
                vardiya_cmbbox.Text = vard_bit_saat;

                string vard_gun = selectedRow.Cells["Gorev_Bolgesi"].Value?.ToString();
                Bolge_cmbbox.Text = vard_gun;




            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (string.IsNullOrWhiteSpace(sicil_cmbbox.Text) || string.IsNullOrWhiteSpace(vardiya_cmbbox.Text) || string.IsNullOrWhiteSpace(Bolge_cmbbox.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (int.TryParse(sicil_cmbbox.Text, out int sicil))
                {
                    int sicilss = Convert.ToInt32(sicil_cmbbox.Text);
                    using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                    {
                        connection.Open();

                        // Retrieve the name and surname of the person with the given sicil
                        string selectPersonQuery = "SELECT ad, soyad FROM personeller WHERE sicil_no = @SicilNo";
                        using (SqlCommand selectPersonCommand = new SqlCommand(selectPersonQuery, connection))
                        {
                            selectPersonCommand.Parameters.AddWithValue("@SicilNo", sicilss);

                            using (SqlDataReader personReader = selectPersonCommand.ExecuteReader())
                            {
                                if (personReader.Read())
                                {
                                    string isim = personReader["ad"].ToString();
                                    string soyisim = personReader["soyad"].ToString();
                                    DateTime Gün_Bilgisi = gun_picker.Value;
                                    string Saat_Bilgisi = vardiya_cmbbox.Text;
                                    string Gorev_Bolgesi = Bolge_cmbbox.Text;
                                    string HaftaninGunleri = Gün_Bilgisi.ToString("dddd");
                                    personReader.Close();


                                    #region çalışıyor özel günler kısmı
                                    string selectOzelGunlerQuery = "SELECT Tarih FROM OzelGunler";

                                    List<DateTime> ozelGunler = new List<DateTime>();


                                    using (SqlCommand selectOzelGunlerCommand = new SqlCommand(selectOzelGunlerQuery, connection))
                                    {
                                        using (SqlDataReader ozelGunlerReader = selectOzelGunlerCommand.ExecuteReader())
                                        {
                                            while (ozelGunlerReader.Read())
                                            {
                                                ozelGunler.Add(ozelGunlerReader.GetDateTime(0).Date);
                                            }
                                        }
                                    }


                                    
                                    // Kontrol etmek için seçilen bölge ve tarihi içeren sorgu
                                    string checkBolgeAndTarihQuery = "SELECT COUNT(*) FROM vardiya_kayit WHERE Gorev_Bolgesi = @BolgeAdi AND Gün_Bilgisi = @Tarih";
                                    using (SqlCommand checkBolgeAndTarihCommand = new SqlCommand(checkBolgeAndTarihQuery, connection))
                                    {
                                        checkBolgeAndTarihCommand.Parameters.AddWithValue("@BolgeAdi", Gorev_Bolgesi);
                                        checkBolgeAndTarihCommand.Parameters.AddWithValue("@Tarih", Gün_Bilgisi.Date);

                                        int kampusIciCount = (int)checkBolgeAndTarihCommand.ExecuteScalar();

                                        // Eğer seçilen bölge kampüs içinde ise ve tarih özel günse kontrol et
                                        if (Gorev_Bolgesi == "Kampüs İçi" && ozelGunler.Contains(Gün_Bilgisi.Date))
                                        {
                                            MessageBox.Show($"Seçilen bölge ({Gorev_Bolgesi}) kampüs içindedir ve seçilen tarih özel gündür. Ekleme yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;  // Ekleme işlemini reddet
                                        }
                                        else if (Gorev_Bolgesi == "Kampüs Dışı" && ozelGunler.Contains(Gün_Bilgisi.Date))
                                        {
                                            DialogResult result = MessageBox.Show($"Seçilen bölge ({Gorev_Bolgesi}) kampüs dışındadır ve seçilen tarih özel gündür. Ekleme yapmak istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                            if (result == DialogResult.No)
                                            {
                                                return; // Ekleme işlemini reddet
                                            }
                                        }
                                        #endregion

                                        #region çalışıyor izinler tablosu sorgulama ve aynı vardiyayı sorgulama

                                        string checkExistingVardiyaQuery = "SELECT COUNT(*) FROM vardiya_kayit WHERE Sicil_No = @SicilNo AND Gün_Bilgisi = @GunBilgisi";
                                        using (SqlCommand checkExistingVardiyaCommand = new SqlCommand(checkExistingVardiyaQuery, connection))
                                        {
                                            checkExistingVardiyaCommand.Parameters.AddWithValue("@SicilNo", sicilss);
                                            checkExistingVardiyaCommand.Parameters.AddWithValue("@GunBilgisi", Gün_Bilgisi);

                                            int existingVardiyaCount = (int)checkExistingVardiyaCommand.ExecuteScalar();

                                            string checkExistingIzinQuery = "SELECT COUNT(*) FROM izin_yonetimi WHERE sicil_numarasi = @SicilNo " +
                                                                            "AND CONVERT(DATE, @GunBilgisi) = CONVERT(DATE, izin_tarihi)";

                                            using (SqlCommand checkExistingIzinCommand = new SqlCommand(checkExistingIzinQuery, connection))
                                            {
                                                checkExistingIzinCommand.Parameters.AddWithValue("@SicilNo", sicilss);
                                                checkExistingIzinCommand.Parameters.AddWithValue("@GunBilgisi", Gün_Bilgisi);

                                                int existingIzinCount = (int)checkExistingIzinCommand.ExecuteScalar();

                                                if (existingIzinCount > 0)
                                                {
                                                    DialogResult result = MessageBox.Show("Bu personelin belirtilen tarihte izni bulunmaktadır. Yine de vardiyayı eklemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                                    if (result == DialogResult.No)
                                                    {
                                                        return; // Vardiyayı eklemeyi reddet
                                                    }
                                                }

                                                if (existingVardiyaCount > 0)
                                                {
                                                    DialogResult result = MessageBox.Show("Bu personelin belirtilen tarihte zaten bir vardiyası bulunmaktadır. Yine de eklemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                                    if (result == DialogResult.No)
                                                    {
                                                        return; // Vardiyayı eklemeyi reddet
                                                    }
                                                }
                                                #endregion

                                                // Buraya personeller tablosundaki izin kontrollerini ekleyin
                                                string checkPersonelIzinQuery = "SELECT COUNT(*) FROM personeller WHERE sicil_no = @SicilNo " +
                                                                                "AND (@HaftaninGunleri = izin_1 OR @HaftaninGunleri = izin_2)";

                                                using (SqlCommand checkPersonelIzinCommand = new SqlCommand(checkPersonelIzinQuery, connection))
                                                {
                                                    checkPersonelIzinCommand.Parameters.AddWithValue("@SicilNo", sicilss);
                                                    checkPersonelIzinCommand.Parameters.AddWithValue("@HaftaninGunleri", HaftaninGunleri);

                                                    int personelIzinCount = (int)checkPersonelIzinCommand.ExecuteScalar();

                                                    if (personelIzinCount > 0)
                                                    {
                                                        DialogResult result = MessageBox.Show("Bu personelin belirtilen tarihte izni bulunmaktadır. Yine de vardiyayı eklemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                                        if (result == DialogResult.No)
                                                        {
                                                            return; // Vardiyayı eklemeyi reddet
                                                        }
                                                    }

                                                    // Ekleme işlemini gerçekleştir
                                                    string insertVardiyaQuery = "INSERT INTO vardiya_kayit (Sicil_No, isim, soyisim, Gün_Bilgisi, Saat_Bilgisi, Gorev_Bolgesi) " +
                                                                           "VALUES (@SicilNo, @Isim, @Soyisim, @GunBilgisi, @SaatBilgisi, @GorevBolgesi)";
                                                    

                                                    using (SqlCommand insertVardiyaCommand = new SqlCommand(insertVardiyaQuery, connection))
                                                    {
                                                        insertVardiyaCommand.Parameters.AddWithValue("@SicilNo", sicilss);
                                                        insertVardiyaCommand.Parameters.AddWithValue("@Isim", isim);
                                                        insertVardiyaCommand.Parameters.AddWithValue("@Soyisim", soyisim);
                                                        insertVardiyaCommand.Parameters.AddWithValue("@GunBilgisi", Gün_Bilgisi);
                                                        insertVardiyaCommand.Parameters.AddWithValue("@SaatBilgisi", Saat_Bilgisi);
                                                        insertVardiyaCommand.Parameters.AddWithValue("@GorevBolgesi", Gorev_Bolgesi);

                                                        insertVardiyaCommand.ExecuteNonQuery();

                                 
                                                    }
                                                    MessageBox.Show("Başarıyla vardiya eklendi", "Başarılı", MessageBoxButtons.OK);

                                                    ListVardiyalar();
                                                    vardiya_tablosu.ClearSelection();
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sicil numarasına uygun personel bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir sicil numarası ve izin saatleri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Hata oluştu: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", "Hata");
            }
        }

        private void ButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (vardiya_tablosu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = vardiya_tablosu.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                DateTime Gün_Bilgisi = gun_picker.Value;
                string Saat_Bilgisi = vardiya_cmbbox.Text;
                string Gorev_Bolgesi = Bolge_cmbbox.Text;
                string sicil = sicil_cmbbox.Text;
                string HaftaninGunleri = Gün_Bilgisi.ToString("dddd");


                try
                {
                    string selectPersonQuery = "SELECT ad, soyad FROM personeller WHERE sicil_no = @SicilNo";

                    using (SqlCommand selectPersonCommand = new SqlCommand(selectPersonQuery, connection))
                    {
                        selectPersonCommand.Parameters.AddWithValue("@SicilNo", sicil);

                        connection.Open();
                        using (SqlDataReader personReader = selectPersonCommand.ExecuteReader())
                        {
                            if (personReader.Read())
                            {
                                string isim = personReader["ad"].ToString();
                                string soyisim = personReader["soyad"].ToString();

                                personReader.Close();

                                int sicilss = Convert.ToInt32(sicil_cmbbox.Text);

                                // İzin kontrolü
                                string checkExistingIzinQuery = "SELECT COUNT(*) FROM izin_yonetimi WHERE sicil_numarasi = @SicilNo " +
                                                                            "AND CONVERT(DATE, @GunBilgisi) = CONVERT(DATE, izin_tarihi)";
                                using (SqlCommand checkExistingIzinCommand = new SqlCommand(checkExistingIzinQuery, connection))
                                {
                                    checkExistingIzinCommand.Parameters.AddWithValue("@SicilNo", sicilss);
                                    checkExistingIzinCommand.Parameters.AddWithValue("@GunBilgisi", Gün_Bilgisi);

                                    int existingIzinCount = (int)checkExistingIzinCommand.ExecuteScalar();



                                    // Vardiya kontrolü
                                    string checkExistingVardiyaQuery = "SELECT COUNT(*) FROM vardiya_kayit WHERE Sicil_No = @SicilNo AND Gün_Bilgisi = @GunBilgisi AND ID <> @ID";
                                    using (SqlCommand checkExistingVardiyaCommand = new SqlCommand(checkExistingVardiyaQuery, connection))
                                    {
                                        checkExistingVardiyaCommand.Parameters.AddWithValue("@SicilNo", sicilss);
                                        checkExistingVardiyaCommand.Parameters.AddWithValue("@GunBilgisi", Gün_Bilgisi);
                                        checkExistingVardiyaCommand.Parameters.AddWithValue("@ID", id);

                                        int existingVardiyaCount = (int)checkExistingVardiyaCommand.ExecuteScalar();

                                        // İzin kontrolü
                                        string checkPersonelIzinQuery = "SELECT COUNT(*) FROM personeller WHERE sicil_no = @SicilNo " +
                                            "AND (@HaftaninGunleri = izin_1 OR @HaftaninGunleri = izin_2)";

                                        using (SqlCommand checkPersonelIzinCommand = new SqlCommand(checkPersonelIzinQuery, connection))
                                        {
                                            checkPersonelIzinCommand.Parameters.AddWithValue("@SicilNo", sicilss);
                                            checkPersonelIzinCommand.Parameters.AddWithValue("@HaftaninGunleri", HaftaninGunleri);

                                            int personelIzinCount = (int)checkPersonelIzinCommand.ExecuteScalar();

                                            if (personelIzinCount > 0)
                                            {
                                                DialogResult result = MessageBox.Show("Bu personelin belirtilen tarihte izni bulunmaktadır. Yine de işlem yapmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                                if (result == DialogResult.No)
                                                {
                                                    return; // İşlemi reddet
                                                }
                                            }

                                            if (existingIzinCount > 0)
                                            {
                                                DialogResult result = MessageBox.Show("Bu personelin belirtilen tarihte izni bulunmaktadır. Yine de vardiyayı güncellemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                                if (result == DialogResult.No)
                                                {
                                                    return; // Vardiyayı güncellemeyi reddet
                                                }
                                            }

                                            if (existingVardiyaCount > 0)
                                            {
                                                DialogResult result = MessageBox.Show("Bu personelin belirtilen tarihte zaten bir vardiyası bulunmaktadır. Yine de güncellemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                                if (result == DialogResult.No)
                                                {
                                                    return; // Vardiyayı güncellemeyi reddet
                                                }
                                            }
                                        }
                                    }
                                }

                                // Vardiya güncelleme
                                string updateQuery = "UPDATE vardiya_kayit SET Gün_Bilgisi = @a, Saat_Bilgisi = @b, Gorev_Bolgesi = @c, Sicil_No = @d, isim = @e, soyisim = @f WHERE ID = @ID";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@a", Gün_Bilgisi);
                                    updateCommand.Parameters.AddWithValue("@b", Saat_Bilgisi);
                                    updateCommand.Parameters.AddWithValue("@c", Gorev_Bolgesi);
                                    updateCommand.Parameters.AddWithValue("@d", sicil);
                                    updateCommand.Parameters.AddWithValue("@e", isim);
                                    updateCommand.Parameters.AddWithValue("@f", soyisim);
                                    updateCommand.Parameters.AddWithValue("@ID", id);

                                    updateCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show("Veri başarıyla güncellendi.");
                                ListVardiyalar();
                            }
                            else
                            {
                                MessageBox.Show("Sicil numarasına uygun personel bulunamadı.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    connection.Close(); // Bağlantıyı her durumda kapat
                }
            }
        }

        public void ButtonSil_Click(object sender, EventArgs e)
        {
            try {
                DataGridViewRow selectedRow = vardiya_tablosu.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                if (MessageBox.Show("Seçili veriyi silmek istediğinizden emin misiniz?", "Veri Silme", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM vardiya_kayit WHERE ID= @ID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ID", id);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Veri başarıyla silindi.");
                        ListVardiyalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tablodan bir değer seçiniz !");
            }
        }

        //Otomasyon formunu açan function
        private void otomasyon_button_Click(object sender, EventArgs e)
        {
            otomasyon mainForm = new otomasyon();
            mainForm.Show();
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            ListVardiyalar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Dosya iletişim kutusunu oluşturun
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Başlangıçta görünecek dosya adını ve türünü belirtin
                saveFileDialog.FileName = "PersonelTablosu.csv";
                saveFileDialog.Filter = "CSV Dosyaları (*.csv)|*.csv|Tüm Dosyalar (*.*)|*.*";

                // Eğer kullanıcı bir dosya seçerse
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen dosyanın yolunu alın
                    string filePath = saveFileDialog.FileName;

                    // DataGridView'in null olup olmadığını kontrol et
                    if (vardiya_tablosu == null)
                    {
                        MessageBox.Show("vardiya_tablosu DataGridView'i null değer içeriyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // DataTable'daki verileri CSV dosyasına kaydedin
                    ExportDataTableToCSV((DataTable)vardiya_tablosu.DataSource, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportDataTableToExcel(DataTable dataTable, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataTable.Columns[i].ColumnName;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                }
            }

            workbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookDefault);
            excelApp.Quit();
        }

        private void ExportDataTableToCSV(DataTable dataTable, string filePath)
        {
            if (vardiya_tablosu == null)
            {
                MessageBox.Show("vardiya_tablosu DataGridView'i null değer içeriyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StringBuilder sb = new StringBuilder();

            // dataTable null olup olmadığını kontrol et
            if (dataTable != null)
            {
                // dataTable.Columns null olup olmadığını kontrol et
                if (dataTable.Columns != null)
                {
                    // Başlık satırı
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // Her bir sütunun adını kontrol et
                        if (column != null && !string.IsNullOrEmpty(column.ColumnName))
                        {
                            sb.Append($"\"{column.ColumnName}\";");
                        }
                    }
                    sb.AppendLine();

                    // Veri satırları
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            // Her bir hücre değerini kontrol et
                            if (column != null && row[column] != null)
                            {
                                sb.Append($"\"{row[column].ToString().Replace("\"", "\"\"")}\";");
                            }
                        }
                        sb.AppendLine();
                    }

                    try
                    {
                        CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
                        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("DataTable verileri başarıyla dosyaya kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show($"İzin hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("DataTable.Columns null değer içeriyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("DataTable null değer içeriyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetVardiyaDataTableFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    string query = "SELECT * FROM vardiya_kayit";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private DataTable GetIzinDataTableFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                // İzinlerin bulunduğu tabloyu seçiniz
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    string query = "SELECT * FROM izin_yonetimi";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Tüm vardiyaları silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo())) // your_connection_string'i kendi veritabanı bağlantı dizenizle değiştirin
                        {
                            connection.Open();

                            string query = "DELETE FROM vardiya_kayit";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.ExecuteNonQuery();
                            }

                            MessageBox.Show("Tüm vardiyalar başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ListVardiyalar(); // Verileri tekrar yükleyerek DataGridView'i güncelle
                        }
                    SoliteraxLibrary.SoliteraxConnection conn = new SoliteraxLibrary.SoliteraxConnection(SoliteraxLibrary.SoliteraxConnection.ConnectionType.SQL);
                    conn.Connect(Tablolar.DatabaseManager.Instance.GetDBInfo());
                    ((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).GetManager().SendData("delete from mesailer");
                    ((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).DisConnect();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    } 
