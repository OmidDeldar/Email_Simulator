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
    public partial class LoggedIn : Form
    {
        public string _username { get; set; }
        public string _usermail { get; set; }
        public LoggedIn(string username,string usermail)
        {
            InitializeComponent();
   
            _username = username;
            _usermail = usermail;
        }

        private void LoggedIn_Load(object sender, EventArgs e)
        {
          label1.Text=""+_username+_usermail+"";
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
            _conn.Open();
            SqlCommand _com = new SqlCommand("select [From],FromMailName,[To],ToMailName,[Subject],Compose from EmailReceive where [from]='" + _username + "' or [to]='"+ _username + "'",_conn);
            SqlDataReader _rdr = null;
            _rdr = _com.ExecuteReader();
            DataTable _dt = new DataTable();
            _dt.Load(_rdr);
            dataGridView1.DataSource = _dt;
            if (_rdr != null)
                _rdr.Close();
            if (_conn != null)
                _conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Login _log = new Login();
                _log.Show();
                Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ChangePasword _changepass = new ChangePasword(_username,_usermail);
            _changepass.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewCompose _comp = new NewCompose(_username, _usermail);
            _comp.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure", "Delete Account", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
                _conn.Open();
                SqlCommand _comm = new SqlCommand("delete from EmailReceive where [From] ='" + _username + "' or [To] ='" + _username + "'", _conn);
                
                SqlCommand _com = new SqlCommand("delete from EmailsInfo where UserName='" + _username + "'", _conn);
                _comm.ExecuteNonQuery();
                _com.ExecuteNonQuery();
                

                if (_conn != null)
                    _conn.Close();

                Login _log = new Login();
                _log.Show();
                Hide();
            }
        }
    }
}
