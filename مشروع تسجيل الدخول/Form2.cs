using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace مشروع_تسجيل_الدخول
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form4 f1 = new Form4();
            //f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            تسجيل_الطلاب f3 = new تسجيل_الطلاب();
            f3.Show();
        }
    }
}
