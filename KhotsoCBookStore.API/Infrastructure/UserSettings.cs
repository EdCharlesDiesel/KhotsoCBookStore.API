using System;
using System.Collections.Generic;


namespace KhotsoCBookStore.API.Infrastructure
{

    public class UserSettings : IReadableSettings,IWritableSettings,ISettings
    {
        private string userName = "";

        public UserSettings(string username)
        {
            this.userName = username;
        }


        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("DisplayName", "Bob");
            return settings;
        }

        public string SetSettings(Dictionary<string, string> settings)
        {
            foreach (var item in settings)
            {
                //save to database
            }
            return "User settings for " + userName + " saved on " + DateTime.Now;
        }

    }
}
