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
using System.Net;
using System.Text.RegularExpressions;

namespace muscnt
{
    public partial class Ensembles : Form
    {
        public Ensembles()
        {
            InitializeComponent();
        }

        private Connection _db;
        string id;

        private void Ensembles_Load(object sender, EventArgs e)
        {
            _db = Connection.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT ensemble_id, name, type FROM Ensembles";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["ensemble_id"], reader["name"], reader["type"]);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT ensemble_id, name, type FROM Ensembles WHERE ensemble_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string nm = reader["name"].ToString();
                    string tp = reader["type"].ToString();

                    textBox1.Text = nm;
                    textBox2.Text = tp;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string type = textBox2.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Заполните все обязательные поля (*)!");
            }
            else if (!Regex.IsMatch(name, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Название правильно!");
            }
            else if (!Regex.IsMatch(name, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Тип ансамбля правильно!");
            }
            else
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Ensembles (name, type) \r\nVALUES (@name, @type);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@type", type);
                command.ExecuteNonQuery();
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
                string sql = "DELETE FROM Ensembles WHERE ensemble_id = @id";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Заполните редактируемые поля!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Название правильно!");
            }
            else if (!Regex.IsMatch(textBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Тип ансамбля правильно!");
            }
            else
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Ensembles SET name = @name, type = @type WHERE ensemble_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@name", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@type", DbType.String).Value = textBox2.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
