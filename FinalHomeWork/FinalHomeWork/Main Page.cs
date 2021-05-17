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
    public partial class Main_Page : Form
    {
        public Main_Page()
        {
            InitializeComponent();
        }
        string sql;
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\UPDATE\Documents\Visual Studio 2017\Projects\FinalHomeWork\FinalHomeWork\ProjectDatabase.mdf;Integrated Security = True");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Show();
            sql = "select * from Patients";
            cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            con.Open();
            ds.Clear();
            da.Fill(ds, "Patients");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = ds.Tables[0].ToString();
            con.Close();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel9.Hide();
        }
        DataSet dss = new DataSet();
        SqlDataAdapter daa;
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            dataGridView1.Show();
            sql = "select * from Medcine";
            cmd = new SqlCommand(sql, con);
            daa = new SqlDataAdapter(cmd);
            con.Open();
            dss.Clear();
            daa.Fill(dss, "Medcine");
            dataGridView1.DataSource = dss;
            dataGridView1.DataMember = dss.Tables[0].ToString();
            con.Close();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel9.Hide();
        }
        private void Main_Page_Load(object sender, EventArgs e){}
        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel9.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            sql = "Delete from Medcine where Meid=@did";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@did", textBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
            panel1.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel9.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            sql = "Delete from Patients where Patid=@did";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@did", textBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
            panel2.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Hide();
            panel2.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel9.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel9.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();

        }
        private void button9_Click(object sender, EventArgs e)
        {
            sql = "insert into Patients values (@pn,@pa,@pnu)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pn", textBox3.Text);
            cmd.Parameters.AddWithValue("@pa", textBox4.Text);
            cmd.Parameters.AddWithValue("@pnu", textBox5.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Added");
            panel3.Hide();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            sql = "insert into Medcine values (@dn,@dc)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@dn", textBox8.Text);
            cmd.Parameters.AddWithValue("@dc", textBox7.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Added");
            panel4.Hide();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel6.Hide();
            panel7.Hide();
            panel9.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            panel5.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            sql = "select * from Patients where Patid='" + textBox6.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                textBox9.Text = dr.GetValue(0).ToString();
                textBox10.Text = dr.GetValue(1).ToString();
                textBox11.Text = dr.GetValue(2).ToString();
                textBox12.Text = dr.GetValue(3).ToString();
            }
            con.Close();
            panel6.Show();
            panel5.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel9.Show();
            panel4.Hide();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel6.Hide();
            panel5.Hide();
            panel7.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            panel5.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            sql = "select * from Medcine where Meid='" + textBox18.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                textBox16.Text = dr.GetValue(0).ToString();
                textBox15.Text = dr.GetValue(1).ToString();
                textBox14.Text = dr.GetValue(2).ToString();
               
            }
            con.Close();
            panel7.Show();
            panel9.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel7.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel9.Hide();
            panel4.Hide();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel6.Hide();
            panel5.Hide();
            panel7.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            panel5.Hide();
        }
    }
}
