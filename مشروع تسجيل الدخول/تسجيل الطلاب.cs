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
using System.IO;

namespace مشروع_تسجيل_الدخول
{
    public partial class تسجيل_الطلاب : Form
    {
        public تسجيل_الطلاب()
        {
            InitializeComponent();
        }

        private void تسجيل_الطلاب_Load(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TB_STU2", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "TB_STU2");
            dataGridView1.DataSource = ds.Tables["TB_STU2"].DefaultView;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";
            con.Open();
            if ((textBox1.Text != string.Empty) && (textBox2.Text != string.Empty) && (textBox3.Text != string.Empty) && (textBox4.Text != string.Empty)
                && (textBox5.Text != string.Empty) && (textBox6.Text != string.Empty) && (textBox7.Text != string.Empty) && (textBox8.Text != string.Empty)
               && (textBox9.Text != string.Empty) && (textBox10.Text != string.Empty))
            {
                string qur = "INSERT INTO TB_STU2 VALUES ('"
           + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'" +
           ",'" + textBox7.Text + "','" + textBox6.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Value.ToString() + "'" +
           ",'" + textBox9.Text + "','" + textBox5.Text + "','" + textBox8.Text + "')";
                SqlCommand cmd = new SqlCommand(qur, con);
                cmd.ExecuteNonQuery();
                con.Close();
                if (!Directory.Exists("img"))
                    Directory.CreateDirectory("img");
                pictureBox1.Image.Save("img/" + textBox1.Text + ".jpg");



                MessageBox.Show("تمت  اضافة الطالب ");
                pictureBox1.Image = new PictureBox().Image;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                //dateTimePicker1.Value= "";
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TB_STU2", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "TB_STU2");
                dataGridView1.DataSource = ds.Tables["TB_STU2"].DefaultView;
            }
            else
            {
                MessageBox.Show("يرجئ ملئ كافة المعلومات حرصا على اطفالكم");
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dataGridView1.CurrentRow;
            textBox1.Text = drg.Cells[1].Value.ToString();
            textBox2.Text = drg.Cells[2].Value.ToString();
            textBox3.Text = drg.Cells[3].Value.ToString();
            textBox4.Text = drg.Cells[4].Value.ToString();
            textBox7.Text = drg.Cells[5].Value.ToString();
            textBox6.Text = drg.Cells[6].Value.ToString();
            textBox10.Text = drg.Cells[7].Value.ToString();
            //dateTimePicker1 = drg.Cells[8].Value.ToString();
            textBox9.Text = drg.Cells[9].Value.ToString();
            textBox5.Text = drg.Cells[10].Value.ToString();
            textBox8.Text = drg.Cells[11].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("delete from TB_STU2 where user_name='" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show(" تم حذف الطالب من القائمة");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            //dateTimePicker1.Value= "";
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TB_STU2", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "TB_STU2");
            dataGridView1.DataSource = ds.Tables["TB_STU2"].DefaultView;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("update  TB_STU2  set user_name='" + textBox1.Text + "',name_mother='" + textBox2.Text + "',num_h='" + textBox3.Text + "',addres='" + textBox4.Text + "'" +
           ",num_phon1='" + textBox7.Text + "',num_phon2='" + textBox6.Text + "',email='" + textBox10.Text + "',age='" + dateTimePicker1.Value.ToString() + "'" +
           ",helth_st='" + textBox9.Text + "',num_hous='" + textBox5.Text + "',country='" + textBox8.Text + "'",con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show(" تم تحديث معلومات الطالب");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            //dateTimePicker1.Value= "";
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TB_STU2", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "TB_STU2");
            dataGridView1.DataSource = ds.Tables["TB_STU2"].DefaultView;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-K41B520\SQLEXPRESS;Initial Catalog=loggg;Integrated Security=True";

            SqlCommand cmd = new SqlCommand("select *from TB_STU2 where user_name like'" + textBox11.Text + "%' ", con);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Images|*.jpg;*.png;*.gif;*.bmp";
            of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                  if(of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(of.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}    

