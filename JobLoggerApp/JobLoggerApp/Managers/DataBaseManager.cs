using System.Configuration;

namespace JobLoggerApp
{
    public class DataBaseManager : IDataBaseManager
    {
        public void SaveLog(Message message)
        {
            //Here we must put the code to access the database and store the data, or preferably to invoke another layer to do that work.

            /*
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("Insert into Log Values('" + message.Text + "', " + message.Type + ")");
            command.ExecuteNonQuery();
             * */
        }
    }
}