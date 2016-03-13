
namespace JobLoggerApp
{
    public interface IFileManager
    {
        void SaveLog(Message message);
    }
}