using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StarPeace.Admin.Services
{
    public interface IChart
    {
        string Title { get; set; }
        List<string> XData { get; set; }
        List<int> YData { get; set; }
        Bitmap GenerateChart();
    }
}