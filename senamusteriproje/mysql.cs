using System.Data;
using MySql.Data.MySqlClient;

namespace senamusteriproje
{
    public class mysql 
    {
        public static MySqlConnection con;
        public static MySqlCommand cmd;
        public static MySqlDataAdapter da;
        public static MySqlDataReader dr;
        public static DataTable dt;
        public static DataSet ds;

        public static string Conn_String
        {
            get {
                return $"server=93.89.225.112;username=pehozgun_admina;password=Admin5050;database=pehozgun_verita";
                }
        }

        public static void Query(string sql)
        {
            using(con = new MySqlConnection(Conn_String))
            {
                con.Open();
                using(cmd = new MySqlCommand(sql,con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetData(string sql)
        {
            using (con = new MySqlConnection(Conn_String))
            {
                dt= new DataTable();
                using(da = new MySqlDataAdapter(sql,con))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static DataSet DataSet(string sql,string tbl)
        {
            using(con =new MySqlConnection(Conn_String))
            {
                ds=new DataSet();
                using(da=new MySqlDataAdapter(sql,con))
                {
                    da.Fill(ds, tbl);
                }
            }
            return ds;  
        }
    }
}
