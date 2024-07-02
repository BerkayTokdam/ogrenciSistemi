using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text== "admin" && maskedTextBox2.Text=="12345")
            {
                Form2 git = new Form2();
                this.Hide();
                git.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı !!! Lütfen tekrar deneyiniz!");
                textBox1.Clear();
                maskedTextBox2.Clear();
            }
        }
    }
}
