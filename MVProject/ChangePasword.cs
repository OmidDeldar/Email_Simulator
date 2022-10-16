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
    public partial class ChangePasword : Form
    {
        public string _username { get; set; }
        public string _usermail { get; set; }
        public ChangePasword(string username, string usermail)
        {
            InitializeComponent();
            _username = username;
            _usermail = usermail;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            LoggedIn _logged = new LoggedIn(_username,_usermail);
            _logged.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection _connect = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
            _connect.Open();

            SqlCommand _UserCheck = new SqlCommand("select * from EmailsInfo where UserName='" + _username + "'and [Password]='" + txtoldpass.Text + "'", _connect);


            SqlDataReader reader = _UserCheck.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
                    _conn.Open();

                    if (txtnewpass.Text == txtconfpass.Text)
                    {
                        SqlCommand _com = new SqlCommand("update  EmailsInfo set [Password]='" + txtnewpass.Text + "' where UserName='" + _username + "' ", _conn);
                        _com.ExecuteNonQuery();

                        if (_conn != null)
                            _conn.Close();


                        MessageBox.Show("Password Change  sucssecfully", "Succesfull", MessageBoxButtons.OK);
                        Login _log = new Login();
                        _log.Show();
                        Hide();

                    }
                    else
                    {
                        MessageBox.Show("password and confirm password  not match", "error", MessageBoxButtons.OK);
                    }
                }
                else
                    MessageBox.Show("Invalid Old Password.", "Error", MessageBoxButtons.RetryCancel);
            }
            else
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.RetryCancel);




        }

        private void ChangePasword_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                txtnewpass.PasswordChar = '\0';
                txtconfpass.PasswordChar = '\0';
                txtoldpass.PasswordChar = '\0';
            }
            else
            {
                txtnewpass.PasswordChar = '*';
                txtconfpass.PasswordChar = '*';
                txtoldpass.PasswordChar = '*';
            }
            
        }
    }
}
