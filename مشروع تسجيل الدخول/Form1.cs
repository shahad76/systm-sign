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


namespace مشروع_تسجيل_الدخول
{
    public partial class Form1 : Form
    { 

        SqlConnection con = new SqlConnection();
        SqlCommand myCommand = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            con.Open();
            SqlCommand cmd = new SqlCommand("select* from login where username='" + textBox1.Text + "' and  password='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(" مرحبا بك ");
                Form2 f2 = new Form2();
                f2.Show();


            }
            else
            {
                MessageBox.Show(" اسم المستخدم خطأ او كلمة السر غير مطابقة");


            }
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
