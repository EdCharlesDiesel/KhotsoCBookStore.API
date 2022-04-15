namespace StarPeace.Admin.Helpers
{
    [Serializable]
    public class UploadedFile : IUploadedFile
    {
        public string FileName { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] FileContent { get; set; }

        public IUploadedFile Clone()
        {
            return (IUploadedFile)this.MemberwiseClone();
        }

        public IUploadedFile DeepCopy()
        {
            if (!this.GetType().IsSerializable)
                throw new ArgumentException("The object provided is not serializable");

            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            IUploadedFile deepcopy = (IUploadedFile)formatter.Deserialize(ms);
            ms.Close();
            return deepcopy;
        }
    }
}