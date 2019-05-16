using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LinkShorteningService
{
    public partial class AddUrlForm : Form
    {
        public AddUrlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 own = (Form1)Owner;

            try
            {
                own.Conn.Open();
                int cont = Convert.ToInt32(DBMySQLUtils.ScalarUrlInfo(string.Format(@DBMySQLQuerys.SELECT_FULLURL_IF_EXIST, textBox1.Text), own.Conn));
                if (cont == 0)
                {
                    string shortUrl = "";

                    do
                    {
                        shortUrl = URLShortener.URLShortening(Convert.ToInt32(DBMySQLUtils.ScalarUrlInfo(DBMySQLQuerys.SELECT_URLINFO_MAX_ID, own.Conn)));
                    } while (Convert.ToInt32(DBMySQLUtils.ScalarUrlInfo(string.Format(DBMySQLQuerys.SELECT_SHORTURL_IF_EXIST, shortUrl), own.Conn)) != 0);

                    DateTime dateValue = DateTime.Parse(DateTime.Now.ToShortDateString());
                    string date = dateValue.ToString("yyyy-MM-dd");
                    string fullUrl = URLShortener.URLDomCuter(textBox1.Text);
                    textBox2.Text = fullUrl + shortUrl;
                    DBMySQLUtils.QuerysUrlInfo(string.Format(DBMySQLQuerys.INSERT_URLINFO, textBox1.Text, textBox2.Text, date, 0), own.Conn);
                }
                else
                { 
                    MessageBox.Show("This URL is already exist.", "Error " + cont, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                own.Table_Load();
                own.Conn.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error with database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
                textBox2.Clear();
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void AddUrlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
