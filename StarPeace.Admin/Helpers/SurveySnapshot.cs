using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace StarPeace.Admin.Helpers
{
    public class SurveySnapshot
    {
        private string fileName;

        public SurveySnapshot(string filename)
        {
            this.fileName = filename;
        }

        public void Save(SurveyState state)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
            stream.Close();
        }

        public SurveyState Restore()
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            object obj = formatter.Deserialize(stream);
            stream.Close();
            return (SurveyState)obj;
        }
    }
}
