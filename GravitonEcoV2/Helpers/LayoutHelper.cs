using System.Windows.Forms;

namespace GravitonEcoV2.Helpers
{
    public class LayoutHelper
    {
        public static void ApplyColumnRowLayout(TableLayoutPanel[] tableLayouts, int[] columnWidths, int[] rowHeights)
        {
            foreach (var tableLayoutPanel in tableLayouts)
            {
                tableLayoutPanel.ColumnStyles.Clear();
                foreach (int width in columnWidths)
                {
                    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
                }

                tableLayoutPanel.RowStyles.Clear();
                foreach (int height in rowHeights)
                {
                    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, height));
                }
            }
        }
    }
}
