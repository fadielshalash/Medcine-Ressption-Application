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

namespace FinalHomeWork
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string sql;
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\UPDATE\Documents\Visual Studio 2017\Projects\FinalHomeWork\FinalHomeWork\ProjectDatabase.mdf;Integrated Security = True");
        Main_Page Mainpagee = new Main_Page();
        private void button5_Click(object sender, EventArgs e)
        {
            sql = "select * from Doctor where username=@un and password=@up";
            cmd = new SqlCommand(sql, con);
            //cmd.CommandText = sql;
            //cmd.Connection = con;
            cmd.Parameters.AddWithValue("@un", textBox1.Text);
            cmd.Parameters.AddWithValue("@up", textBox2.Text);
            con.Open();
            SqlDataReader sqlread = cmd.ExecuteReader();
            while (sqlread.Read())
            {
                if (textBox1.Text == sqlread.GetValue(1).ToString() && textBox2.Text == sqlread.GetValue(2).ToString()) ;
                {
                    this.Close();
                    Mainpagee.ShowDialog();
                }
            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

        }
    }
}
