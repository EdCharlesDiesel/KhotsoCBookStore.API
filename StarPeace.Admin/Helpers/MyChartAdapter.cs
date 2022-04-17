using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Helpers
{
    public class MyChartAdapter : IChart
    {
        public string Title { get; set; }
        public List<string> XData { get; set; }
        public List<int> YData { get; set; }

        public Bitmap GenerateChart()
        {
            ThirdPartyChartGenerator chart = new ThirdPartyChartGenerator();
            return chart.DrawChart(Title, XData, YData);
        }
    }



    public class MyChartAdapter2 : ThirdPartyChartGenerator, IChart
    {
        public string Title { get; set; }
        public List<string> XData { get; set; }
        public List<int> YData { get; set; }

        public Bitmap GenerateChart()
        {
            return this.DrawChart(Title, XData, YData);
        }
    }
}
