using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Ado.Net._6.HW2.XMLMakeFromDB
{
    class Program
    {
     
        static void Main(string[] args)
        {
            GetDataToXml();
        }

        static void GetDataToXml()
        {

            string connectionString = @"Data Source=DESKTOP-PG10UGI\SQLEXPRESS;Initial Catalog=CRCMS_new;Integrated Security=True; User Id = sa; Password = Mc123456";
            string sql = "SELECT * FROM Area";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet("Areas");
                DataTable dt = new DataTable("Area");
                ds.Tables.Add(dt);
                adapter.Fill(ds.Tables["Area"]);

                ds.WriteXml("areadb.xml");
                Console.WriteLine("Данные сохранены в файл");
            }

        }
    }
}
