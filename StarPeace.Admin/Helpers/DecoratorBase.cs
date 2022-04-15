using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Helpers
{
    public abstract class DecoratorBase : IPhoto
    {
        private IPhoto photo;

        public DecoratorBase(IPhoto photo)
        {
            this.photo = photo;
        }

        public virtual Bitmap GetPhoto()
        {
            return photo.GetPhoto();
        }
    }
}
