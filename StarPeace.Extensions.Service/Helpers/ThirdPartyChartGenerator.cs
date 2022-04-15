using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace StarPeace.Extensions.Service.Helpers
{
    public class ThirdPartyChartGenerator
    {
        public Bitmap DrawChart(string title,List<string> xData, List<int> yData)
        {
            var chartBitmap = new Bitmap(400, 200);
            var chartGraphics = System.Drawing.Graphics.FromImage(chartBitmap);
            chartGraphics.Clear(Color.White);
            var titleFont = new Font("Arial", 16);
            var titleXY = new PointF(5, 5);
            chartGraphics.DrawString(title, titleFont, Brushes.Black, titleXY);

            var totalAngle = (float)0;
            var sweepAngle = (float)0;
            var startAngle = (float)0;
            for (var i = 0; i < yData.Count; i++)
            {
                totalAngle = totalAngle + yData[i];
            }
            for (var i = 0; i < yData.Count; i++)
            {
                var pieBrush = new SolidBrush(ColorHelper.GetBrushColor(i));
                var pieX = 100;
                var pieY = 40;
                var pieWidth = 150;
                var pieHeight = 150;
                sweepAngle = yData[i] / totalAngle * 360;
                chartGraphics.FillPie(pieBrush, pieX, pieY, pieWidth, pieHeight, startAngle, sweepAngle);
                chartGraphics.DrawPie(Pens.Black, pieX, pieY, pieWidth, pieHeight, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }

            var legendRect = new PointF(335, 20);
            var legendText = new PointF(360, 16);
            var legendFont = new Font("Arial", 10);
            for (int i = 0; i < xData.Count; i++)
            {
                var legendBrush = new SolidBrush(ColorProvider.GetBrushColor(i));
                chartGraphics.FillRectangle(legendBrush, legendRect.X, legendRect.Y, 20, 10);
                chartGraphics.DrawRectangle(Pens.Black, legendRect.X, legendRect.Y, 20, 10);
                chartGraphics.DrawString(xData[i], legendFont, Brushes.Black, legendText);
                legendRect.Y += 15;
                legendText.Y += 15;
            }

            var borderPen = new Pen(Color.Black, 2);
            var borderRect = new Rectangle(1, 1, 398, 198);
            chartGraphics.DrawRectangle(borderPen, borderRect);
            return chartBitmap;
        }
    }



    public class ColorProvider
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
