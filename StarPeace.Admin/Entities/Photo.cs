using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Entities
{
    public class Photo : IPhoto
    {
        private string fileName;

        public Photo(string filename)
        {
            this.fileName = filename;
        }

        public Bitmap GetPhoto()
        {
            Bitmap bmp = (Bitmap)Image.FromFile(fileName);
            return bmp;
        }
    }
}
