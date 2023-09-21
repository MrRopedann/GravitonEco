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
            groupBox3 = new GroupBox();
            button1 = new Button();
            newPassword = new TextBox();
            label8 = new Label();
            oldPassword = new TextBox();
            label9 = new Label();
            groupBox2 = new GroupBox();
            dataBasePasswort = new TextBox();
            label7 = new Label();
            dataBaseUserName = new TextBox();
            label6 = new Label();
            dataBaseName = new TextBox();
            label5 = new Label();
            saveDataBaseConnection = new Button();
            button4 = new Button();
            portDb = new TextBox();
            label3 = new Label();
            ipAddresDb = new TextBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            saveSensorConnection = new Button();
            checkSensorConnection = new Button();
            portSensor = new TextBox();
            label2 = new Label();
            ipAddresSensor = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(914, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(newPassword);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(oldPassword);
            groupBox3.Controls.Add(label9);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.FlatStyle = FlatStyle.Flat;
            groupBox3.ForeColor = Color.FromArgb(25, 150, 190);
            groupBox3.Location = new Point(3, 304);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(451, 292);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Пароль администратора";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(250, 250, 250);
            button1.Location = new Point(6, 245);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(183, 39);
            button1.TabIndex = 40;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // newPassword
            // 
            newPassword.BackColor = Color.FromArgb(30, 30, 30);
            newPassword.BorderStyle = BorderStyle.FixedSingle;
            newPassword.ForeColor = Color.FromArgb(250, 250, 250);
            newPassword.Location = new Point(138, 104);
            newPassword.Margin = new Padding(3, 4, 3, 4);
            newPassword.Name = "newPassword";
            newPassword.PasswordChar = '*';
            newPassword.Size = new Size(153, 27);
            newPassword.TabIndex = 38;
            newPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 106);
            label8.Name = "label8";
            label8.Size = new Size(115, 20);
            label8.TabIndex = 37;
            label8.Text = "Новый пароль:";
            // 
            // oldPassword
            // 
            oldPassword.BackColor = Color.FromArgb(30, 30, 30);
            oldPassword.BorderStyle = BorderStyle.FixedSingle;
            oldPassword.ForeColor = Color.FromArgb(250, 250, 250);
            oldPassword.Location = new Point(138, 45);
            oldPassword.Margin = new Padding(3, 4, 3, 4);
            oldPassword.Name = "oldPassword";
            oldPassword.PasswordChar = '*';
            oldPassword.Size = new Size(153, 27);
            oldPassword.TabIndex = 36;
            oldPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 52);
            label9.Name = "label9";
            label9.Size = new Size(119, 20);
            label9.TabIndex = 0;
            label9.Text = "Старый пароль:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataBasePasswort);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dataBaseUserName);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(dataBaseName);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(saveDataBaseConnection);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(portDb);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(ipAddresDb);
            groupBox2.Controls.Add(label4);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.ForeColor = Color.FromArgb(25, 150, 190);
            groupBox2.Location = new Point(460, 4);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(451, 292);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Подключение к БД";
            // 
            // dataBasePasswort
            // 
            dataBasePasswort.BackColor = Color.FromArgb(30, 30, 30);
            dataBasePasswort.BorderStyle = BorderStyle.FixedSingle;
            dataBasePasswort.ForeColor = Color.FromArgb(250, 250, 250);
            dataBasePasswort.Location = new Point(141, 195);
            dataBasePasswort.Margin = new Padding(3, 4, 3, 4);
            dataBasePasswort.Name = "dataBasePasswort";
            dataBasePasswort.Size = new Size(153, 27);
            dataBasePasswort.TabIndex = 47;
            dataBasePasswort.Text = "20";
            dataBasePasswort.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(74, 197);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 51;
            label7.Text = "Пароль:";
            // 
            // dataBaseUserName
            // 
            dataBaseUserName.BackColor = Color.FromArgb(30, 30, 30);
            dataBaseUserName.BorderStyle = BorderStyle.FixedSingle;
            dataBaseUserName.ForeColor = Color.FromArgb(250, 250, 250);
            dataBaseUserName.Location = new Point(141, 156);
            dataBaseUserName.Margin = new Padding(3, 4, 3, 4);
            dataBaseUserName.Name = "dataBaseUserName";
            dataBaseUserName.Size = new Size(153, 27);
            dataBaseUserName.TabIndex = 46;
            dataBaseUserName.Text = "20";
            dataBaseUserName.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(83, 159);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 49;
            label6.Text = "Логин:";
            // 
            // dataBaseName
            // 
            dataBaseName.BackColor = Color.FromArgb(30, 30, 30);
            dataBaseName.BorderStyle = BorderStyle.FixedSingle;
            dataBaseName.ForeColor = Color.FromArgb(250, 250, 250);
            dataBaseName.Location = new Point(141, 117);
            dataBaseName.Margin = new Padding(3, 4, 3, 4);
            dataBaseName.Name = "dataBaseName";
            dataBaseName.Size = new Size(153, 27);
            dataBaseName.TabIndex = 45;
            dataBaseName.Text = "20";
            dataBaseName.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 120);
            label5.Name = "label5";
            label5.Size = new Size(137, 20);
            label5.TabIndex = 47;
            label5.Text = "Имя Базы данных:";
            // 
            // saveDataBaseConnection
            // 
            saveDataBaseConnection.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            saveDataBaseConnection.FlatStyle = FlatStyle.Flat;
            saveDataBaseConnection.ForeColor = Color.FromArgb(250, 250, 250);
            saveDataBaseConnection.Location = new Point(261, 245);
            saveDataBaseConnection.Margin = new Padding(3, 4, 3, 4);
            saveDataBaseConnection.Name = "saveDataBaseConnection";
            saveDataBaseConnection.Size = new Size(183, 39);
            saveDataBaseConnection.TabIndex = 49;
            saveDataBaseConnection.Text = "Сохранить";
            saveDataBaseConnection.UseVisualStyleBackColor = true;
            saveDataBaseConnection.Click += saveDataBaseConnection_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(250, 250, 250);
            button4.Location = new Point(10, 245);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(183, 39);
            button4.TabIndex = 48;
            button4.Text = "Проверить соединение";
            button4.UseVisualStyleBackColor = true;
            // 
            // portDb
            // 
            portDb.BackColor = Color.FromArgb(30, 30, 30);
            portDb.BorderStyle = BorderStyle.FixedSingle;
            portDb.ForeColor = Color.FromArgb(250, 250, 250);
            portDb.Location = new Point(141, 73);
            portDb.Margin = new Padding(3, 4, 3, 4);
            portDb.Name = "portDb";
            portDb.Size = new Size(153, 27);
            portDb.TabIndex = 44;
            portDb.Text = "20";
            portDb.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 76);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 43;
            label3.Text = "Порт:";
            // 
            // ipAddresDb
            // 
            ipAddresDb.BackColor = Color.FromArgb(30, 30, 30);
            ipAddresDb.BorderStyle = BorderStyle.FixedSingle;
            ipAddresDb.ForeColor = Color.FromArgb(250, 250, 250);
            ipAddresDb.Location = new Point(141, 28);
            ipAddresDb.Margin = new Padding(3, 4, 3, 4);
            ipAddresDb.Name = "ipAddresDb";
            ipAddresDb.Size = new Size(153, 27);
            ipAddresDb.TabIndex = 42;
            ipAddresDb.Text = "20";
            ipAddresDb.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 31);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
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
            groupBox1.Location = new Point(3, 4);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(451, 292);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Подключение к устройству";
            // 
            // saveSensorConnection
            // 
            saveSensorConnection.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            saveSensorConnection.FlatStyle = FlatStyle.Flat;
            saveSensorConnection.ForeColor = Color.FromArgb(250, 250, 250);
            saveSensorConnection.Location = new Point(261, 245);
            saveSensorConnection.Margin = new Padding(3, 4, 3, 4);
            saveSensorConnection.Name = "saveSensorConnection";
            saveSensorConnection.Size = new Size(183, 39);
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
            checkSensorConnection.Location = new Point(13, 245);
            checkSensorConnection.Margin = new Padding(3, 4, 3, 4);
            checkSensorConnection.Name = "checkSensorConnection";
            checkSensorConnection.Size = new Size(183, 39);
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
            portSensor.Location = new Point(90, 104);
            portSensor.Margin = new Padding(3, 4, 3, 4);
            portSensor.Name = "portSensor";
            portSensor.Size = new Size(153, 27);
            portSensor.TabIndex = 38;
            portSensor.Text = "20";
            portSensor.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 107);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 37;
            label2.Text = "Порт:";
            // 
            // ipAddresSensor
            // 
            ipAddresSensor.BackColor = Color.FromArgb(30, 30, 30);
            ipAddresSensor.BorderStyle = BorderStyle.FixedSingle;
            ipAddresSensor.ForeColor = Color.FromArgb(250, 250, 250);
            ipAddresSensor.Location = new Point(90, 48);
            ipAddresSensor.Margin = new Padding(3, 4, 3, 4);
            ipAddresSensor.Name = "ipAddresSensor";
            ipAddresSensor.Size = new Size(153, 27);
            ipAddresSensor.TabIndex = 36;
            ipAddresSensor.Text = "20";
            ipAddresSensor.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 51);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Ip-Addres:";
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 21);
            ClientSize = new Size(914, 600);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Setting";
            Text = "Настройки";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private TextBox dataBaseName;
        private Label label5;
        private Button saveDataBaseConnection;
        private Button button4;
        private TextBox portDb;
        private Label label3;
        private TextBox ipAddresDb;
        private Label label4;
        private Button saveSensorConnection;
        private TextBox dataBasePasswort;
        private Label label7;
        private TextBox dataBaseUserName;
        private Label label6;
        private GroupBox groupBox3;
        private Button button1;
        private TextBox newPassword;
        private Label label8;
        private TextBox oldPassword;
        private Label label9;
    }
}