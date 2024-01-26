using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using PersonelVardiyaOtomasyonu.Tablolar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PersonelVardiyaOtomasyonu
{
    public partial class personel : Form
    {

        public personel()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Veritabanından personel verilerini çek
                string sqlQuery = "SELECT * FROM personeller";
                string connectionString = "Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True";

                DataTable dataTable = GetDataTableFromSqlQuery(sqlQuery, connectionString);

                // DataGridView'e DataTable'ı ata
                personel_tablo.DataSource = dataTable;

                // DataGridView sütunları düzenle
                if (personel_tablo.Columns.Contains("id"))
                {
                    personel_tablo.Columns["id"].Visible = false;
                }

                // ComboBox olayını ekleyerek filtreleme işlemlerini gerçekleştir
                kadro_tur_cmbbox.OnSelectedIndexChanged += kadro_tur_cmbbox_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                // Hata durumunda gerekli işlemleri gerçekleştirin
                Console.WriteLine($"Hata: {ex.Message}");
            }

            kadro_tur_cmbbox.OnSelectedIndexChanged += Kadro_tur_cmbbox_SelectedIndexChanged;
        }

        private void Kadro_tur_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            izin_gun_1cmbbox.Visible = false;
            label1.Visible = false;
            izin_gun_2cmbbox.Visible = false;
            label2.Visible = false;

            if (kadro_tur_cmbbox.Text.ToLower().Equals("işçi"))
            {
                izin_gun_1cmbbox.Visible = true;
                label1.Visible = true;
            }
            if (kadro_tur_cmbbox.Text.ToLower().Equals("memur"))
            {
                izin_gun_1cmbbox.Visible = true;
                label1.Visible = true;
                izin_gun_2cmbbox.Visible = true;
                label2.Visible = true;
            }
            
            
        }

        private DataTable GetDataTableFromSqlQuery(string sqlQuery, string connectionString)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda gerekli işlemleri gerçekleştirin
                Console.WriteLine($"Hata: {ex.Message}");
            }

            return dataTable;
        }

        private void kadro_tur_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kadro_tur_cmbbox.SelectedItem != null)
            {
                string selectedKadro = kadro_tur_cmbbox.SelectedItem.ToString(); // Convert to string

                try
                {
                    using (var connection = new SqlConnection($"Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                    {
                        connection.Open();

                        // Sicil no'yu almak için önce kadro türüne ait sicil_no'yu sorgulayalım.
                        string sicilNoQuery = $"SELECT sicil_no FROM personeller WHERE kadro_tur = @selectedKadro";
                        using (var sicilNoCommand = new SqlCommand(sicilNoQuery, connection))
                        {
                            sicilNoCommand.Parameters.AddWithValue("@selectedKadro", selectedKadro);

                            object sicilNoResult = sicilNoCommand.ExecuteScalar();

                            if (sicilNoResult != null)
                            {
                                string sicilNo = sicilNoResult.ToString();

                                // Sicil no'ya göre detaylı bilgileri çekelim.
                                string query = $"SELECT * FROM personeller WHERE sicil_no = @sicil_no";
                                using (var command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@sicil_no", sicilNo);

                                    using (var reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            if (selectedKadro == "Memur")
                                            {
                                                izin_gun_1cmbbox.Visible = true;
                                                izin_gun_2cmbbox.Visible = true;
                                                label1.Visible = true;
                                                label2.Visible = true;
                                            }
                                            else if (selectedKadro == "İşçi")
                                            {
                                                izin_gun_1cmbbox.Visible = true;
                                                label1.Visible = true;
                                            }
                                            else if (selectedKadro == "Yönetici")
                                            {
                                                izin_gun_1cmbbox.Visible = false;
                                                izin_gun_2cmbbox.Visible = false;
                                                label1.Visible = false;
                                                label2.Visible = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata combo box: " + ex.Message);
                    Console.WriteLine("Hatanın Kaynağı: " + ex.Source);
                    Console.WriteLine("Hata Stack Trace: " + ex.StackTrace);
                }
            }
        }

        private bool IsUsed(string columnName, string value)
        {
            using (var connection = new SqlConnection($"Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
            {
                connection.Open();

                // Belirtilen kolon ve değere göre sorgu
                string query = $"SELECT COUNT(*) FROM personeller WHERE {columnName} = @Value";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value);

                    int count = (int)command.ExecuteScalar();

                    // Eğer count değeri 0'dan büyükse, belirtilen değer kullanılmış demektir
                    return count > 0;
                }
            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string sicilNo = sicil_txtbox.Text;
                string tcNo = TC_txtbox.Text;
                string mail = mail_txtbox.Text;

                if (string.IsNullOrWhiteSpace(ad_txtbox.Text) || string.IsNullOrWhiteSpace(soyad_txtbox.Text) || string.IsNullOrWhiteSpace(sicil_txtbox.Text) || string.IsNullOrWhiteSpace(kadro_tur_cmbbox.Text) || string.IsNullOrWhiteSpace(unvan_txtbox.Text) || string.IsNullOrWhiteSpace(mail_txtbox.Text) || string.IsNullOrWhiteSpace(sifre_txtbox.Text) || string.IsNullOrWhiteSpace(tel_txtbox.Text) || string.IsNullOrWhiteSpace(TC_txtbox.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (IsUsed("sicil_no", sicilNo))
                {
                    MessageBox.Show("Bu sicil numarası zaten kullanılmaktadır. Lütfen başka bir sicil numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (IsUsed("TC_no", tcNo))
                {
                    MessageBox.Show("Bu TC numarası zaten kullanılmaktadır. Lütfen başka bir TC numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (IsUsed("mail", mail))
                {
                    MessageBox.Show("Bu e-posta adresi zaten kullanılmaktadır. Lütfen başka bir e-posta adresi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (int.TryParse(sicil_txtbox.Text, out int sicil))
                {
                    using (var connection = new SqlConnection($"Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                    {
                        connection.Open();

                        using (var command = new SqlCommand("INSERT INTO personeller (sicil_no, ad, soyad, mail, tel_no, TC_no, kadro_turu, personel_unvan, sifre, izin_1, izin_2) VALUES (@sicil, @ad, @soyad, @mail, @tel_no, @TC_no, @kadro_turu, @personel_unvan, @sifre, @izin_1, @izin_2)", connection))
                        {
                            command.Parameters.AddWithValue("@sicil", sicil);
                            command.Parameters.AddWithValue("@ad", ad_txtbox.Text);
                            command.Parameters.AddWithValue("@soyad", soyad_txtbox.Text);
                            command.Parameters.AddWithValue("@mail", mail_txtbox.Text);
                            command.Parameters.AddWithValue("@tel_no", tel_txtbox.Text);
                            command.Parameters.AddWithValue("@TC_no", TC_txtbox.Text);
                            command.Parameters.AddWithValue("@kadro_turu", kadro_tur_cmbbox.Text);
                            command.Parameters.AddWithValue("@personel_unvan", unvan_txtbox.Text);
                            command.Parameters.AddWithValue("@sifre", sifre_txtbox.Text);
                            command.Parameters.AddWithValue("@izin_1", izin_gun_1cmbbox.Text);
                            command.Parameters.AddWithValue("@izin_2", izin_gun_2cmbbox.Text);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Başarıyla personel eklendi", "Başarılı", MessageBoxButtons.OK);
                            
                            ClearAllTexts();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir sicil numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);

            }
            finally
            {
                

                LoadData();
            }
        }

        private void ButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (personel_tablo.SelectedRows.Count > 0)
            {
                int selectedRowIndex = personel_tablo.SelectedRows[0].Index;
                int selectedId = Convert.ToInt32(personel_tablo.Rows[selectedRowIndex].Cells["id"].Value);

                try
                {
                    using (var connection = new SqlConnection($"Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                    {
                        connection.Open();


                        using (var command = new SqlCommand("UPDATE personeller SET sicil_no = @sicil, ad = @ad, soyad = @soyad, kadro_turu = @kadro_turu, personel_unvan = @personel_unvan, mail = @mail, sifre = @sifre, tel_no = @tel_no, TC_no = @TC_no, izin_1 = @izin_1, izin_2 = @izin_2 WHERE id = @id", connection))
                        {
                            command.Parameters.AddWithValue("@id", selectedId);

                            // Sicil değeri geçerli bir sayı mı kontrolü
                            if (int.TryParse(sicil_txtbox.Text, out int sicil))
                            {
                                command.Parameters.AddWithValue("@sicil", sicil);
                            }
                            else
                            {
                                MessageBox.Show("Geçerli bir sicil numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            command.Parameters.AddWithValue("@id", selectedId);
                            command.Parameters.AddWithValue("@sicil", int.TryParse(sicil_txtbox.Text, out sicil) ? (object)sicil : DBNull.Value);
                            command.Parameters.AddWithValue("@ad", ad_txtbox.Text);
                            command.Parameters.AddWithValue("@soyad", soyad_txtbox.Text);
                            command.Parameters.AddWithValue("@kadro_turu", kadro_tur_cmbbox.Text);
                            command.Parameters.AddWithValue("@personel_unvan", unvan_txtbox.Text);
                            command.Parameters.AddWithValue("@mail", mail_txtbox.Text);
                            command.Parameters.AddWithValue("@sifre", sifre_txtbox.Text);
                            command.Parameters.AddWithValue("@tel_no", tel_txtbox.Text);
                            command.Parameters.AddWithValue("@TC_no", TC_txtbox.Text);
                            command.Parameters.AddWithValue("@izin_1", izin_gun_1cmbbox.Text);

                            // Kadro turu "memur" iken "işçi" olarak güncellenirse izin_2'yi NULL yap
                            command.Parameters.AddWithValue("@izin_2", (kadro_tur_cmbbox.Text == "işçi") ? DBNull.Value : (object)izin_gun_2cmbbox.Text);

                            command.ExecuteNonQuery();

                            ClearAllTexts();
                        }
                    }

                    MessageBox.Show($"Başarıyla Personel Güncellendi", "Başarılı", MessageBoxButtons.OK);

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Hata: " + ex.Message);
                    Console.WriteLine("Hatanın Kaynağı: " + ex.Source);
                    Console.WriteLine("Hata Stack Trace: " + ex.StackTrace);
                }
            }
        }

        private void ButtonSil_Click(object sender, EventArgs e)
        {
            if (personel_tablo.SelectedRows.Count > 0)
            {
                int selectedRowIndex = personel_tablo.SelectedRows[0].Index;
                int selectedPersonId = Convert.ToInt32(personel_tablo.Rows[selectedRowIndex].Cells["id"].Value);

                try
                {
                    using (var connection = new SqlConnection($"Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                    {
                        connection.Open();

                        // Silme işlemi öncesi onay al
                        DialogResult result = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            using (var command = new SqlCommand("DELETE FROM personeller WHERE id = @id", connection))
                            {
                                command.Parameters.AddWithValue("@id", selectedPersonId);
                                command.ExecuteNonQuery();
                            }

                            MessageBox.Show("Başarıyla personel kaldırıldı", "Başarılı", MessageBoxButtons.OK);
                            LoadData();

                            ClearAllTexts();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Hata: " + ex.Message);
                    Console.WriteLine("Hatanın Kaynağı: " + ex.Source);
                    Console.WriteLine("Hata Stack Trace: " + ex.StackTrace);

                }
            }
        }

        void ClearAllTexts()
        {
            ad_txtbox.SecretProperties.Clear();
            soyad_txtbox.SecretProperties.Clear();
            sicil_txtbox.SecretProperties.Clear();
            kadro_tur_cmbbox.Text = "";
            unvan_txtbox.SecretProperties.Clear();
            mail_txtbox.SecretProperties.Clear();
            sifre_txtbox.SecretProperties.Clear();
            tel_txtbox.SecretProperties.Clear();
            TC_txtbox.SecretProperties.Clear();
            izin_gun_1cmbbox.Text = "";
            izin_gun_2cmbbox.Text = "";
        }

        //yazdırma btonu
        private void button1_Click_1(object sender, EventArgs e)
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

                    // DataTable'daki verileri SQL sorgusu ile alın
                    DataTable dataTable = GetDataFromDatabase();

                    // Verileri CSV dosyasına kaydedin
                    ExportDataTableToCSV(dataTable, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDataFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SqlConnection($"Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                {
                    connection.Open();

                    // Örnek SQL sorgusu, gerçek sorgunuzu bu örneğe uyarlayın
                    string query = "SELECT * FROM personeller";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private void ExportDataTableToCSV(DataTable dataTable, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Başlık satırı
            foreach (DataColumn column in dataTable.Columns)
            {
                sb.Append($"\"{column.ColumnName}\";"); // Noktalı virgül kullanarak sütunları ayırdık
            }
            sb.AppendLine();

            // Veri satırları
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    sb.Append($"\"{row[column].ToString().Replace("\"", "\"\"")}\";"); // Noktalı virgül kullanarak hücreleri ayırdık
                }
                sb.AppendLine();
            }

            try
            {
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8); // Türkçe karakterleri doğru bir şekilde korumak için Encoding.UTF8 ekledik
                MessageBox.Show("DataTable verileri başarıyla CSV dosyasına kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"İzin hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void personel_tablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < personel_tablo.Rows.Count)
            {
                personel_tablo.ClearSelection();
                personel_tablo.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = personel_tablo.Rows[e.RowIndex];

                string sicil_no = selectedRow.Cells["sicil_no"].Value?.ToString();

                try
                {
                    string connectionString = "Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM personeller WHERE sicil_no = @sicil_no";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@sicil_no", sicil_no);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {

                                    ad_txtbox.Text = reader["ad"].ToString();
                                    soyad_txtbox.Text = reader["soyad"].ToString();
                                    mail_txtbox.Text = reader["mail"].ToString();
                                    sicil_txtbox.Text = reader["sicil_no"].ToString();
                                    kadro_tur_cmbbox.Text = reader["kadro_turu"].ToString();
                                    unvan_txtbox.Text = reader["personel_unvan"].ToString();
                                    sifre_txtbox.Text = reader["sifre"].ToString();
                                    tel_txtbox.Text = reader["tel_no"].ToString();
                                    TC_txtbox.Text = reader["TC_no"].ToString();
                                    izin_gun_1cmbbox.Text = reader["izin_1"].ToString();
                                    izin_gun_2cmbbox.Text = reader["izin_2"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                    Console.WriteLine("Hatanın Kaynağı: " + ex.Source);
                    Console.WriteLine("Hata Stack Trace: " + ex.StackTrace);
                    
                }
            }
        }
    }
}
