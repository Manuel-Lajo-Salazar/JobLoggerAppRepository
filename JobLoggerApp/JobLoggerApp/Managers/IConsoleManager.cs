using System;

namespace JobLoggerApp
{
    public interface IConsoleManager
    {
        void ShowLog(Message message, ConsoleColor color);
    }
}