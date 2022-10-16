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
    public partial class NewCompose : Form
    {
        public string _username { get; set; }
        public string _usermail { get; set; }
        public NewCompose(string username,string usermail)
        {
            InitializeComponent();
            _username = username;
            _usermail = usermail;
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

        private void NewCompose_Load(object sender, EventArgs e)
        {
            lblFrom.Text = "" + _username + _usermail + "";
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
            _conn.Open();

            SqlCommand _UserCheck = new SqlCommand("select * from EmailsInfo where UserName='" + txtTo.Text + "' and MailName='" + maillbl.Text + "'", _conn);


            SqlDataReader reader = _UserCheck.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    SqlConnection _connect = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
                    _connect.Open();

                    SqlCommand _comm = new SqlCommand("INSERT INTO EmailReceive ([From],FromMailName,[To],ToMailName,[Subject],Compose) " +
                                    "VALUES('" + _username + "','" + _usermail + "', '" + txtTo.Text + "', '" + maillbl.Text + "','" + TxtSubject.Text + "','" + TxtCompose.Text + "')", _connect);
                    _comm.ExecuteNonQuery();

                    if (_connect != null)
                        _connect.Close();
                    MessageBox.Show("Sent Succesfully!", "Done", MessageBoxButtons.OK);
                    LoggedIn _logged = new LoggedIn(_username, _usermail);
                    _logged.Show();
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
            if (_conn != null)
                _conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoggedIn _logged = new LoggedIn(_username, _usermail);
            _logged.Show();
            Hide();
        }
    }
}
