using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Infrastructure
{
    public interface ISettings
    {
        Dictionary<string,string> GetSettings();
        string SetSettings(Dictionary<string,string> settings);
    }

    public interface IReadableSettings
    {
        Dictionary<string, string> GetSettings();
    }

    public interface IWritableSettings
    {
        string SetSettings(Dictionary<string, string> settings);
    }
}
