using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniproject
{
    public partial class Form2 : Form
    {
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=BISEN\SQLEXPRESS;Initial Catalog=shubham;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x, y, z;
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;

            x = int.Parse(a);
            y = int.Parse(b);
            CheckState state = checkBox1.CheckState;
            CheckState state2 = checkBox2.CheckState;
            if (x < 1944 || x > 2013)
            {
                MessageBox.Show("please enter year between 1944 and 2013", "Error");
            }

            else
            {

                if (checkBox1.Checked == false && checkBox2.Checked == false)
                {
                    MessageBox.Show("please select male , female or both", "Error");
                }


                else
                {
                    // SqlConnection sqlConnection = new SqlConnection("Data Source=Akshant;Initial Catalog=aks;Integrated Security=True");
                    if (checkBox1.Checked == true && checkBox2.Checked == true)
                    {
                        SqlCommand sqlComman = new SqlCommand();
                        sqlComman.Connection = sqlConnection;
                        sqlConnection.Open();
                        sqlComman.CommandText = "SELECT count(*) FROM  master where year ='" + textBox1.Text + "'  ";
                        sqlComman.ExecuteNonQuery();
                        z = Convert.ToInt32(sqlComman.ExecuteScalar().ToString());
                        sqlConnection.Close();


                        if (y > z)
                        {
                            MessageBox.Show("please enter valid number in 'TOP' space  ", "Error");
                        }
                        else
                        {
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlCommand.CommandText = "select top " + textBox2.Text + " [Given Name],Amount  from master where year='" + textBox1.Text + "' order by CAST(Amount as int) desc; ";
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }

                    else if (checkBox1.Checked)
                    {
                        SqlCommand sqlComman = new SqlCommand();
                        sqlComman.Connection = sqlConnection;
                        sqlConnection.Open();
                        sqlComman.CommandText = "SELECT count(*) FROM master where year ='" + textBox1.Text + "' and category='2' ";
                        sqlComman.ExecuteNonQuery();
                        z = Convert.ToInt32(sqlComman.ExecuteScalar().ToString());
                        sqlConnection.Close();


                        if (y > z)
                        {
                            MessageBox.Show("please enter valid number in 'TOP' space  ", "Error");
                        }
                        else
                        {
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlCommand.CommandText = "SELECT top " + textBox2.Text + " [Given Name],Amount  FROM master where year ='" + textBox1.Text + "' and category='2' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                    else if (checkBox2.Checked)
                    {
                        SqlCommand sqlComman = new SqlCommand();
                        sqlComman.Connection = sqlConnection;
                        sqlConnection.Open();
                        sqlComman.CommandText = "SELECT count(*) FROM master where year ='" + textBox1.Text + "' and category='1'";
                        sqlComman.ExecuteNonQuery();
                        z = Convert.ToInt32(sqlComman.ExecuteScalar().ToString());
                        sqlConnection.Close();


                        if (y > z)
                        {
                            MessageBox.Show("please enter valid number in 'TOP' space  ", "Error");
                        }
                        else
                        {
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlCommand.CommandText = "SELECT top " + textBox2.Text + " [Given Name],Amount  FROM master where year ='" + textBox1.Text + "' and category='1' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            int i;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f3 = new Form1();
            f3.ShowDialog();
        }
    }
}
