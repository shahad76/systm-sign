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
    public partial class Form4 : Form

    {
        SqlConnection con = new SqlConnection();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM login8", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "login8");
            dataGridView1.DataSource = ds.Tables["login8"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";
            con.Open();
            if ( (textBox2.Text != string.Empty) && (textBox3.Text != string.Empty) && (textBox4.Text != string.Empty))
            {
                string qur = "INSERT INTO login8 VALUES ('"
               + textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text+"')";
                SqlCommand cmd = new SqlCommand(qur, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تمت الأضافة بنجاح");
                
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM login8", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "login8");
                dataGridView1.DataSource = ds.Tables["login8"].DefaultView;
            }
            else
            {
                MessageBox.Show("يرجى ملئ احد الحقول");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("delete from login8 where us_n='" + textBox2.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show(" تم الحذف");
            con.Close();
            //textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            con.Close();
            
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM login8", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "login8");
            dataGridView1.DataSource = ds.Tables["login8"].DefaultView;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            SqlCommand cmd = new SqlCommand("Update login8 set  us_n='" + textBox2.Text + "', la_n='" + textBox3.Text + "',pas='" + textBox4.Text + "' where us_n = '" + textBox2.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("updata your id");
           // textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM login8", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "login8");
            dataGridView1.DataSource = ds.Tables["login8"].DefaultView;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dataGridView1.CurrentRow;
            //textBox1.Text = drg.Cells[0].Value.ToString();
            textBox2.Text = drg.Cells[1].Value.ToString();
            textBox3.Text = drg.Cells[2].Value.ToString();
            textBox4.Text = drg.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            SqlCommand cmd = new SqlCommand("select *from login8 where us_n like'" + textBox5.Text + "%' ", con);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
    }

