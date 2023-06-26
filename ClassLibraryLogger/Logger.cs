namespace ClassLibraryLogger
{
    public class Logger
    {
        public static readonly string LOGGER_FILE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ReplicasStatus/Logger.log";
        public static readonly string LOGGER_DIRECTORY_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ReplicasStatus";

        public static (bool, string) CreateLog()
        {
            try
            {
                if (!Directory.Exists(LOGGER_DIRECTORY_PATH))
                {
                    Directory.CreateDirectory(LOGGER_DIRECTORY_PATH);
                }

                if (!File.Exists(LOGGER_FILE_PATH))
                {
                    FileStream fs = File.Open(LOGGER_FILE_PATH, FileMode.Create);
                    fs.Close();
                }
                return (true, "Log ccreado exitosamente");
            }
            catch (Exception ex)
            {
                return (false, "Error al crear log: " + ex.Message);
            }
        }

        public static void WriteToLog(string message)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                using (StreamWriter w = File.AppendText(LOGGER_FILE_PATH))
                {
                    w.WriteLine(dateTime.ToString() + ": " + message);
                }
            }
            catch
            {
                ;
            }
        }

        public static bool LoggerExists()
        {
            return File.Exists(LOGGER_FILE_PATH);
        }
    }
}