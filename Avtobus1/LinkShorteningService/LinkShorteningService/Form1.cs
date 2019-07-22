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
    public partial class Form1 : Form
    {
        MySqlConnection conn;

        public MySqlConnection Conn
        {
            get { return conn; }
        }

        public Form1()
        {
            InitializeComponent();

            conn = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
                Table_Load();
                conn.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error to connect to database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Table_Load()
        {
            MySqlDataAdapter adap = new MySqlDataAdapter(DBMySQLQuerys.SELECT_URLINFO, conn);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            //dataGridView1.Columns["id"].Visible = false;
        }

        private void DeleteUrlInfo()
        {
            DBMySQLUtils.DeleteUrlInfo(DBMySQLQuerys.DELETE_URLINFO_ROW, conn, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value));
        }

        private void OpenShortUrl(string fullUrl)
        {
            string target = fullUrl;

            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch
                (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                DeleteUrlInfo();
                Table_Load();
                conn.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error to connect to database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = contextMenuStrip1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddUrlForm().ShowDialog(this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["shorturl"].Index)
            {
                OpenShortUrl(dataGridView1.Rows[e.RowIndex].Cells["fullurl"].Value.ToString());
                try
                {
                    conn.Open();
                    DBMySQLUtils.QuerysUrlInfo(string.Format(DBMySQLQuerys.UPDATE_URLINFO_AMOUNT, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value)), Conn);
                    Table_Load();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error to connect to database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EditUrlForm(dataGridView1.SelectedRows[0].Cells["fullurl"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["shorturl"].Value.ToString(), Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value)).ShowDialog(this);
        }
    }
}
