using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace StarPeace.Admin.Helpers
{

    public class MyChartGenerator : IChart
    {
        public string Title { get; set; }
        public List<string> XData { get; set; }
        public List<int> YData { get; set; }

        public Bitmap GenerateChart()
        {
            var chartBitmap = new Bitmap(400, 200);
            var chartGraphics = Graphics.FromImage(chartBitmap);
            chartGraphics.Clear(Color.White);
            var titleFont = new Font("Arial", 16);
            var titleXY = new PointF(5, 5);
            chartGraphics.DrawString(Title, titleFont, Brushes.Black, titleXY);

            var spacing = 35;
            var scale = 10;
            for (var i = 0; i < YData.Count; i++)
            {
                var barBrush = new SolidBrush(ColorHelper.GetBrushColor(i));
                var barX = (i * spacing) + 15;
                var barY = 200 - (YData[i] * scale);
                var barWidth = 20;
                var barHeight = (YData[i] * scale) + 5;
                chartGraphics.FillRectangle(barBrush, barX, barY, barWidth, barHeight);
                chartGraphics.DrawRectangle(Pens.Black, barX, barY, barWidth, barHeight);
            }

            var legendRect = new PointF(335, 20);
            var legendText = new PointF(360, 16);
            var legendFont = new Font("Arial", 10);
            for (var i = 0; i < XData.Count; i++)
            {
                var legendBrush = new SolidBrush(ColorHelper.GetBrushColor(i));
                chartGraphics.FillRectangle(legendBrush, legendRect.X, legendRect.Y, 20, 10);
                chartGraphics.DrawRectangle(Pens.Black, legendRect.X, legendRect.Y, 20, 10);
                chartGraphics.DrawString(XData[i], legendFont, Brushes.Black, legendText);
                legendRect.Y += 15;
                legendText.Y += 15;
            }

            var borderPen = new Pen(Color.Black, 2);
            var borderRect = new Rectangle(1, 1, 398, 198);
            chartGraphics.DrawRectangle(borderPen, borderRect);
            return chartBitmap;
        }
    }



    public class ColorHelper
    {
        public static Color GetBrushColor(int i)
        {
            Color c;

            switch (i)
            {
                case 0:
                    c = Color.Blue;
                    break;
                case 1:
                    c = Color.Red;
                    break;
                case 2:
                    c = Color.Yellow;
                    break;
                case 3:
                    c = Color.Peru;
                    break;
                case 4:
                    c = Color.Orange;
                    break;
                case 5:
                    c = Color.Coral;
                    break;
                case 6:
                    c = Color.Gray;
                    break;
                case 7:
                    c = Color.Maroon;
                    break;
                default:
                    c = Color.SteelBlue;
                    break;
            }
            return c;
        }
    }
}
