namespace GravitonEcoV2.View
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveDeviceConnection = new System.Windows.Forms.Button();
            this.CheckDeviceConnection = new System.Windows.Forms.Button();
            this.portSensor = new System.Windows.Forms.TextBox();
            this.ipAddresSensor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveDataBaseConnection = new System.Windows.Forms.Button();
            this.CheckDataBaseConnection = new System.Windows.Forms.Button();
            this.dataBasePasswort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataBaseUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataBaseName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.portDb = new System.Windows.Forms.TextBox();
            this.ipAddresDb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 316);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1126, 316);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveDeviceConnection);
            this.groupBox1.Controls.Add(this.CheckDeviceConnection);
            this.groupBox1.Controls.Add(this.portSensor);
            this.groupBox1.Controls.Add(this.ipAddresSensor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 316);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение к устройству";
            // 
            // SaveDeviceConnection
            // 
            this.SaveDeviceConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveDeviceConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveDeviceConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDeviceConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.SaveDeviceConnection.Location = new System.Drawing.Point(268, 264);
            this.SaveDeviceConnection.Name = "SaveDeviceConnection";
            this.SaveDeviceConnection.Size = new System.Drawing.Size(111, 31);
            this.SaveDeviceConnection.TabIndex = 5;
            this.SaveDeviceConnection.Text = "Сохранить";
            this.SaveDeviceConnection.UseVisualStyleBackColor = false;
            this.SaveDeviceConnection.Click += new System.EventHandler(this.SaveDeviceConnection_Click);
            // 
            // CheckDeviceConnection
            // 
            this.CheckDeviceConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CheckDeviceConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CheckDeviceConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckDeviceConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.CheckDeviceConnection.Location = new System.Drawing.Point(15, 264);
            this.CheckDeviceConnection.Name = "CheckDeviceConnection";
            this.CheckDeviceConnection.Size = new System.Drawing.Size(230, 31);
            this.CheckDeviceConnection.TabIndex = 4;
            this.CheckDeviceConnection.Text = "Проверить соединение";
            this.CheckDeviceConnection.UseVisualStyleBackColor = false;
            this.CheckDeviceConnection.Click += new System.EventHandler(this.CheckDeviceConnection_Click);
            // 
            // portSensor
            // 
            this.portSensor.Location = new System.Drawing.Point(105, 82);
            this.portSensor.Name = "portSensor";
            this.portSensor.Size = new System.Drawing.Size(225, 27);
            this.portSensor.TabIndex = 3;
            // 
            // ipAddresSensor
            // 
            this.ipAddresSensor.Location = new System.Drawing.Point(105, 34);
            this.ipAddresSensor.Name = "ipAddresSensor";
            this.ipAddresSensor.Size = new System.Drawing.Size(225, 27);
            this.ipAddresSensor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label2.Location = new System.Drawing.Point(42, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Порт:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ip-Адрес:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SaveDataBaseConnection);
            this.groupBox2.Controls.Add(this.CheckDataBaseConnection);
            this.groupBox2.Controls.Add(this.dataBasePasswort);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dataBaseUserName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dataBaseName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.portDb);
            this.groupBox2.Controls.Add(this.ipAddresDb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 316);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Подключение к БД";
            // 
            // SaveDataBaseConnection
            // 
            this.SaveDataBaseConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveDataBaseConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveDataBaseConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDataBaseConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.SaveDataBaseConnection.Location = new System.Drawing.Point(274, 264);
            this.SaveDataBaseConnection.Name = "SaveDataBaseConnection";
            this.SaveDataBaseConnection.Size = new System.Drawing.Size(111, 31);
            this.SaveDataBaseConnection.TabIndex = 15;
            this.SaveDataBaseConnection.Text = "Сохранить";
            this.SaveDataBaseConnection.UseVisualStyleBackColor = false;
            this.SaveDataBaseConnection.Click += new System.EventHandler(this.SaveDataBaseConnection_Click);
            // 
            // CheckDataBaseConnection
            // 
            this.CheckDataBaseConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CheckDataBaseConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CheckDataBaseConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckDataBaseConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.CheckDataBaseConnection.Location = new System.Drawing.Point(21, 264);
            this.CheckDataBaseConnection.Name = "CheckDataBaseConnection";
            this.CheckDataBaseConnection.Size = new System.Drawing.Size(230, 31);
            this.CheckDataBaseConnection.TabIndex = 14;
            this.CheckDataBaseConnection.Text = "Проверить соединение";
            this.CheckDataBaseConnection.UseVisualStyleBackColor = false;
            // 
            // dataBasePasswort
            // 
            this.dataBasePasswort.Location = new System.Drawing.Point(109, 207);
            this.dataBasePasswort.Name = "dataBasePasswort";
            this.dataBasePasswort.Size = new System.Drawing.Size(182, 27);
            this.dataBasePasswort.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label7.Location = new System.Drawing.Point(26, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Пароль:";
            // 
            // dataBaseUserName
            // 
            this.dataBaseUserName.Location = new System.Drawing.Point(109, 163);
            this.dataBaseUserName.Name = "dataBaseUserName";
            this.dataBaseUserName.Size = new System.Drawing.Size(182, 27);
            this.dataBaseUserName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label6.Location = new System.Drawing.Point(39, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Логин:";
            // 
            // dataBaseName
            // 
            this.dataBaseName.Location = new System.Drawing.Point(109, 120);
            this.dataBaseName.Name = "dataBaseName";
            this.dataBaseName.Size = new System.Drawing.Size(182, 27);
            this.dataBaseName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label5.Location = new System.Drawing.Point(26, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Имя БД:";
            // 
            // portDb
            // 
            this.portDb.Location = new System.Drawing.Point(109, 75);
            this.portDb.Name = "portDb";
            this.portDb.Size = new System.Drawing.Size(182, 27);
            this.portDb.TabIndex = 7;
            // 
            // ipAddresDb
            // 
            this.ipAddresDb.Location = new System.Drawing.Point(109, 30);
            this.ipAddresDb.Name = "ipAddresDb";
            this.ipAddresDb.Size = new System.Drawing.Size(182, 27);
            this.ipAddresDb.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label3.Location = new System.Drawing.Point(46, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Порт:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label4.Location = new System.Drawing.Point(17, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ip-Адрес:";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(1126, 316);
            this.Controls.Add(this.panel1);
            this.Name = "Setting";
            this.Text = "[НАСТРОЙКИ] СТАНЦИЯ ОНЛАЙН МОНИТОРИНГА GRAVITON ECO ";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SaveDeviceConnection;
        private System.Windows.Forms.Button CheckDeviceConnection;
        private System.Windows.Forms.TextBox portSensor;
        private System.Windows.Forms.TextBox ipAddresSensor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveDataBaseConnection;
        private System.Windows.Forms.Button CheckDataBaseConnection;
        private System.Windows.Forms.TextBox dataBasePasswort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dataBaseUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dataBaseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox portDb;
        private System.Windows.Forms.TextBox ipAddresDb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}