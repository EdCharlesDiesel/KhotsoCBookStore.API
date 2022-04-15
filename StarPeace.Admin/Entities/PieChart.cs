using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    public class PieChart : IChart
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
            var totalAngle = (float)0;
            var sweepAngle = (float)0;
            var startAngle = (float)0;
            for (var i = 0; i < YData.Count; i++)
            {
                totalAngle = totalAngle + YData[i];
            }

            for (var i = 0; i < YData.Count; i++)
            {
                var pieBrush = new SolidBrush(ColorHelper.GetBrushColor(i));
                var pieX = 100;
                var pieY = 40;
                var pieWidth = 150;
                var pieHeight = 150;
                sweepAngle = YData[i] / totalAngle * 360;
                chartGraphics.FillPie(pieBrush, pieX, pieY, pieWidth, pieHeight, startAngle,
                sweepAngle);
                chartGraphics.DrawPie(Pens.Black, pieX, pieY, pieWidth, pieHeight, startAngle,
                sweepAngle);
                startAngle += sweepAngle;
            }
            var legendRect = new PointF(335, 20);
            var legendText = new PointF(360, 16);
            var legendFont = new Font("Arial", 10);
            for (int i = 0; i < XData.Count; i++)
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
}