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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sql;
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\UPDATE\Documents\Visual Studio 2017\Projects\FinalHomeWork\FinalHomeWork\ProjectDatabase.mdf;Integrated Security = True");
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            panel3.Hide();
            MessageBox.Show("Contact Us At 05272632737 Or 04-6740384");
        }
        Login go = new Login();
        private void button5_Click(object sender, EventArgs e)
        {
            try { go.Show(); }
            catch {
                MessageBox.Show("Error,You Can Got To login Page Only 1 Time");
            }

            
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            dataGridView2.Show();
            dataGridView1.Hide();
            sql = "select * from Medcine";
            cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            con.Open();
            ds.Clear();
            da.Fill(ds, "Medcine");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = ds.Tables[0].ToString();
            con.Close();
        }
        DataSet dss = new DataSet();
        SqlDataAdapter daa;
        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            dataGridView2.Hide();
            dataGridView1.Show();
            sql = "select Docid,Docname,DocAdd from Doctor";
            cmd = new SqlCommand(sql, con);
            daa = new SqlDataAdapter(cmd);
            con.Open();
            dss.Clear();
            daa.Fill(dss, "Doctor");
            dataGridView1.DataSource = dss;
            dataGridView1.DataMember = dss.Tables[0].ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            panel3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sql = "insert into Appo values (@pn,@pa,@pnu,@paa,@pe)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pn", textBox3.Text);
            cmd.Parameters.AddWithValue("@pa", textBox4.Text);
            cmd.Parameters.AddWithValue("@pnu", textBox5.Text);
            cmd.Parameters.AddWithValue("@paa", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@pe", comboBox1.SelectedItem.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Added");
            panel3.Hide();
        }
    }
}
