using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEco.View
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        public static void ShowSplashScreen()
        {
            SplashForm splashForm = new SplashForm();
            splashForm.Show();

            // Задержка на стартовом экране (2 секунды в данном примере)
            //Thread.Sleep(5000);

            Application.DoEvents(); // Обновление интерфейса, чтобы стартовый экран успел отрисоваться
        }

        public static void CloseSplashScreen()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is SplashForm splashForm)
                {
                    splashForm.Close();
                    break;
                }
            }
        }
    }
}
