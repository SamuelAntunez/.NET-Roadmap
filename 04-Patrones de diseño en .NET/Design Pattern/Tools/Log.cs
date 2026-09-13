namespace Tools
{
    public sealed class Log // declaracion que define reglas de acceso, sealed impide que otras clases puedan heredar de ella
    {
        private static Log _instance = null;
        private string _path;
        private static object _lock = new object();

        public static Log GetInstance(string path)
        {
            lock (_lock)
            {
                if (_instance == null) _instance = new Log(path);
            }
            return _instance;
            
        }
        private Log(string path)
        {
            _path = path;
        }
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
