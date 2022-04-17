using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    public class WatermarkDecorator : DecoratorBase
    {
        private string watermarkText;

        public WatermarkDecorator(IPhoto photo,string watermark) : base(photo)
        {
            this.watermarkText = watermark;
        }

        public override Bitmap GetPhoto()
        {
            Bitmap bmp = base.GetPhoto();
            Graphics g = Graphics.FromImage(bmp);
            Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            float x = (float)bmp.Width / 2;
            float y = (float)bmp.Height / 2;
            g.DrawString(watermarkText, font, Brushes.Black, x, y, sf);
            g.Save();
            return bmp;
        }
    }
}
