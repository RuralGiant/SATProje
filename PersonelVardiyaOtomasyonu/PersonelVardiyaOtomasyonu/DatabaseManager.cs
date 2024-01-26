
namespace PersonelVardiyaOtomasyonu.Tablolar
{
    public class DatabaseManager
    {
        public DatabaseManager() { }

        private static DatabaseManager instance;

        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }

        private string Server = "localhost";

        public string GetDBInfo()
        {
            return $"Data Source={Server};Initial Catalog=PersonelVardiyaOtomasyonu;Integrated Security=True";
        }
    }

}
