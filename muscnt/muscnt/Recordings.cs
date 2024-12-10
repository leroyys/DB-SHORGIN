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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace muscnt
{
    public partial class Recordings : Form
    {
        public Recordings()
        {
            InitializeComponent();
        }

        private Connection _db;
        string id;

        private void Recordings_Load(object sender, EventArgs e)
        {
            _db = Connection.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT \r\n    Recordings.recording_id as id, \r\n    MusicalWorks.title as pro, \r\n    Musicians.name AS musician_name, \r\n    Recordings.performance_date as date \r\nFROM \r\n    Recordings\r\nJOIN \r\n    MusicalWorks ON Recordings.work_id = MusicalWorks.work_id\r\nJOIN \r\n    Musicians ON Recordings.musician_id = Musicians.musician_id;";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["id"], reader["pro"], reader["musician_name"], reader["date"]);
            }

            _db = Connection.GetInstance();
            SQLiteConnection conn3 = _db.GetConnection();
            string query3 = "SELECT DISTINCT name \r\nFROM Musicians \r\nWHERE role = 'композитор';";
            SQLiteCommand cmd3 = new SQLiteCommand(query3, conn3);
            SQLiteDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string data = reader3.GetString(0);
                comboBox2.Items.Add(data);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pr = textBox2.Text;
            string mus = comboBox2.Text;
            string dt = textBox1.Text;

            if (string.IsNullOrEmpty(pr) || string.IsNullOrEmpty(mus) || string.IsNullOrEmpty(dt))
            {
                MessageBox.Show("Заполните все обязательные поля (*)!");
            }
            else if (!Regex.IsMatch(pr, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните поле Произведение правильно!");
            }
            else if (!Regex.IsMatch(mus, "^[а-яА-Я№ -]+$"))
            {
                MessageBox.Show("Заполните поле Музыканта правильно!");
            }
            else if (!Regex.IsMatch(dt, "^[0-9.]+$"))
            {
                MessageBox.Show("Заполните поле Даты релиза правильно!");
            }
            else
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();

                
                string query = "INSERT INTO MusicalWorks (title, composer_id) VALUES (@pr, (SELECT musician_id FROM Musicians WHERE name = @mus));";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@pr", pr);
                command.Parameters.AddWithValue("@mus", mus);
                command.ExecuteNonQuery();
            
                string qwr = "SELECT work_id FROM MusicalWorks ORDER BY work_id DESC LIMIT 1;";
                SQLiteCommand commandSelect = new SQLiteCommand(qwr, conn);
                commandSelect.ExecuteNonQuery();

                object result = commandSelect.ExecuteScalar();
                int lastWorkId = result != null ? Convert.ToInt32(result) : -1; 

                string qwrr = "INSERT INTO Recordings (work_id, musician_id, performance_date)\r\nVALUES (@lw, \r\n    (SELECT composer_id FROM MusicalWorks WHERE work_id = @lw), \r\n    @dt\r\n);";
                SQLiteCommand commandSelect2 = new SQLiteCommand(qwrr, conn);
                commandSelect2.Parameters.AddWithValue("@lw", lastWorkId);
                commandSelect2.Parameters.AddWithValue("@dt", dt);
                commandSelect2.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Recordings WHERE recording_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                dataGridView1.Refresh();
                MessageBox.Show("Запись удалена из базы!");
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT \r\n    Recordings.recording_id as id, \r\n    MusicalWorks.title as pro, \r\n    Musicians.name AS musician_name, \r\n    Recordings.performance_date as date \r\nFROM \r\n    Recordings\r\nJOIN \r\n    MusicalWorks ON Recordings.work_id = MusicalWorks.work_id\r\nJOIN \r\n    Musicians ON Recordings.musician_id = Musicians.musician_id WHERE recording_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string wrk = reader["pro"].ToString();
                    string mus = reader["musician_name"].ToString();
                    string pd = reader["date"].ToString();

                    textBox1.Text = pd;
                    comboBox2.Text = mus;
                    textBox2.Text = wrk;

                }
            }
        }
    }
}
