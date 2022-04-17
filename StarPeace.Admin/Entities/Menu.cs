using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Entities
{
    public class Menu : IMenuComponent
    {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }
        public List<IMenuComponent> Children { get; set; }
        public bool OpenInNewWindow { get; set; }
    }
}
