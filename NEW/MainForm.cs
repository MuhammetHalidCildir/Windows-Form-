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
using System.Data.Entity;

namespace NEW
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                NorthwindContext.Connection.Open();
                string sql = "Select * From Password where Name=@Name AND Password=@Password";
                SqlParameter prm1 = new SqlParameter("Name", txtUserName.Text.Trim());
                SqlParameter prm2 = new SqlParameter("Password", txtPassword.Text.Trim());
                SqlCommand command = new SqlCommand(sql, NorthwindContext.Connection);
                command.Parameters.Add(prm1);
                command.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form1 mf = new Form1();
                    mf.Show();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("You entered an incorrect username or password!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
