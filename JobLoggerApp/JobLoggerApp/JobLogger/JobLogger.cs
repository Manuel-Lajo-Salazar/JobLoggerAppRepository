using System;
using System.Configuration;

namespace JobLoggerApp
{
    public class JobLogger
    {
        public static bool LogToFile { get; set; }
        public static bool LogToConsole { get; set; }
        public static bool LogToDatabase { get; set; }
        public static bool LogMessage { get; set; }
        public static bool LogWarning { get; set; }
        public static bool LogError { get; set; }

        private IFileManager FileServiceProvider { get; set; }
        private IConsoleManager ConsoleServiceProvider { get; set; }
        private IDataBaseManager DataBaseServiceProvider { get; set; }

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        {
            LogToFile = logToFile;
            LogToConsole = logToConsole;
            LogToDatabase = logToDatabase;
            LogMessage = logMessage;
            LogWarning = logWarning;
            LogError = logError;
            FileServiceProvider = new FileManager();
            ConsoleServiceProvider = new ConsoleManager();
            DataBaseServiceProvider = new DataBaseManager();
        }

        public bool Log(Message message)
        {
            ValidateMessageAndConfiguration(message);

            bool successLogToFile = false;
            bool successLogToConsole = false;
            bool successLogToDatabase = false;
            //File Log
            if (LogToFile)
            {
                successLogToFile = LogMessageToFile(message);
            }
            //Console Log
            if (LogToConsole)
            {
                successLogToConsole = LogMessageToConsole(message);
            }
            //Database Log
            if (LogToDatabase)
            {
                successLogToDatabase = LogMessageToDatabase(message);
            }
            return (successLogToFile || !LogToFile) && (successLogToConsole || !LogToConsole) && (successLogToDatabase || !LogToDatabase);
        }

        private void ValidateMessageAndConfiguration(Message message)
        {
            if (string.IsNullOrEmpty(message.Text))
            {
                throw new Exception("Message must contain some text");
            }
            if ((!LogToFile && !LogToConsole && !LogToDatabase) || (!LogMessage && !LogWarning && !LogError))
            {
                throw new Exception("Invalid configuration");
            }
            if (string.IsNullOrEmpty(message.Type) ||
                (!message.Type.Equals(Constant.MessageType.Message) &&
                !message.Type.Equals(Constant.MessageType.Warning) &&
                !message.Type.Equals(Constant.MessageType.Error)
                ))
            {
                throw new Exception("Type of message must be specified");
            }
        }

        private bool LogMessageToFile(Message message)
        {
            bool successLog = false;
            switch (message.Type)
            {
                case Constant.MessageType.Message:
                    if (LogMessage)
                    {
                        FileServiceProvider.SaveLog(message);
                        successLog = true;
                    }
                    break;
                case Constant.MessageType.Warning:
                    if (LogWarning)
                    {
                        FileServiceProvider.SaveLog(message);
                        successLog = true;
                    }
                    break;
                case Constant.MessageType.Error:
                    if (LogError)
                    {
                        FileServiceProvider.SaveLog(message);
                        successLog = true;
                    }
                    break;
            }
            return successLog;
        }

        private bool LogMessageToConsole(Message message)
        {
            bool successLog = false;
            switch (message.Type)
            {
                case Constant.MessageType.Message:
                    if (LogMessage)
                    {
                        ConsoleServiceProvider.ShowLog(message, ConsoleColor.White);
                        successLog = true;
                    }
                    break;
                case Constant.MessageType.Warning:
                    if (LogWarning)
                    {
                        ConsoleServiceProvider.ShowLog(message, ConsoleColor.Yellow);
                        successLog = true;
                    }
                    break;
                case Constant.MessageType.Error:
                    if (LogError)
                    {
                        ConsoleServiceProvider.ShowLog(message, ConsoleColor.Red);
                        successLog = true;
                    }
                    break;
            }
            return successLog;
        }

        private bool LogMessageToDatabase(Message message)
        {
            bool successLog = false;
            switch (message.Type)
            {
                case Constant.MessageType.Message:
                    if (LogMessage)
                    {
                        DataBaseServiceProvider.SaveLog(message);
                        successLog = true;
                    }
                    break;
                case Constant.MessageType.Warning:
                    if (LogWarning)
                    {
                        DataBaseServiceProvider.SaveLog(message);
                        successLog = true;
                    }
                    break;
                case Constant.MessageType.Error:
                    if (LogError)
                    {
                        DataBaseServiceProvider.SaveLog(message);
                        successLog = true;
                    }
                    break;
            }
            return successLog;
        }

    }
}