namespace SoftwareArchitectureDesignAPI.Logger
{
    public class Logger : ILogger
    {
        private string filepath = "Logs.txt";
        
        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(filepath,
                       true))
            {
                writer.WriteLine(DateTime.Now + " | "+ message);
            }
        }
    }
}