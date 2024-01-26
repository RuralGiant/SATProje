using PersonelVardiyaOtomasyonu.Tablolar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PersonelVardiyaOtomasyonu;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;

namespace PersonelVardiyaOtomasyonu
{
    using Excel = Microsoft.Office.Interop.Excel;
    public partial class personel_profil : Form
    {
        private DataTable _dataTable;
        private int personelId;
        private SqlConnection connection;
        private SoliteraxLibrary.SoliteraxConnection conn;
        

        public personel_profil(int personelId)
        {
            
            this.conn = new SoliteraxLibrary.SoliteraxConnection(SoliteraxLibrary.SoliteraxConnection.ConnectionType.SQL);
            conn.Connect(DatabaseManager.Instance.GetDBInfo());
            InitializeComponent();
            this.personelId = personelId;
            LoadPersonelInfo();
            WritePersonelInfo();
            ((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).DisConnect();
        }

        private void WritePersonelInfo()
        {
            DataTable dt = (DataTable)personel_bilgi_tablosu.DataSource;
            DataTable dt2 = (DataTable)((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).GetManager().GetData($"select * from personeller where sicil_no = '{dt.Rows[0][1]}'");
            label2.Text = "Ad Soyad: " + dt2.Rows[0][1].ToString()+ " " + dt2.Rows[0][2].ToString();
            

            label3.Text = "Yıllık İzin: " + double.Parse(((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).GetManager().GetSingleData($"select mesai_saat from mesailer where sicil_no = '{dt.Rows[0][1]}'").ToString()) / 24 + " Gün";
           
        }

        private void LoadPersonelInfo()
        {
            _dataTable = ((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).GetManager().GetData($"select * from vardiya_kayit where Sicil_No='{personelId.ToString()}'");
            personel_bilgi_tablosu.DataSource = _dataTable;
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            giris giris= new giris();
            giris.Show();
            this.Close();
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

                    // DataTable'daki verileri CSV dosyasına kaydedin
                    ExportDataTableToExcel(_dataTable, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void ExportDataTableToExcel(DataTable dataTable, string filePath)
        {
            // Excel uygulamasını başlat
            Excel.Application excelApp = new Excel.Application();

            // Yeni bir Excel çalışma kitabı oluştur
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            // Aktif çalışma sayfasını seç
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // Verileri hücrelere yaz
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    worksheet.Cells[i + 1, j + 1] = dataTable.Rows[i][j].ToString();
                }
            }

            // Excel dosyasını kaydet
            workbook.SaveAs(filePath);

            // Excel uygulamasını kapat
            excelApp.Quit();
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
                // CultureInfo ile sayı formatını Türkçe'ye uygun şekilde belirledik
                CultureInfo.CurrentCulture = new CultureInfo("tr-TR");

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8); // Türkçe karakterleri doğru bir şekilde korumak için Encoding.UTF8 ekledik
                MessageBox.Show("DataTable verileri başarıyla CSV dosyasına kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"İzin hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void personel_profil_Load(object sender, EventArgs e)
        {

        }

        private void personel_profil_Load_1(object sender, EventArgs e)
        {

        }

        private void personel_profil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Visible = true;
            this.Dispose();
            this.Close();
            GC.Collect();
        }
    }
}
