using PersonelVardiyaOtomasyonu.Tablolar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;


namespace PersonelVardiyaOtomasyonu
{ 

    public partial class resmi_tatil : Form
    {


        public resmi_tatil()
        {
            InitializeComponent();
            RefreshDataGridView();
            LoadData();
        }
        
        public void LoadData()
        {
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns["ID"].Visible = false;
            }
        }



        private void ekle_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                {
                    connection.Open();

                    // OzelGunler tablosuna ekleme yap
                    string ekleQuery = "INSERT INTO OzelGunler (Ozel_gun_adı, Tarih) VALUES (@OzelGunAdi, @Tarih)";
                    using (SqlCommand ekleCommand = new SqlCommand(ekleQuery, connection))
                    {
                        ekleCommand.Parameters.AddWithValue("@OzelGunAdi", textBox1.Text);
                        ekleCommand.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
                        ekleCommand.ExecuteNonQuery();
                    }

                    RefreshDataGridView();
                }

                MessageBox.Show("Başarıyla Gün eklendi", "Başarılı", MessageBoxButtons.OK);

                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                {
                    connection.Open();

                    // OzelGunler tablosundaki tüm verileri getir
                    string selectQuery = "SELECT * FROM OzelGunler";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // DataGridView'e verileri doldur
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sil_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int selectedIzinId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True"))
                    {
                        connection.Open();

                        // OzelGunler tablosundan seçilen ID'ye sahip veriyi sil
                        string deleteQuery = $"DELETE FROM OzelGunler WHERE ID = {selectedIzinId}";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.ExecuteNonQuery();
                        }

                        RefreshDataGridView();

                        MessageBox.Show("Başarıyla Tatil kaldırıldı", "Başarılı", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // ID sütununun indeksini kontrol et
                int idColumnIndex = dataGridView1.Columns["ID"].Index;

                if (selectedRow.Cells.Count > idColumnIndex)
                {
                    // ID değerini al
                    int selectedId = Convert.ToInt32(selectedRow.Cells[idColumnIndex].Value);

                    // Burada ID değerini kullanabilirsiniz
                    MessageBox.Show($"Seçilen ID: {selectedId}");

                    string ad = selectedRow.Cells["Ozel_gun_adı"].Value?.ToString();
                    textBox1.Text = ad;

                    // Hücre içeriğine tıklandığında seçimi günceller
                    if (!selectedRow.Selected)
                    {
                        // Sadece seçili değilse işlem yap
                        dataGridView1.ClearSelection();
                        selectedRow.Selected = true;
                    }
                }
            }
        }




    }
}
