using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Shopping_Mall.Database
{
    public class DBConnector
    {
        SqlConnection myConn;
        public DBConnector(){
            connect();
        }

        public void connect()
        {
            //設定資料庫IP位址，此為localhost
            String host = "59.124.167.62,1434";
            //設定資料庫名稱，此為database_name
            String db = "Shopping";
            //設定連結資料庫使用者ID，此為admin
            String user = "yll";
            //設定連結資料庫使用者Password，此為1234567890
            String password = "fYL52WDGH";

            String strConn = "server=" + host + "; database=" + db + "; User ID=" + user + "; Password=" + password + "; Trusted_Connection=True;Integrated Security=False" ;
            //建立連接
            myConn = new SqlConnection(strConn);
            
        }

        public void close()
        {
            myConn.Close();
        }

        public String sql(String strSQL)
        {
            //打開連接
            myConn.Open();
            SqlCommand myCommand = new SqlCommand(strSQL, myConn);
            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                return ex.ToString();
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                    myConn.Close();
            }
            return "Success";
        }
        /*
        public String[] sqlSelect(String strSQL, String fieldName)
        {
            //打開連接
            myConn.Open();
            List<String> res = new List<string>();

            SqlCommand myCommand = new SqlCommand(strSQL, myConn);
            try
            {
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        res.Add(reader[fieldName].ToString());
                }
            }
            catch (System.Exception ex){}
            finally
            {
                if (myConn.State == ConnectionState.Open)
                    myConn.Close();
            }
            return res.ToArray();
        }*/

        public String[] sqlSelect(String strSQL)
        {
            //打開連接
            myConn.Open();
            List<String> res = new List<string>();

            SqlCommand myCommand = new SqlCommand(strSQL, myConn);
            try
            {
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        for (int i = 0; i<reader.FieldCount; i++ )
                            res.Add(reader[i].ToString());
                }
            }
            catch (System.Exception ex) { }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                    myConn.Close();
            }
            return res.ToArray();
        }

        public String sqlGetID(String cmd)
        {
            SqlCommand myCommand = new SqlCommand(cmd, myConn);
            try
            {
                myConn.Open();
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    String res = reader["id"].ToString();
                    myConn.Close();
                    return res;
                }
                else
                {
                    myConn.Close();
                    return "";
                }
            }
            catch (System.Exception ex)
            {
                myConn.Close();
                return "";
            }
        }
    }
}