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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        /*public bool UserNameCheck()
        {
            string constring = "Data Source=LFC;Initial Catalog=contactmgmt;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("select count(*) from emailinfo where UserName = '" + txtusername.Text + "'", con);
            cmd.Parameters.AddWithValue("Username", this.txtusername.Text);
            con.Open();
            int TotalRows = 0;
            TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
            if (TotalRows > 0)
            {        
                return true;
            }
            else
            {
                return false;
            }
        }*/
        private void button2_Click(object sender, EventArgs e)
        {
            int BussinesCheck = 0;
            if (checkBox1.Checked == true)
                BussinesCheck = 1;

            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
            _conn.Open();

            SqlCommand _UserCheck = new SqlCommand("select * from EmailsInfo where UserName='" + txtusername.Text+"' ", _conn);


            SqlDataReader reader = _UserCheck.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    MessageBox.Show(" User Already Exist.", "Error", MessageBoxButtons.OK);
                    if (reader != null)
                        reader.Close();
                }
                else
                {
                    if (txtpassword.Text == TxtConfirmPass.Text)
                    {
                        SqlConnection _connect = new SqlConnection(@"Data Source=DESKTOP-G41SMVS\SQLEXPRESS; Initial Catalog=Email;Integrated Security=SSPI;");
                        _connect.Open();
                        /*if(UserNameCheck()==false)
                         {   */
                        SqlCommand _comm = new SqlCommand("INSERT INTO EmailsInfo " +
                            "VALUES('" + txtusername.Text + "','" + maillbl.Text + "', '" + txtfirstname.Text + "', '" + txtlastname.Text + "','" + txtpassword.Text + "','" + txtgender.Text + "'," + BussinesCheck + ")", _connect);


                        _comm.ExecuteNonQuery();

                        if (_connect != null)
                            _connect.Close();


                        MessageBox.Show("Registerd sucssecfully", "Registed", MessageBoxButtons.OK);
                        Login _log = new Login();
                        _log.Show();
                        Hide();
                        /*}
                       else
                           MessageBox.Show("Username Already exist");*/
                    }
                    else
                    {
                        MessageBox.Show("password and confirm password  not match", "error", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.RetryCancel);
            }
           
            
        }

        private void register_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtgender_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 _foform = new Form1();
            _foform.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";

            checkBox1.Checked = false;
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

        private void maillbl_Click(object sender, EventArgs e)
        {

        }
    }
}
