using PersonelVardiyaOtomasyonu.Tablolar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelVardiyaOtomasyonu
{
	public partial class menu : Form
	{
		public menu()
		{
			InitializeComponent();
		}

		private void personeller_Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			personel mainForm = new personel();
			mainForm.TopLevel = false;
			panel1.Controls.Add(mainForm);
			mainForm.FormBorderStyle = FormBorderStyle.None;
			mainForm.Show();	
		}

		private void vardiyalar_Click(object sender, EventArgs e)
		{
            panel1.Controls.Clear();
            vardiya mainForm = new vardiya();
			mainForm.TopLevel = false;
			panel1.Controls.Add(mainForm);
			mainForm.Show();

		}

		private void izinler_Click(object sender, EventArgs e)
		{
            panel1.Controls.Clear();		
            izinler mainForm = new izinler();
			mainForm.TopLevel = false;
			panel1.Controls.Add(mainForm);
			mainForm.Show();

		}

        private void menu_Load(object sender, EventArgs e)
        {
			vardiya vardiya = new vardiya();
			vardiya.TopLevel = false;
			panel1.Controls.Add(vardiya);
			vardiya.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            resmi_tatil mainForm = new resmi_tatil();
            mainForm.TopLevel = false;
            panel1.Controls.Add(mainForm);
            mainForm.Show();

        }

        private void mesailer_Click(object sender, EventArgs e)
        {

			
			
            panel1.Controls.Clear();
            Maaş_Bilgi mainForm = new Maaş_Bilgi();
            mainForm.TopLevel = false;
            panel1.Controls.Add(mainForm);
            mainForm.Show();
			
			
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
			Application.OpenForms[0].Visible = true;
			this.Dispose();
			this.Hide();
        }
    }
}
