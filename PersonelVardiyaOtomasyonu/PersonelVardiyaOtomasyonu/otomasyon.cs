using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using PersonelVardiyaOtomasyonu.Tablolar;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics.Eventing.Reader;

namespace PersonelVardiyaOtomasyonu
{
    public partial class otomasyon : Form
    {

        private SqlConnection connection;

        public otomasyon()
        {
            InitializeComponent();
            connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo());
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            //kapüs adında dış vardiya saatlerini tutacak liste oluşturuluyor
            List<string> kampüs = new List<string>();
            kampüs.Add("00:00-08:00");
            kampüs.Add("08:00-16:00");
            kampüs.Add("16:00-24:00");

            //kampüs2 adında iç vardiya bilgilerini tutacak liste oluşturuluyor
            List<string> kampüs2 = new List<string>();
            kampüs2.Add("08:00-16:00");
            kampüs2.Add("09:00-17:00");


            //datetimepicker içerisinde bulunan string veriler datetime formatını çevirilip değişkenlere aktarılıyor
            DateTime baslangictarihi = DateTime.Parse(vardiya_baslangic_picker.Text);
            DateTime bitistarihi = DateTime.Parse(vardiya_bitis_picker.Text);


            string sqlCommand = "SELECT sicil_no FROM personeller WHERE kadro_turu != 'Yönetici'";
            List<int> sicillistesi;

            using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        sicillistesi = new List<int>();

                        while (reader.Read())
                        {
                            int sicilNo = Convert.ToInt32(reader["sicil_no"]);
                            sicillistesi.Add(sicilNo);
                        }
                    }
                }
            }




            //for döngüsü için sisteme girilen günler hesaplanırken kullanılacak değer oluşturuluyor
            TimeSpan gfarkt = bitistarihi - baslangictarihi;
            int gunfarki = gfarkt.Days;


            //her gün için 1 defa dönüyor
            for (int i = 0; i <= gunfarki; i++)
            {
                //başlangıç tarihine 1 ekliyor
                DateTime Days = baslangictarihi.AddDays(i);
                var kampusIciVardiyaCount = 0;
                var kampusDisiVardiyaCount = 2;
                var vardiyaA = 0;
                var vardiyaB = 0;
                var vardiyaC = 0;
                var vardiyaD = 0;
                var vardiyaE = 0;

                //personel kontrol ediyor varmı yokmu
                if (!sicillistesi.Any())
                    break;
                 //personelleri foreach ile tek tek döndürüyor
                foreach (int sicil in sicillistesi)
                {
                        if (ozelgünsorgualama(Days))
                        {
                            if (IzinYonetimiKontrol(sicil, Days, Days))  // Burada başlangıç ve bitiş tarihi aynı kullanılmıştır, ihtiyaca göre değiştirilebilir.
                            {
                                //izin memur ve işçinin default izin günlerine bakıp dönüyo
                                if (izinsorgulama(sicil, Days))
                                {

                                    string saat = " ";
                                    if ((kampusIciVardiyaCount / 3) < (kampusDisiVardiyaCount / 2))
                                    {

                                        kampusIciVardiyaCount++;
                                        string bölge = "Kampüs Disi";

                                        int enKucukVardiye = Math.Min(vardiyaA, Math.Min(vardiyaB, vardiyaC));

                                        if (enKucukVardiye == vardiyaA)
                                        {
                                            vardiyaA++;
                                            saat = kampüs[0];
                                        }
                                        else if (enKucukVardiye == vardiyaB)
                                        {
                                            vardiyaB++;
                                            saat = kampüs[1];
                                        }
                                        else if (enKucukVardiye == vardiyaC)
                                        {
                                            vardiyaC++;
                                            saat = kampüs[2];
                                        }


                                        try
                                        {
                                            using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                                            {
                                                connection.Open();

                                                // Personel bilgilerini çekmek için SQL sorgusu
                                                string selectPersonQuery = "SELECT * FROM personeller WHERE sicil_no = @SicilNo";

                                                using (SqlCommand selectPersonCommand = new SqlCommand(selectPersonQuery, connection))
                                                {
                                                    selectPersonCommand.Parameters.AddWithValue("@SicilNo", sicil);

                                                    using (SqlDataReader personReader = selectPersonCommand.ExecuteReader())
                                                    {
                                                        if (personReader.Read())
                                                        {
                                                            string isim = personReader["ad"].ToString();
                                                            string soyisim = personReader["soyad"].ToString();

                                                            personReader.Close();
                                                            // Yeni vardiya kaydını eklemek için SQL sorgusu
                                                            string insertQuery = "INSERT INTO vardiya_kayit (Sicil_No, isim, soyisim, Gün_Bilgisi, Saat_Bilgisi, Gorev_Bolgesi) " +
                                                                                 "VALUES (@SicilNo, @Isim, @Soyisim, @GunBilgisi, @SaatBilgisi, @GorevBolgesi)";

                                                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                                            {
                                                                insertCommand.Parameters.AddWithValue("@SicilNo", sicil);
                                                                insertCommand.Parameters.AddWithValue("@Isim", isim);
                                                                insertCommand.Parameters.AddWithValue("@Soyisim", soyisim);
                                                                insertCommand.Parameters.AddWithValue("@GunBilgisi", Days);
                                                                insertCommand.Parameters.AddWithValue("@SaatBilgisi", saat);
                                                                insertCommand.Parameters.AddWithValue("@GorevBolgesi", bölge);

                                                                insertCommand.ExecuteNonQuery();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Sicil numarasına uygun personel bulunamadı.");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            // Hata durumunda gerekli işlemleri yapabilirsiniz.
                                            MessageBox.Show("Hata oluştu: " + ex.Message);
                                        }

                                    }
                                    else
                                    {
                                        kampusDisiVardiyaCount++;
                                        string bölge = "Kampüs İci";
                                        if (vardiyaD < vardiyaE)
                                        {
                                            vardiyaD++;
                                            saat = kampüs2[0];
                                        }
                                        else
                                        {
                                            vardiyaE++;
                                            saat = kampüs2[1];
                                        }


                                        try
                                        {
                                            using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                                            {

                                                connection.Open();

                                                string insertQuery = "INSERT INTO vardiya_kayit (Sicil_No, isim, soyisim, Gün_Bilgisi, Saat_Bilgisi, Gorev_Bolgesi) " +
                                                                     "VALUES (@SicilNo, (SELECT TOP 1 ad FROM personeller WHERE sicil_no = @SicilNo), " +
                                                                     "(SELECT TOP 1 soyad FROM personeller WHERE sicil_no = @SicilNo), @GunBilgisi, @SaatBilgisi, @GorevBolgesi)";

                                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                                {
                                                    insertCommand.Parameters.AddWithValue("@SicilNo", sicil);
                                                    insertCommand.Parameters.AddWithValue("@GunBilgisi", Days);
                                                    insertCommand.Parameters.AddWithValue("@SaatBilgisi", saat);
                                                    insertCommand.Parameters.AddWithValue("@GorevBolgesi", bölge);

                                                    insertCommand.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Hata oluştu: " + ex.Message);
                                        }
                                    }
                                }
                            }
                        } 
                    else
                    {
                        if (IzinYonetimiKontrol(sicil, Days, Days))  // Burada başlangıç ve bitiş tarihi aynı kullanılmıştır, ihtiyaca göre değiştirilebilir.
                        {
                            //izin memur ve işçinin default izin günlerine bakıp dönüyor 
                            if (izinsorgulama(sicil, Days))
                            {

                                string saat = " ";
                                if ((kampusIciVardiyaCount / 3) < (kampusDisiVardiyaCount / 2))
                                {

                                    kampusIciVardiyaCount++;
                                    string bölge = "Kampüs Disi";

                                    int enKucukVardiye = Math.Min(vardiyaA, Math.Min(vardiyaB, vardiyaC));

                                    if (enKucukVardiye == vardiyaA)
                                    {
                                        vardiyaA++;
                                        saat = kampüs[0];
                                    }
                                    else if (enKucukVardiye == vardiyaB)
                                    {
                                        vardiyaB++;
                                        saat = kampüs[1];
                                    }
                                    else if (enKucukVardiye == vardiyaC)
                                    {
                                        vardiyaC++;
                                        saat = kampüs[2];
                                    }

                                   
                                    try
                                    {
                                        using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                                        {
                                            connection.Open();

                                            // Personel bilgilerini çekmek için SQL sorgusu
                                            string selectPersonQuery = "SELECT * FROM personeller WHERE sicil_no = @SicilNo";

                                            using (SqlCommand selectPersonCommand = new SqlCommand(selectPersonQuery, connection))
                                            {
                                                selectPersonCommand.Parameters.AddWithValue("@SicilNo", sicil);

                                                using (SqlDataReader personReader = selectPersonCommand.ExecuteReader())
                                                {
                                                    if (personReader.Read())
                                                    {
                                                        string isim = personReader["ad"].ToString();
                                                        string soyisim = personReader["soyad"].ToString();

                                                        personReader.Close();
                                                        // Yeni vardiya kaydını eklemek için SQL sorgusu
                                                        string insertQuery = "INSERT INTO vardiya_kayit (Sicil_No, isim, soyisim, Gün_Bilgisi, Saat_Bilgisi, Gorev_Bolgesi) " +
                                                                             "VALUES (@SicilNo, @Isim, @Soyisim, @GunBilgisi, @SaatBilgisi, @GorevBolgesi)";

                                                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                                        {
                                                            insertCommand.Parameters.AddWithValue("@SicilNo", sicil);
                                                            insertCommand.Parameters.AddWithValue("@Isim", isim);
                                                            insertCommand.Parameters.AddWithValue("@Soyisim", soyisim);
                                                            insertCommand.Parameters.AddWithValue("@GunBilgisi", Days);
                                                            insertCommand.Parameters.AddWithValue("@SaatBilgisi", saat);
                                                            insertCommand.Parameters.AddWithValue("@GorevBolgesi", bölge);

                                                            insertCommand.ExecuteNonQuery();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Sicil numarasına uygun personel bulunamadı.");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // Hata durumunda gerekli işlemleri yapabilirsiniz.
                                        MessageBox.Show("Hata oluştu: " + ex.Message);
                                    }
                                }
                            }
                        }
                    }  
                }
            }

            #region Mesai Hesaplamaları

            SoliteraxLibrary.SoliteraxConnection conn = new SoliteraxLibrary.SoliteraxConnection(SoliteraxLibrary.SoliteraxConnection.ConnectionType.SQL);
            conn.Connect(DatabaseManager.Instance.GetDBInfo());
            SoliteraxLibrary.SQLSystem.DatabaseManager db = ((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).GetManager();
            DataTable dt = db.GetData("select sicil_no from personeller");
            foreach (DataRow row in dt.Rows)
            {
                DataTable personeller = db.GetData($"select * from personeller where sicil_no = '{row[0]}'");
        
                int totalGun = int.Parse(db.GetSingleData("select COUNT(Sicil_No) from vardiya_kayit where Sicil_No='" + row[0].ToString() + "'").ToString());
                int mesaiGun = 0;
                if (personeller.Rows[0][4].ToString().ToLower().Equals("işçi"))
                    mesaiGun = totalGun * 8 - (totalGun / 6 * 45);
                else if (personeller.Rows[0][4].ToString().ToLower().Equals("memur"))
                    mesaiGun = totalGun * 8 - (totalGun / 5 * 40);
                else
                    mesaiGun = 0;
                DataTable mesaiTable = db.GetData("select * from mesailer where Sicil_No = '" + row[0].ToString() + "'");
                if (mesaiTable.Rows.Count < 1)
                {
                    db.SendData($"insert into mesailer(sicil_no, mesai_saat) values ('{row[0].ToString()}', '{mesaiGun}')");
                    continue;
                }
                mesaiGun += int.Parse(mesaiTable.Rows[2].ToString());
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("kayıtlı gün: " + mesaiGun + Environment.NewLine + "TotalGün: " + totalGun);
                Console.WriteLine("------------------------------------------------");
                db.SendData($"delete from mesailer where sicil_no = '{row[0]}'");
                db.SendData($"insert into mesailer(sicil_no, mesai_saat) values ('{row[0]}', '{mesaiGun}')");
            }
            ((SoliteraxLibrary.SQLSystem.ConnectDatabase)conn.GetConnection()).DisConnect();
            #endregion
            MessageBox.Show("Vardiye Oluşturuldu");

        }

        public bool IzinYonetimiKontrol(int personelSicil, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    // İzinler tablosunda izin var mı, count olarak bakıyor
                    string izinSorgusu = "SELECT COUNT(*) FROM izin_yonetimi WHERE sicil_numarasi = @PersonelSicil AND izin_tarihi = @BaslangicTarihi";
                    using (SqlCommand izinCommand = new SqlCommand(izinSorgusu, connection))
                    {
                        izinCommand.Parameters.AddWithValue("@PersonelSicil", personelSicil);
                        izinCommand.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
                        //izinCommand.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);

                        int izinSayisi = Convert.ToInt32(izinCommand.ExecuteScalar());

                        // İzin varsa false döner, yoksa true döner
                        return izinSayisi == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public List<int> getSicilList()
        {
            List<int> personel_sicil = new List<int>();
            MessageBox.Show("Sicil Numaraları: " + string.Join(", ", personel_sicil));

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    string query = "SELECT sicil_no FROM personeller";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int sicilNo = Convert.ToInt32(reader["sicil_no"]);
                                personel_sicil.Add(sicilNo);
                                reader.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return personel_sicil;
        }

        public bool izinsorgulama(int sicil_no, DateTime tarih)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    // İzinler tablosunda izni var mı, count olarak bakıyor
                    string izinSorgusu = "SELECT COUNT(*) FROM izinler_tablosu WHERE personel_sicil = @SicilNo AND izin_baslangic_tarihi = @Tarih";

                    using (SqlCommand izinCommand = new SqlCommand(izinSorgusu, connection))
                    {
                        izinCommand.Parameters.AddWithValue("@SicilNo", sicil_no);
                        izinCommand.Parameters.AddWithValue("@Tarih", tarih);

                        int izinSayisi = Convert.ToInt32(izinCommand.ExecuteScalar());

                        // İzni yoksa çalışıyor
                        if (izinSayisi == 0)
                        {
                            // Vardiya kayıt tablosunda bu personelin kaç vardiyası var
                            string vardiyaSorgusu = "SELECT COUNT(*) FROM vardiya_kayit WHERE Sicil_No = @SicilNo AND Gün_Bilgisi = @Tarih";

                            using (SqlCommand vardiyaCommand = new SqlCommand(vardiyaSorgusu, connection))
                            {
                                vardiyaCommand.Parameters.AddWithValue("@SicilNo", sicil_no);
                                vardiyaCommand.Parameters.AddWithValue("@Tarih", tarih);

                                int vardiyaSayisi = Convert.ToInt32(vardiyaCommand.ExecuteScalar());

                                // O gün vardiyası yoksa çalışır
                                if (vardiyaSayisi == 0)
                                {
                                    string gunAdi = tarih.ToString("dddd", CultureInfo.GetCultureInfo("tr-TR"));

                                    // Personel izin gün 1 ve gün 2 sorguları
                                    string izinGünSorgusu = "SELECT COUNT(*) FROM personeller WHERE sicil_no = @SicilNo AND (izin_1 = @GunAdi OR izin_2 = @GunAdi)";

                                    using (SqlCommand izinGünCommand = new SqlCommand(izinGünSorgusu, connection))
                                    {
                                        izinGünCommand.Parameters.AddWithValue("@SicilNo", sicil_no);
                                        izinGünCommand.Parameters.AddWithValue("@GunAdi", gunAdi);

                                        int izinGünSayisi = Convert.ToInt32(izinGünCommand.ExecuteScalar());

                                        if (izinGünSayisi == 0)
                                        {
                                            return true; // İzin ve vardiya yok, izin günleri de belirlenmemişse true döner
                                        }
                                        else
                                        {
                                            return false;
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
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public bool ozelgünsorgualama(DateTime tarih)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))
                {
                    connection.Open();

                    // Özel günler tablosunda o tarih var mı, count olarak bakıyor
                    string ozelGunSorgusu = "SELECT COUNT(*) FROM OzelGunler WHERE Tarih = @Tarih";

                    using (SqlCommand ozelGunCommand = new SqlCommand(ozelGunSorgusu, connection))
                    {
                        ozelGunCommand.Parameters.AddWithValue("@Tarih", tarih);

                        int ozelGunSayisi = Convert.ToInt32(ozelGunCommand.ExecuteScalar());

                        // Eğer ozelGunSayisi 0'dan büyükse, o tarih OzelGunler tablosu'nda bulunmaktadır.
                        return ozelGunSayisi == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void ButtonSil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}