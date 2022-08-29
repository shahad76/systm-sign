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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM info", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "info");
            dataGridView2.DataSource = ds.Tables["info"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";
            con.Open();
            if ((textBox1.Text != string.Empty) && (textBox2.Text != string.Empty) && (textBox3.Text != string.Empty))
            {
                string qur = "INSERT INTO info VALUES ('" + textBox1.Text + "','"
               + textBox2.Text + "','" + textBox3.Text + "')";
                SqlCommand cmd = new SqlCommand(qur, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تمت الأضافة بنجاح");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM info", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "info");
                dataGridView2.DataSource = ds.Tables["info"].DefaultView;
            }
            else
            {
                MessageBox.Show("يرجى ملئ احد الحقول");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow drg = dataGridView2.CurrentRow;
            textBox1.Text = drg.Cells[0].Value.ToString();
            textBox2.Text = drg.Cells[1].Value.ToString();
            textBox3.Text = drg.Cells[2].Value.ToString();


        }

        private void label1_Click(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)

        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";
           
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("delete from info where username='" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show(" تم الحذف");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            con.Close();
            con.Close();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM infoo", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "info");
            dataGridView2.DataSource = ds.Tables["info"].DefaultView;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Update info set  username = '" + textBox1.Text + "', password='" + textBox2.Text + "', email='" + textBox3.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("تم التعديل");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM info", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "info");
            dataGridView2.DataSource = ds.Tables["infoo"].DefaultView;


            con.Close();
        }
    }


}

