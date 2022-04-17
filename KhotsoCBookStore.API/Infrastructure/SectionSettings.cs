using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KhotsoCBookStore.API.Infrastructure
{

    public class SectionSettings : IReadableSettings,IWritableSettings,ISettings
    {
        private string sectionName = "";

        public SectionSettings(string sectionname)
        {
            this.sectionName = sectionname;
        }

        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("Title", "Books");
            return settings;
        }

        public string SetSettings(Dictionary<string, string> settings)
        {
            foreach (var item in settings)
            {
                //save to database
            }
            return "Section settings for " + sectionName + " saved on " + DateTime.Now;
        }



    }
}
