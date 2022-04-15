using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StarPeace.Admin.Entities
{
    public class BarChart : IChart
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
}