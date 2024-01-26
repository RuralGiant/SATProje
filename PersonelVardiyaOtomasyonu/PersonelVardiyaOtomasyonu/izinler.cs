using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using PersonelVardiyaOtomasyonu.Tablolar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PersonelVardiyaOtomasyonu
{

    public partial class izinler : Form
    {
        private SqlConnection connection;

        public izinler()
        {
            connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo());
            InitializeComponent();
            LoadData();
            Sicil_cmbbox.SelectedIndexChanged += Sicil_cmbbox_SelectedIndexChanged;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    // Veritabanındaki izinleri çek
                    string izinQuery = "SELECT id,sicil_numarasi,isim,soyisim,izin_tarihi FROM izin_yonetimi ";
                    using (SqlCommand izinCommand = new SqlCommand(izinQuery, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(izinCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Tabloyu güncelle
                        izinler_tablo.DataSource = dataTable;

                        // Gereksiz sütunları gizle
                        if (izinler_tablo.Columns.Contains("id"))
                        {
                            izinler_tablo.Columns["id"].Visible = false;
                        }
                    }
                }

                VeriCekSicilNumaralari();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme hatası 1: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VeriCekSicilNumaralari()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    // Sicil numaralarını çek
                    string sicilQuery = "SELECT sicil_no FROM personeller WHERE kadro_turu <> 'Yönetici'";
                    using (SqlCommand sicilCommand = new SqlCommand(sicilQuery, connection))
                    {
                        using (SqlDataReader reader = sicilCommand.ExecuteReader())
                        {
                            Sicil_cmbbox.Items.Clear(); // Mevcut öğeleri temizle

                            while (reader.Read())
                            {
                                int sicilNo = reader.GetInt32(0);
                                Sicil_cmbbox.Items.Add(sicilNo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme hatası 2: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Tuple<string, string> GetDataFromDatabase(int selectedSicilNo)
        {
            string ad = string.Empty;
            string soyad = string.Empty;

            try
            {
                using (var connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    string query = $"SELECT ad, soyad FROM personeller WHERE sicil_no = {selectedSicilNo}";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ad = reader["ad"].ToString();
                                soyad = reader["soyad"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Tuple.Create(ad, soyad);
        }

        private void Sicil_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen Sicil Numarasına göre diğer bilgileri Label'lara yazdır
            if (Sicil_cmbbox.SelectedItem != null)
            {
                int selectedSicilNo = Convert.ToInt32(Sicil_cmbbox.SelectedItem);

                try
                {
                    Tuple<string, string> result = GetDataFromDatabase(selectedSicilNo);

                    ad_lbl.Text = result.Item1;
                    Soyad_lbl.Text = result.Item2;

                    ad_lbl.Visible = true;
                    Soyad_lbl.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
              
        private void izinlerDataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < izinler_tablo.Rows.Count)
            {
                izinler_tablo.ClearSelection();
                izinler_tablo.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = izinler_tablo.Rows[e.RowIndex];

                // Seçilen satırdaki verileri al
                int selectedId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                DateTime baslangicTarihi = Convert.ToDateTime(selectedRow.Cells["izin_tarihi"].Value);
                //DateTime bitisTarihi = Convert.ToDateTime(selectedRow.Cells["bitis_tarihi"].Value);

                // DateTimePicker'lara değerleri set et
                izin_baslangic_picker.Value = baslangicTarihi;
                //izin_bitis_picker.Value = baslangicTarihi;

                // Diğer kontrolleri güncelle
                Sicil_cmbbox.Text = selectedRow.Cells["sicil_numarasi"].Value?.ToString();

                // Kontrolleri görünür yap
                ad_lbl.Visible = true;
                Soyad_lbl.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Sicil_cmbbox.Text, out int sicil))
                {
                    DateTime baslangicTarihi = izin_baslangic_picker.Value;
                    DateTime bitisTarihi = izin_bitis_picker.Value;

                    string baslangicTarihStr = baslangicTarihi.ToString("yyyy-MM-dd");
                    string bitisTarihStr = bitisTarihi.ToString("yyyy-MM-dd");

                    string isim = ad_lbl.Text;
                    string soyisim = Soyad_lbl.Text;
                    using (var connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                    {
                        connection.Open();

                        using (SqlCommand izinCommand = new SqlCommand("INSERT INTO izin_yonetimi (sicil_numarasi, izin_tarihi, bitis_tarihi, isim, soyisim) VALUES (@SicilNo, @BaslangicTarih, @BitisTarih, @Isim, @Soyisim)", connection))
                        {
                            izinCommand.Parameters.AddWithValue("@SicilNo", sicil);
                            izinCommand.Parameters.AddWithValue("@BaslangicTarih", baslangicTarihi);
                            izinCommand.Parameters.AddWithValue("@BitisTarih", baslangicTarihi);
                            izinCommand.Parameters.AddWithValue("@Isim", isim);
                            izinCommand.Parameters.AddWithValue("@Soyisim", soyisim);

                            izinCommand.ExecuteNonQuery();

                            MessageBox.Show("İzin başarıyla eklendi", "Başarılı", MessageBoxButtons.OK);
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
                // Temizleme işlemleri
                Sicil_cmbbox.Text = "";
                label1.Visible= false;
                label2.Visible= false;
                ad_lbl.Visible= false;
                Soyad_lbl.Visible= false;
                LoadData();
            }

        }

        private void ButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (izinler_tablo.SelectedRows.Count > 0)
            {
                int selectedRowIndex = izinler_tablo.SelectedRows[0].Index;
                int selectedId = Convert.ToInt32(izinler_tablo.Rows[selectedRowIndex].Cells["id"].Value);

                try
                {
                    // DateTimePicker'dan tarihleri al
                    DateTime baslangicTarihi = izin_baslangic_picker.Value;
                    DateTime bitisTarihi = izin_bitis_picker.Value;

                    // SQL sorgusu için tarihleri uygun formata çevir
                    string baslangicTarihStr = baslangicTarihi.ToString("yyyy-MM-dd");
                    string bitisTarihStr = bitisTarihi.ToString("yyyy-MM-dd");

                    // SQL sorgusunu oluştur ve çalıştır
                    using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                    {
                        connection.Open();

                        string isim = ad_lbl.Text;
                        string soyisim = Soyad_lbl.Text;

                        using (SqlCommand izinUpdateCommand = new SqlCommand("UPDATE izin_yonetimi SET izin_tarihi = @BaslangicTarih, bitis_tarihi = @BitisTarih, sicil_numarasi = @Sicil, isim = @Isim, soyisim = @Soyisim WHERE id = @Id", connection))
                        {
                            izinUpdateCommand.Parameters.AddWithValue("@Id", selectedId);
                            izinUpdateCommand.Parameters.AddWithValue("@BaslangicTarih", baslangicTarihStr);
                            izinUpdateCommand.Parameters.AddWithValue("@BitisTarih", baslangicTarihStr);
                            izinUpdateCommand.Parameters.AddWithValue("@Sicil", Sicil_cmbbox.Text);
                            izinUpdateCommand.Parameters.AddWithValue("@Isim", isim);
                            izinUpdateCommand.Parameters.AddWithValue("@Soyisim", soyisim);

                            izinUpdateCommand.ExecuteNonQuery();
                        }    
                    }

                    MessageBox.Show($"Başarıyla izin güncellendi", "Başarılı", MessageBoxButtons.OK);

                    izin_baslangic_picker.Text = "";
                    izin_bitis_picker.Text = "";
                    Sicil_cmbbox.Text = "";

                    ad_lbl.Visible = false;
                    Soyad_lbl.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;

                    izinler_tablo.ClearSelection();
                    
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSil_Click(object sender, EventArgs e)
        {
            if (izinler_tablo.SelectedRows.Count > 0)
            {
                int selectedRowIndex = izinler_tablo.SelectedRows[0].Index;
                int selectedIzinId = Convert.ToInt32(izinler_tablo.Rows[selectedRowIndex].Cells["id"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                    {
                        connection.Open();

                        // İzin kaydını sil
                        string silQuery = "DELETE FROM izin_yonetimi WHERE id = @IzinId";
                        using (SqlCommand silCommand = new SqlCommand(silQuery, connection))
                        {
                            silCommand.Parameters.AddWithValue("@IzinId", selectedIzinId);
                            silCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Başarıyla izin kaldırıldı", "Başarılı", MessageBoxButtons.OK);

                        izin_baslangic_picker.Text = "";
                        izin_bitis_picker.Text = "";
                        Sicil_cmbbox.Text = "";

                        ad_lbl.Visible = false;
                        Soyad_lbl.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;

                        izinler_tablo.ClearSelection();

                        // Tabloyu güncelle
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}