namespace Tools
{
    public sealed class Log
    {
        private static Log _instance = null;
        private string _path;

        public static Log GetInstance(string path)
        {
            if (_instance == null) 
            {
            
            }

            return _instance;
        }
        private Log()
        {
        }
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
