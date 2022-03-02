using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Sql_Bot
{
    class SqlBot
    {
        public MySqlConnection con;

        public SqlBot()
        {

            string host = "localhost";
            string db = "todoBase";
            string port = "3306";
            string user = "Tom";
            string pass = "tom";
            string conString = "datasource=127.0.0.1;port=3306;username=root;password=;database=todobase;";
            con = new MySqlConnection(conString);
        }


    }


    class CRUD : SqlBot
    {

        // properties
        public string eintrag { set; get; }

        // id 
        public int id { set; get; }

        // read properties
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        // create funktion

        public void Create_data()
        {
            // funktion zum einfügen von daten
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO todo(Eintrag) VALUES(@eintrag)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@Eintrag", MySqlDbType.VarChar).Value = eintrag;
                
                
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void Update_data()
        {
            // funktion zum updaten der datenbank
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE todo SET Eintrag=@eintrag WHERE id_eintrag="+id+";";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@Eintrag", MySqlDbType.VarChar).Value = eintrag;

                cmd.Parameters.Add("@id_eintrag", MySqlDbType.Int16).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }


        public void Delete_data()
        {
            // funktion zum löschen von datensätzen aus der datenbank
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM todo WHERE id_eintrag="+id+";";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_eintrag", MySqlDbType.Int16).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        // Lese Funktion

        public void Read_data()
        {
            dt.Clear();
            string query = "SELECT * FROM todo";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);

            MDA.Fill(ds);
            dt = ds.Tables[0];

        }

    }











}
