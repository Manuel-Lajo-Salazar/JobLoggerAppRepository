using System;

namespace JobLoggerApp
{
    public class ConsoleManager : IConsoleManager
    {
        public void ShowLog(Message message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(DateTime.Now.ToShortDateString() + " - " + message.Text);
        }
    }
}