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
    public partial class EditUrlForm : Form
    {
        string fullUrl;
        string shortUrl;
        int id;

        public EditUrlForm()
        {
            InitializeComponent();

            fullUrl = "";
            id = 0;
        }

        public EditUrlForm(string fullUrl, string shortUrl, int id)
        {
            InitializeComponent();

            this.fullUrl = fullUrl;
            this.shortUrl = shortUrl;
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditUrls();
        }

        private void EditUrls()
        {
            Form1 own = (Form1)Owner;

            try
            {
                own.Conn.Open();
                int cont = Convert.ToInt32(DBMySQLUtils.ScalarUrlInfo(string.Format(@DBMySQLQuerys.SELECT_FULLURL_IF_EXIST, textBox1.Text), own.Conn));
                if (cont == 0)
                {
                    DBMySQLUtils.QuerysUrlInfo(string.Format(DBMySQLQuerys.UPDATE_URLINFO_FULLURL, textBox1.Text, id), own.Conn);
                    DBMySQLUtils.QuerysUrlInfo(string.Format(DBMySQLQuerys.UPDATE_URLINFO_SHORTURL, URLShortener.URLReplacer(shortUrl, textBox1.Text), id), own.Conn);
                    DBMySQLUtils.QuerysUrlInfo(string.Format(DBMySQLQuerys.UPDATE_URLINFO_AMOUNT_CLEAR, id), own.Conn);
                }
                else
                {
                    MessageBox.Show("This URL is already exist.", "Error " + cont, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                own.Table_Load();
                own.Conn.Close();
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error with database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStandardUrl();
            }
        }

        private void SetStandardUrl()
        {
            textBox1.Text = fullUrl;
        }

        private void EditUrlForm_Load(object sender, EventArgs e)
        {
            SetStandardUrl();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == fullUrl)
            {
                button1.Enabled = false;
            }
            else if (textBox1.Text == "")
            {
                button1.Enabled = false;
                SetStandardUrl();
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void EditUrlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }
    }
}
