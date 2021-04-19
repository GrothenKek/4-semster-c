using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo1 {
    /*
     * 
     * Using
     * Properties.Settings.Default.connString
     * SqlConnection
     * SqlCommand
     * SqlDataReader
     * IDataRecord
     * 
     */
    public class DBReader1 {
        // The simplest possible way to do ADO
        public DBReader1() {
            ReadData(Properties.Settings.Default.connString);
        }

        private void ReadData(string connectionString) {
            string queryString = "SELECT * FROM Persons";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(queryString, connection)) 
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord record = (IDataRecord)reader;

                            for (int i = 0; i < record.FieldCount; ++i)
                            {
                                Console.WriteLine(String.Format("{0}, {1}, {2}", record.GetDataTypeName(i), record.GetName(i), record[i])); // record[i].GetType()
                            }

                            int id = (int)record[0];
                            string name = (string)record[1];
                            int age = (int)record[2];
                            int weight = (int)record[3];
                            int score = (int)record[4];

                            // Do stuff with data
                        }
                    }
                }
            }
        }
    }

    /*
     * Using
     * DataTable
     * 
     */
    public class DBReader2 {

        public DBReader2() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        // this will query your database and return the result to your datatable
                        da.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            Console.WriteLine($"ID = {id},Name = {name} : {score} points, {age} years, {weight} kg");
                        }

                        // Using LINQ
                        var q = from row in dataTable.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        

                    }
                }
            }
        }
    }

    public class DBReader3 {

        public DBReader3() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            //DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet("Persons");
                        da.Fill(dataSet);
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            Console.WriteLine(dataSet.Tables[0].Rows[i]["Name"].ToString());

                        string tableName = dataSet.Tables[0].TableName;
                        DataTable table = dataSet.Tables["Table"];
                        foreach (DataRow row in table.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            // Do lots of funny stuff with dataTable
                        }

                        var q = from row in table.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        foreach (var obj in q)
                            Console.WriteLine($"ID={obj.ID}, Name={obj.Name}");
                    }
                }
            }                
        }
    }

    // SELECT Persons.ID, Persons.Name, Pets.Name FROM Persons
    // INNER JOIN Pets ON Persons.ID = Pets.owner_id;
    public class DBReader4 {

        public DBReader4() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT Persons.Name, Pets.Name FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id";

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows) {
                var c0 = row.Table.Columns[0].ColumnName;
                var c1 = row.Table.Columns[1].ColumnName;
               
                //var c2 = row.Table.Columns[3].ColumnName;
                //var c3 = row.Table.Columns[2].ColumnName;

                var PersonName = (string)row[c0];
                var PetName = (string)row[c1];
                //var PersonID = (int)row[c2];
                //var PetID = (int)row[c3];

                Console.WriteLine($"PersonName={PersonName},   PetName={PetName}, ");

                // Do lots of funny stuff with dataTable
            }

            //// Using LINQ
            //var q = from row in dataTable.AsEnumerable()
            //        where row.Field<int>("ID") >= 1
            //        select new {
            //            Name = row.Field<string>(1),
            //            Pet = row.Field<string>(2),
            //        };
            //foreach (var obj in q)
            //    Console.WriteLine($"Name={obj.Name}, Pet={obj.Pet}");

            conn.Close();
            da.Dispose();
        }
    }


    public class DBReader5
    {

        public DBReader5()
        {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString)
        {
            string query = "SELECT Persons.Name, Pets.Name as PetName, Pets.ID  as PetID, Pets.owner_id FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id";

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                // int id = (int)row["ID"];
                string Personname = (string)row["Name"];
                string Petname = (string)row["PetName"];
                int PetId = (int)row["PetID"];
                int PersonID = (int)row["owner_id"];




                // Do lots of funny stuff with dataTable
                Console.WriteLine($"ID = {PersonID} Name = {Personname}, petID =  {PetId} ,{Petname}");
            }

            //// Using LINQ
            //var q = from row in dataTable.AsEnumerable()
            //        where row.Field<int>("ID") >= 1
            //        select new {
            //            Name = row.Field<string>(1),
            //            Pet = row.Field<string>(2),
            //        };
            //foreach (var obj in q)
            //    Console.WriteLine($"Name={obj.Name}, Pet={obj.Pet}");

            conn.Close();
            da.Dispose();
        }
    }
    public class MaxScore
    {

        public MaxScore()
        {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString)
        {
            string query = "SELECT Persons.Name, Persons.Score, Persons.ID  FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id";

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                string Personname = (string)row["Name"];
               // string Petname = (string)row["PetName"];
                int Score = (int)row["Score"];
                int ID = (int)row["ID"];







                // Do lots of funny stuff with dataTable
                Console.WriteLine($"{ID}  Name = {Personname}, Score =  {Score} ");
            }

            //// Using LINQ
            //var q = from row in dataTable.AsEnumerable()
            //        where row.Field<int>("ID") >= 1
            //        select new {
            //            Name = row.Field<string>(1),
            //            Pet = row.Field<string>(2),
            //        };
            //foreach (var obj in q)
            //    Console.WriteLine($"Name={obj.Name}, Pet={obj.Pet}");

            conn.Close();
            da.Dispose();
        }
    }

    public class DBWriter5 {

        public DBWriter5() {
            //WriteData1(Properties.Settings.Default.connString);
            //WriteData2(Properties.Settings.Default.connString);
            //WriteData3(Properties.Settings.Default.connString);
            WriteData4(Properties.Settings.Default.connString);
        }

        public void WriteData1(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (21,'Anton',34,64,8)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void WriteData2(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (@ID,@Name,@Age,@Weight,@Score)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 250).Value = "Anton";
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = 34;
                    command.Parameters.Add("@Weight", SqlDbType.Int).Value = 64;
                    command.Parameters.Add("@Score", SqlDbType.Int).Value = 8;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


            //--DELETE FROM Persons WHERE ID = 21;
            //--UPDATE Pets SET Weight = 24 WHERE Name = 'Garfield';

        }

        public void WriteData3(string connectionString) {

            string query = "DELETE FROM Persons WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void WriteData4(string connectionString) {

            string query = "UPDATE Pets SET Weight = 24 WHERE ID = 4";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("connString : " + Properties.Settings.Default.connString);

            //Console.WriteLine("Running DBReader1");
            // var reader1 = new DBReader1();

            //  Console.WriteLine("Running DBReader2");
            // var reader2 = new DBReader2();

            // Console.WriteLine("Running DBReader3");
            // var reader3 = new DBReader3();

            // Console.WriteLine("Running DBReader4");
            // var reader4 = new DBReader4();

            // Console.WriteLine("Running DBReader5");
            // var reader5 = new DBReader5();

            // Console.WriteLine("Running DBWriter5");
            //var writer5 = new DBWriter5();

             Console.WriteLine("Garfield is fat");
            var writer4 = new DBWriter5();



            Console.WriteLine("Running MaxScore");
            var writer6 = new MaxScore();


            Console.ReadKey();
        }

    }
}
