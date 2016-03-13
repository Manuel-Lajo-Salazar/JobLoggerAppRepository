
namespace JobLoggerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            JobLogger logger = new JobLogger(true, true, true, true, true, true);
            Message msg = new Message { Text = "Warning from main", Type = Constant.MessageType.Warning };
            logger.Log(msg);
        }
    }
}