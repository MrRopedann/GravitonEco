using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.View
{
    public partial class LogSensor : Form
    {
        private Color color_1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        private Color color_2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));

        public LogSensor()
        {
            InitializeComponent();


            for (int i = 0; i < 10; i++)
            {
                addValuetable("Параметр" + i, "Параметр" + i, "Параметр" + i);
            }
        }

        private void dataLogHistory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Устанавливаем цвет фона для четных и нечетных строк
            if (e.RowIndex % 2 == 0)
            {
                dataLogHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = color_1;
            }
            else
            {
                dataLogHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = color_2;
            }
        }

        private void addValuetable(string param_1, string param_2, string param_3)
        {
            // Создайте новую строку
            DataGridViewRow newRow = new DataGridViewRow();

            // Создайте ячейки для каждой колонки и установите значения
            DataGridViewTextBoxCell cellDate = new DataGridViewTextBoxCell();
            cellDate.Value = DateTime.Now.ToString("yyyy-MM-dd"); // Замените на ваш способ получения даты

            DataGridViewTextBoxCell cellTime = new DataGridViewTextBoxCell();
            cellTime.Value = DateTime.Now.ToString("HH:mm:ss"); // Замените на ваш способ получения времени

            DataGridViewTextBoxCell cellParameter = new DataGridViewTextBoxCell();
            cellParameter.Value = param_1; // Замените на ваш параметр

            DataGridViewTextBoxCell cellValue1 = new DataGridViewTextBoxCell();
            cellValue1.Value = param_2; // Замените на ваше значение

            DataGridViewTextBoxCell cellValue2 = new DataGridViewTextBoxCell();
            cellValue2.Value = param_3; // Замените на ваше значение

            // Добавьте ячейки к строке
            newRow.Cells.Add(cellDate);
            newRow.Cells.Add(cellTime);
            newRow.Cells.Add(cellParameter);
            newRow.Cells.Add(cellValue1);
            newRow.Cells.Add(cellValue2);

            // Добавьте строку к DataGridView
            dataLogHistory.Rows.Add(newRow);
        }
    }
}
