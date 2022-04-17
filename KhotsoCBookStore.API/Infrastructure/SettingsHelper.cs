using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Infrastructure;

namespace KhotsoCBookStore.API.Infrastructure
{
    public class SettingsHelper
    {
        public static Dictionary<IReadableSettings, Dictionary<string, string>> GetAllSettings(List<IReadableSettings> items)
        {
            Dictionary<IReadableSettings, Dictionary<string, string>> allSettings = new Dictionary<IReadableSettings, Dictionary<string, string>>();
            foreach (IReadableSettings item in items)
            {
                allSettings.Add(item, item.GetSettings());
            }
            return allSettings;
        }

        public static List<string> SetAllSettings(List<IWritableSettings> items, List<Dictionary<string, string>> values)
        {
            List<string> messages = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                messages.Add(items[i].SetSettings(values[i]));
            }
            return messages;
        }



        public static Dictionary<ISettings, Dictionary<string, string>> GetAllSettings(List<ISettings> items)
        {
            var allSettings = new Dictionary<ISettings, Dictionary<string, string>>();
            foreach (ISettings item in items)
            {
                allSettings.Add(item, item.GetSettings());
            }
            return allSettings;
        }

        public static List<string> SetAllSettings(List<ISettings> items, List<Dictionary<string, string>> values)
        {
            List<string> messages = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                messages.Add(items[i].SetSettings(values[i]));
            }
            return messages;
        }
    }
}
