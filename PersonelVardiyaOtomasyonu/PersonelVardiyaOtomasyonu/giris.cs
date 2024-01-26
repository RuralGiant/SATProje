
using PersonelVardiyaOtomasyonu.Tablolar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PersonelVardiyaOtomasyonu
{
    public partial class giris: Form
    {

        public giris()
        {
            InitializeComponent();
        }

        private void girisbtn(object sender, EventArgs e)
        {
            string mail = giristxtbox.Text;
            string sifre = girissifretxtbox.Text;

            using (SqlConnection connection = new SqlConnection(DatabaseManager.Instance.GetDBInfo()))

            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM personeller WHERE mail = @mail AND sifre = @sifre", connection))
                {
                    command.Parameters.AddWithValue("@Mail", mail);
                    command.Parameters.AddWithValue("@Sifre", sifre);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Kullanıcı doğru bilgileri girdiyse
                            int personelId = Convert.ToInt32(reader["sicil_no"]);
                            string yetki = reader["kadro_turu"].ToString();
                            if (yetki == "Yönetici")
                            {
                                // Yönetici ise, yeni formu açabilirsiniz
                                menu menu = new menu();
                                menu.Show();
                                this.Hide();
                            }
                            else
                            {

                                personel_profil personelProfilForm = new personel_profil(personelId);
                                personelProfilForm.Show();
                                this.Hide();
                            }
                            giristxtbox.Clear();
                            girissifretxtbox.Clear();
                        }
                        else
                        {
                            // Kullanıcı bilgileri yanlışsa
                            MessageBox.Show("Hatalı mail veya şifre!");
                        }
                    }
                }
            }
        }

        private void cikisbtn(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
