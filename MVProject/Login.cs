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

namespace MVProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 _foform = new Form1();
            _foform.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
            _conn.Open();

            SqlCommand _comm = new SqlCommand("select * from EmailsInfo where UserName='" + txtusername.Text+ "' and MailName='" + maillbl.Text+"' and password='"+txtpassword.Text+"'", _conn);


            SqlDataReader reader = _comm.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    MessageBox.Show("'" +txtusername.Text + "' welcome.", "Login Succesfully", MessageBoxButtons.OK);
                    LoggedIn _log = new LoggedIn(txtusername.Text,maillbl.Text);
                    _log.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("User Doesen't Exist.", "Error", MessageBoxButtons.RetryCancel);
                }
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.RetryCancel);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (comboBox1.SelectedIndex == 0)
                    {
                        maillbl.Text = "@gmail.com";
                    }
                    break;
                case 1:
                    if (comboBox1.SelectedIndex == 1)
                    {
                        maillbl.Text = "@yahoo.com";
                    }

                    break;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void maillbl_Click(object sender, EventArgs e)
        {

        }
    }
}
