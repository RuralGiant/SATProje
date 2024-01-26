using PersonelVardiyaOtomasyonu.Tablolar;
using SoliteraxLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelVardiyaOtomasyonu
{
    public partial class Maaş_Bilgi : Form
    {
        public Maaş_Bilgi()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            SoliteraxConnection conn = new SoliteraxConnection(SoliteraxConnection.ConnectionType.SQL);
            conn.Connect(DatabaseManager.Instance.GetDBInfo());
            SoliteraxLibrary.SQLSystem.DatabaseManager db = ((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).GetManager();
            dataGridView1.DataSource = db.GetData("select p.sicil_no as 'Sicil_No', p.ad, p.soyad, p.kadro_turu, m.mesai_saat as 'Mesai Saati' from mesailer as m, personeller as p where m.sicil_no = p.sicil_no");
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

        private void Maaş_Bilgi_Load(object sender, EventArgs e)
        {

        }
    }
}
