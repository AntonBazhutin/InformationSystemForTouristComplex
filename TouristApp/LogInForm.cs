using AppIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouristApp
{
    public partial class LogInForm : Form
    {
        private Tourist personalInfo;
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю";
        private SqlConnection sqlcon;
        private const string connectionString = @"Data Source=АНТОН-ПК;Initial Catalog=TouristComplex;Integrated Security=True;";

        public LogInForm()
        {
            InitializeComponent();
        }
        private void LogInForm_Load(object sender, EventArgs e)
        {
            labelWarning.Visible = false;
        }

        private void btnLogIn_Click_1(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = connectionString;
            try
            {
                sqlcon.Open();
                if (txtBxLogin.Text != string.Empty && txtBxPassword.Text != string.Empty)
                {
                    labelWarning.Visible = false;

                    if (txtBxLogin.ForeColor != Color.Red && txtBxPassword.ForeColor != Color.Red)
                    {
                        var cmd = new SqlCommand("Select * from Tourists where login=@login AND password=@password", sqlcon);
                        cmd.Parameters.AddWithValue("@login", txtBxLogin.Text);
                        cmd.Parameters.AddWithValue("@password", txtBxPassword.Text);
                        cmd.ExecuteNonQuery();

                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                personalInfo = new Tourist(dr["login"].ToString(), dr["password"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(), dr["email"].ToString(),
                                    dr["dateOfComing"].ToString(), dr["dateOfLeaving"].ToString(), dr["country"].ToString(), int.Parse(dr["room_id"].ToString()));
                            }
                        }

                        if (personalInfo == null)
                            MessageBox.Show("Неправильный логин или пароль");
                        else
                        {
                            this.Hide();
                            TouristForm1 mf = new TouristForm1(personalInfo);
                            mf.ShowDialog();
                            this.Dispose();
                            this.Close();
                        }
                    }
                }
                else
                {
                    labelWarning.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBxPassword_TextChanged_1(object sender, EventArgs e)
        {
            int counter = 0;
            for (int i = 0; i < txtBxPassword.Text.Length; i++)
            {
                if (safeString.Contains(txtBxPassword.Text[i]))
                    counter++;
            }
            if (counter != txtBxPassword.Text.Length)
            {
                txtBxPassword.ForeColor = Color.Red;
            }
            else
            {
                txtBxPassword.ForeColor = Color.Black;
            }
        }

        private void txtBxLogin_TextChanged(object sender, EventArgs e)
        {
            int counter = 0;
            for (int i = 0; i < txtBxLogin.Text.Length; i++)
            {
                if (safeString.Contains(txtBxLogin.Text[i]))
                    counter++;
            }
            if (counter != txtBxLogin.Text.Length)
            {
                txtBxLogin.ForeColor = Color.Red;
            }
            else
            {
                txtBxLogin.ForeColor = Color.Black;
            }
        }
    }
}
