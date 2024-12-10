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
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace muscnt
{
    public partial class musicisp : Form
    {
        public musicisp()
        {
            InitializeComponent();
        }

        private Connection _db;
        string id;
        private byte[] imageBytes;

        private void musicisp_Load(object sender, EventArgs e)
        {
            _db = Connection.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT \r\n    Musicians.musician_id as musid, \r\n    Musicians.name AS musician_name, \r\n    Musicians.role as rl, \r\n    Musicians.instrument as inst, \r\n    Ensembles.name AS ensemble_name\r\nFROM \r\n    Musicians\r\nJOIN \r\n    Ensembles ON Musicians.ensemble_id = Ensembles.ensemble_id;";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["musid"], reader["musician_name"], reader["rl"], reader["inst"], reader["ensemble_name"]);
            }

            _db = Connection.GetInstance();
            SQLiteConnection conn3 = _db.GetConnection();
            string query3 = "SELECT DISTINCT name FROM Ensembles";
            SQLiteCommand cmd3 = new SQLiteCommand(query3, conn3);
            SQLiteDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string data = reader3.GetString(0);
                comboBox1.Items.Add(data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mus = textBox1.Text;
            string rol = textBox2.Text;
            string inst = textBox3.Text;
            string ens = comboBox1.Text;

            if (string.IsNullOrEmpty(mus) || string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(ens))
            {
                MessageBox.Show("Заполните все обязательные поля (*)!");
            }
            else if (!Regex.IsMatch(mus, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните корректно имя музыканта!");
            }
            else if (!Regex.IsMatch(rol, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните корректно роль музыканта!");
            }
            else if (!Regex.IsMatch(inst, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните корректно название инструмента!");
            }
            else if (!Regex.IsMatch(inst, "^[а-яА-Я 0-9 -]+$"))
            {
                MessageBox.Show("Заполните корректно название ансамбля!");
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                        _db = Connection.GetInstance();
                        SQLiteConnection conn = _db.GetConnection();
                        string query = "INSERT INTO Musicians (name, role, instrument, ensemble_id, photo_url) \r\nVALUES (@mus, @rol, @inst, \r\n (SELECT ensemble_id FROM Ensembles WHERE name = @ens), \r\n        @phot);";
                        SQLiteCommand command = new SQLiteCommand(query, conn);
                        command.Parameters.AddWithValue("@mus", mus);
                        command.Parameters.AddWithValue("@rol", rol);
                        command.Parameters.AddWithValue("@inst", inst);
                        command.Parameters.AddWithValue("@ens", ens);
                        command.Parameters.AddWithValue("@phot", imageBytes);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись добавлена в базу!");
                    }

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Musicians WHERE musician_id = @id";
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
                string query = "SELECT \r\n    Musicians.musician_id AS musid, \r\n    Musicians.name AS musician_name, \r\n    Musicians.role AS rl, \r\n    Musicians.instrument AS inst, \r\n    Ensembles.name AS ensemble_name,\r\n    Musicians.photo_url AS ph \r\nFROM \r\n    Musicians\r\nJOIN \r\n    Ensembles ON Musicians.ensemble_id = Ensembles.ensemble_id\r\nWHERE \r\n    Musicians.musician_id = @id;";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string nm = reader["musician_name"].ToString();
                    string rl = reader["rl"].ToString();
                    string inst = reader["inst"].ToString();
                    string ens = reader["ensemble_name"].ToString();

                    textBox1.Text = nm;
                    textBox2.Text = rl;
                    textBox3.Text = inst;
                    comboBox1.Text = ens;

                    byte[] pht = (byte[])reader["ph"];
                    MemoryStream ms = new MemoryStream(pht);
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Заполните все обязательные поля (*)!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните корректно имя музыканта!");
            }
            else if (!Regex.IsMatch(textBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните корректно роль музыканта!");
            }
            else if (!Regex.IsMatch(comboBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните корректно название инструмента!");
            }
            else
            {
                _db = Connection.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Musicians \r\nSET \r\n    name = @name, \r\n    role = @role, \r\n    instrument = @instrument, \r\n    ensemble_id = (SELECT ensemble_id FROM Ensembles WHERE name = @ensemble_id)\r\nWHERE \r\n    musician_id = @id;";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@name", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@role", DbType.String).Value = textBox2.Text;
                command.Parameters.Add("@instrument", DbType.String).Value = textBox3.Text;
                command.Parameters.Add("@ensemble_id", DbType.String).Value = comboBox1.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }
    }
}
