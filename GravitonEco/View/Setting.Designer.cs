namespace GravitonEco.View
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            button3 = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            saveSensorConnection = new Button();
            checkSensorConnection = new Button();
            portSensor = new TextBox();
            label2 = new Label();
            ipAddresSensor = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.ForeColor = Color.FromArgb(25, 150, 190);
            groupBox2.Location = new Point(403, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(394, 219);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Подключение к БД";
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(30, 30, 30);
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.ForeColor = Color.FromArgb(250, 250, 250);
            textBox6.Location = new Point(123, 146);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(134, 23);
            textBox6.TabIndex = 47;
            textBox6.Text = "20";
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(65, 148);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 51;
            label7.Text = "Пароль:";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(30, 30, 30);
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.ForeColor = Color.FromArgb(250, 250, 250);
            textBox5.Location = new Point(123, 117);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(134, 23);
            textBox5.TabIndex = 46;
            textBox5.Text = "20";
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 119);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 49;
            label6.Text = "Логин:";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(30, 30, 30);
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.ForeColor = Color.FromArgb(250, 250, 250);
            textBox4.Location = new Point(123, 88);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(134, 23);
            textBox4.TabIndex = 45;
            textBox4.Text = "20";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 90);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 47;
            label5.Text = "Имя Базы данных:";
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(250, 250, 250);
            button3.Location = new Point(228, 184);
            button3.Name = "button3";
            button3.Size = new Size(160, 29);
            button3.TabIndex = 49;
            button3.Text = "Сохранить";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(250, 250, 250);
            button4.Location = new Point(9, 184);
            button4.Name = "button4";
            button4.Size = new Size(160, 29);
            button4.TabIndex = 48;
            button4.Text = "Проверить соединение";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(30, 30, 30);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.ForeColor = Color.FromArgb(250, 250, 250);
            textBox2.Location = new Point(123, 55);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(134, 23);
            textBox2.TabIndex = 44;
            textBox2.Text = "20";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 57);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 43;
            label3.Text = "Порт:";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(30, 30, 30);
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.ForeColor = Color.FromArgb(250, 250, 250);
            textBox3.Location = new Point(123, 21);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(134, 23);
            textBox3.TabIndex = 42;
            textBox3.Text = "20";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 23);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 41;
            label4.Text = "Ip-Addres:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(saveSensorConnection);
            groupBox1.Controls.Add(checkSensorConnection);
            groupBox1.Controls.Add(portSensor);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ipAddresSensor);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = Color.FromArgb(25, 150, 190);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 219);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Подключение к устройству";
            // 
            // saveSensorConnection
            // 
            saveSensorConnection.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            saveSensorConnection.FlatStyle = FlatStyle.Flat;
            saveSensorConnection.ForeColor = Color.FromArgb(250, 250, 250);
            saveSensorConnection.Location = new Point(228, 184);
            saveSensorConnection.Name = "saveSensorConnection";
            saveSensorConnection.Size = new Size(160, 29);
            saveSensorConnection.TabIndex = 40;
            saveSensorConnection.Text = "Сохранить";
            saveSensorConnection.UseVisualStyleBackColor = true;
            saveSensorConnection.Click += saveSensorConnection_Click;
            // 
            // checkSensorConnection
            // 
            checkSensorConnection.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            checkSensorConnection.FlatStyle = FlatStyle.Flat;
            checkSensorConnection.ForeColor = Color.FromArgb(250, 250, 250);
            checkSensorConnection.Location = new Point(11, 184);
            checkSensorConnection.Name = "checkSensorConnection";
            checkSensorConnection.Size = new Size(160, 29);
            checkSensorConnection.TabIndex = 39;
            checkSensorConnection.Text = "Проверить соединение";
            checkSensorConnection.UseVisualStyleBackColor = true;
            checkSensorConnection.Click += checkSensorConnection_Click;
            // 
            // portSensor
            // 
            portSensor.BackColor = Color.FromArgb(30, 30, 30);
            portSensor.BorderStyle = BorderStyle.FixedSingle;
            portSensor.ForeColor = Color.FromArgb(250, 250, 250);
            portSensor.Location = new Point(79, 78);
            portSensor.Name = "portSensor";
            portSensor.Size = new Size(134, 23);
            portSensor.TabIndex = 38;
            portSensor.Text = "20";
            portSensor.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 80);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 37;
            label2.Text = "Порт:";
            // 
            // ipAddresSensor
            // 
            ipAddresSensor.BackColor = Color.FromArgb(30, 30, 30);
            ipAddresSensor.BorderStyle = BorderStyle.FixedSingle;
            ipAddresSensor.ForeColor = Color.FromArgb(250, 250, 250);
            ipAddresSensor.Location = new Point(79, 36);
            ipAddresSensor.Name = "ipAddresSensor";
            ipAddresSensor.Size = new Size(134, 23);
            ipAddresSensor.TabIndex = 36;
            ipAddresSensor.Text = "20";
            ipAddresSensor.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 38);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Ip-Addres:";
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 21);
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Setting";
            Text = "Настройки";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Button checkSensorConnection;
        private TextBox portSensor;
        private Label label2;
        private TextBox ipAddresSensor;
        private TextBox textBox4;
        private Label label5;
        private Button button3;
        private Button button4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Button saveSensorConnection;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox5;
        private Label label6;
    }
}