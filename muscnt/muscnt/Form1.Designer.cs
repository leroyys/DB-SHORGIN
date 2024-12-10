namespace muscnt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            исполнителиToolStripMenuItem = new ToolStripMenuItem();
            лейблыToolStripMenuItem = new ToolStripMenuItem();
            произведенияToolStripMenuItem = new ToolStripMenuItem();
            dataGridView2 = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { исполнителиToolStripMenuItem, лейблыToolStripMenuItem, произведенияToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(949, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // исполнителиToolStripMenuItem
            // 
            исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            исполнителиToolStripMenuItem.Size = new Size(102, 24);
            исполнителиToolStripMenuItem.Text = "Музыканты";
            исполнителиToolStripMenuItem.Click += исполнителиToolStripMenuItem_Click;
            // 
            // лейблыToolStripMenuItem
            // 
            лейблыToolStripMenuItem.Name = "лейблыToolStripMenuItem";
            лейблыToolStripMenuItem.Size = new Size(78, 24);
            лейблыToolStripMenuItem.Text = "Лейблы";
            лейблыToolStripMenuItem.Click += лейблыToolStripMenuItem_Click;
            // 
            // произведенияToolStripMenuItem
            // 
            произведенияToolStripMenuItem.Name = "произведенияToolStripMenuItem";
            произведенияToolStripMenuItem.Size = new Size(126, 24);
            произведенияToolStripMenuItem.Text = "Произведения";
            произведенияToolStripMenuItem.Click += произведенияToolStripMenuItem_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column5, Column6, Column7, Column8, Column9, Column1, Column2, Column3 });
            dataGridView2.Location = new Point(12, 31);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(931, 390);
            dataGridView2.TabIndex = 2;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // Column5
            // 
            Column5.HeaderText = "ID";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "Номер лейбла";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 125;
            // 
            // Column7
            // 
            Column7.HeaderText = "Дата релиза";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 125;
            // 
            // Column8
            // 
            Column8.HeaderText = "Оптовая цена";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 125;
            // 
            // Column9
            // 
            Column9.HeaderText = "Розничная цена";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Продано за прошлый год";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Продано в этом году";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Не продано ";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Location = new Point(12, 427);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(931, 324);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Информация о пластинках";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(514, 177);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 18;
            label3.Text = "Не продано";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(514, 103);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 17;
            label2.Text = "Продано в этом году";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(514, 34);
            label1.Name = "label1";
            label1.Size = new Size(189, 20);
            label1.TabIndex = 16;
            label1.Text = "Продано за прошлый год";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.GradientInactiveCaption;
            textBox3.Location = new Point(514, 200);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(411, 27);
            textBox3.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.GradientInactiveCaption;
            textBox2.Location = new Point(514, 126);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(411, 27);
            textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.GradientInactiveCaption;
            textBox1.Location = new Point(514, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(411, 27);
            textBox1.TabIndex = 12;
            // 
            // button3
            // 
            button3.Location = new Point(798, 244);
            button3.Name = "button3";
            button3.Size = new Size(133, 65);
            button3.TabIndex = 11;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(653, 244);
            button2.Name = "button2";
            button2.Size = new Size(133, 65);
            button2.TabIndex = 10;
            button2.Text = "Редактировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(514, 244);
            button1.Name = "button1";
            button1.Size = new Size(133, 65);
            button1.TabIndex = 9;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 259);
            label7.Name = "label7";
            label7.Size = new Size(122, 20);
            label7.TabIndex = 8;
            label7.Text = "Розничная цена";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 177);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 7;
            label6.Text = "Оптовая цена";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 103);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 6;
            label5.Text = "Дата релиза";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Location = new Point(6, 34);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 5;
            label4.Text = "Номер лейбла";
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.GradientInactiveCaption;
            textBox7.Location = new Point(6, 282);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(423, 27);
            textBox7.TabIndex = 4;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.GradientInactiveCaption;
            textBox6.Location = new Point(6, 200);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(423, 27);
            textBox6.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.GradientInactiveCaption;
            textBox5.Location = new Point(6, 126);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(423, 27);
            textBox5.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.GradientInactiveCaption;
            textBox4.Location = new Point(6, 57);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(423, 27);
            textBox4.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 758);
            Controls.Add(groupBox2);
            Controls.Add(dataGridView2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "\"Музыкальный магазин\"";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem исполнителиToolStripMenuItem;
        private ToolStripMenuItem лейблыToolStripMenuItem;
        private DataGridView dataGridView2;
        private GroupBox groupBox2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private ToolStripMenuItem произведенияToolStripMenuItem;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
