using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Infrastructure
{
    public class GlobalSettings : IReadableSettings,IWritableSettings,ISettings
{
    public Dictionary<string, string> GetSettings()
    {
        Dictionary<string, string> settings = new Dictionary<string, string>();
        settings.Add("Theme", "Summer");
        return settings;
    }

    public string SetSettings(Dictionary<string, string> settings)
    {
        foreach (var item in settings)
        {
            //save to database
        }
        return "Global settings saved on " + DateTime.Now;
    }
}

}
