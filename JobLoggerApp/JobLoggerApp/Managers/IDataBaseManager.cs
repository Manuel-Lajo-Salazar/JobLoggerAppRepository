
namespace JobLoggerApp
{
    public interface IDataBaseManager
    {
        void SaveLog(Message message);
    }
}