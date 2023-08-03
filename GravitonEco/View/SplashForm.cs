using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GravitonEco.View
{
    public partial class SplashForm : Form
    {

        private System.Windows.Forms.Timer timer;
        private int progressValue;
        private const int totalTimeInSeconds = 20;
        private const int timerIntervalInMilliseconds = 100;

        public SplashForm()
        {
            InitializeComponent();
            InitializeProgressBar();
        }

        private void InitializeProgressBar()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = totalTimeInSeconds * 1000 / timerIntervalInMilliseconds; // Рассчитываем общее количество шагов прогресса
            progressBar1.Value = 0;
            progressValue = 0;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = timerIntervalInMilliseconds;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressValue++;
            progressBar1.Value = progressValue;

            if (progressValue >= progressBar1.Maximum)
            {
                timer.Stop();
                this.Close();
            }
        }
    }
}
