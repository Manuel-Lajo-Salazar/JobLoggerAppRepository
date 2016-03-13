using System;
using System.Configuration;
using System.IO;

namespace JobLoggerApp
{
    public class FileManager : IFileManager
    {
        public void SaveLog(Message message)
        {
            string currentDate = DateTime.Now.ToShortDateString().Replace('/', '-');
            string path = @ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + currentDate + ".txt";
            File.AppendAllText(path, currentDate + " - " + message.Text + Environment.NewLine);
        }
    }
}