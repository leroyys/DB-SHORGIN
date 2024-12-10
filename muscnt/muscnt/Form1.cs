using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace muscnt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Connection _db;
        string id;

        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musicisp mp = new musicisp();
            mp.ShowDialog(this);
        }

        private void лейблыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ensembles en = new Ensembles();
            en.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _db = Connection.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT record_id as id, label_number as nmb, release_date, wholesale_price, retail_price, sold_last_year, sold_this_year, unsold FROM Records";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader["id"], reader["nmb"], reader["release_date"], reader["wholesale_price"], reader["retail_price"], reader["sold_last_year"], reader["sold_this_year"], reader["unsold"]);
            }


        }

        private void произведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recordings recordings = new Recordings();
            recordings.ShowDialog(this);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _db = Connection.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            id = dataGridView2.SelectedRows[0].Cells["Column5"].Value.ToString();
            string query = "SELECT record_id as id, label_number as nmb, release_date, wholesale_price, retail_price, sold_last_year, sold_this_year, unsold FROM Records WHERE record_id = @id";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string nmb = reader["nmb"].ToString();
                string rd = reader["release_date"].ToString();
                string wp = reader["wholesale_price"].ToString();
                string rp = reader["retail_price"].ToString();
                string sly = reader["sold_last_year"].ToString();
                string sty = reader["sold_this_year"].ToString();
                string un = reader["unsold"].ToString();

                textBox4.Text = nmb;
                textBox5.Text = rd;
                textBox6.Text = wp;
                textBox7.Text = rp;
                textBox1.Text = sly;
                textBox2.Text = sty;
                textBox3.Text = un;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ln = textBox4.Text;
            string rd = textBox5.Text;
            string wp = textBox6.Text;
            string rp = textBox7.Text;
            string sly = textBox1.Text;
            string sty = textBox2.Text;
            string un = textBox3.Text;

            if (string.IsNullOrEmpty(ln) || string.IsNullOrEmpty(rd) || string.IsNullOrEmpty(wp) || string.IsNullOrEmpty(rp) || string.IsNullOrEmpty(sly) || string.IsNullOrEmpty(sty) || string.IsNullOrEmpty(un))
            {
                MessageBox.Show("Заполните все обязательные поля (*)!");
            }
            else if (!Regex.IsMatch(ln, "^[A-Z0-9-]+$"))
            {
                MessageBox.Show("Заполните номер лейбла правильно!");
            }
            else if (!Regex.IsMatch(rd, "^[0-9.]+$"))
            {
                MessageBox.Show("Заполните дату релиза правильно!");
            }
            else if (!Regex.IsMatch(wp, "^[0-9.]+$"))
            {
                MessageBox.Show("Заполните поле оптовой цены правильно!");
            }
            else if (!Regex.IsMatch(rp, "^[0-9-.,]+$"))
            {
                MessageBox.Show("Заполните поле розничной цены правильно!");
            }
            else if (!Regex.IsMatch(sly, "^[0-9.,]+$"))
            {
                MessageBox.Show("Заполните поле продажи за прошлый год правильно!");
            }
            else if (!Regex.IsMatch(sly, "^[0-9.,]+$"))
            {
                MessageBox.Show("Заполните поле продажи за этот год правильно!");
            }
            else if (!Regex.IsMatch(sly, "^[0-9.,]+$"))
            {
                MessageBox.Show("Заполните поле не проданных правильно!");
            }
            else
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Records (label_number, release_date, wholesale_price, retail_price, sold_last_year, sold_this_year, unsold) \r\nVALUES (@ln, @rd, @wp, @rp, @sly, @sty, @un);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@ln", ln);
                command.Parameters.AddWithValue("@rd", rd);
                command.Parameters.AddWithValue("@wp", wp);
                command.Parameters.AddWithValue("@rp", rp);
                command.Parameters.AddWithValue("@sly", sly);
                command.Parameters.AddWithValue("@sty", sty);
                command.Parameters.AddWithValue("@un", un);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView2.SelectedRows[0].Cells["Column5"].Value.ToString();
                string sql = "DELETE FROM Records WHERE record_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                dataGridView2.Refresh();
                MessageBox.Show("Запись удалена из базы!");
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Заполните все обязательные поля (*)!");
            }
            else if (!Regex.IsMatch(textBox4.Text, "^[A-Z 0-9-]+$"))
            {
                MessageBox.Show("Заполните номер лейбла правильно!");
            }
            else if (!Regex.IsMatch(textBox5.Text, "^[0-9.]+$"))
            {
                MessageBox.Show("Заполните дату релиза правильно!");
            }
            else if (!Regex.IsMatch(textBox6.Text, "^[0-9.]+$"))
            {
                MessageBox.Show("Заполните поле оптовой цены правильно!");
            }
            else if (!Regex.IsMatch(textBox7.Text, "^[0-9-.,]+$"))
            {
                MessageBox.Show("Заполните поле розничной цены правильно!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[0-9.,]+$"))
            {
                MessageBox.Show("Заполните поле продажи за прошлый год правильно!");
            }
            else if (!Regex.IsMatch(textBox2.Text, "^[0-9.,]+$"))
            {
                MessageBox.Show("Заполните поле продажи за этот год правильно!");
            }
            else if (!Regex.IsMatch(textBox3.Text, "^[0-9.,]+$"))
            {
                MessageBox.Show("Заполните поле не проданных правильно!");
            }
            else
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Records SET label_number = @lm, release_date = @rd, wholesale_price = @wp, retail_price = @rp, sold_last_year = @sly, sold_this_year = @sty, unsold = @un WHERE record_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@lm", DbType.String).Value = textBox4.Text;
                command.Parameters.Add("@rd", DbType.String).Value = textBox5.Text;
                command.Parameters.Add("@wp", DbType.String).Value = textBox6.Text;
                command.Parameters.Add("@rp", DbType.String).Value = textBox6.Text;
                command.Parameters.Add("@sly", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@sty", DbType.String).Value = textBox2.Text;
                command.Parameters.Add("@un", DbType.String).Value = textBox3.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }
    }
}
