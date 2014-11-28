using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL;
using System.Data;

namespace AutoLotConnectedLayer
{
    internal class InventoryDAL:IDisposable
    {
        private SqlConnection sqlConnection = null;

        public InventoryDAL(string connectionString)
        {
            this.OpenConnection(connectionString);
        }

        public void Dispose()
        {
            this.CloseConnection();
        }

        public void OpenConnection(string connectionString)
        {
            this.sqlConnection = new SqlConnection() { ConnectionString = connectionString };
            this.sqlConnection.Open();
        }

        private void CloseConnection()
        {
            this.sqlConnection.Close();
        }

        public void InsertAuto(Car car)
        {
            string sql = string.Format("Insert into Inventory" + "(Id, Make, Color, PetName) Values" + "('{0}','{1}','{2}','{3}')", car.ID, car.Make, car.Color, car.PetName);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertAuto(int id, string color, string make, string petName)
        {
            string sql = string.Format("Insert Into Inventory" + "(Id, Make, Color, PetName) Values" + "(@Id, @Make, @Color, @PetName)");
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConnection))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Id";
                param.Value = id;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Make";
                param.Value = make;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Color";
                param.Value = color;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@PetName";
                param.Value = petName;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertCarUsingTransaction(Car car)
        {
            SqlTransaction tx = null;
            try
            {
                string sql = string.Format("Insert into Inventory" + "(Id, Make, Color, PetName) Values" + "('{0}','{1}','{2}','{3}')", car.ID, car.Make, car.Color, car.PetName);
                SqlCommand cmdInsert = new SqlCommand(sql, this.sqlConnection);
                
                tx = this.sqlConnection.BeginTransaction();
                cmdInsert.Transaction = tx;
                cmdInsert.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : the same car is already into database");
                if (tx != null)
                {
                    tx.Rollback();
                }
            }
            finally
            {
                tx = null;
            }
        }

        public void DeleteCar(string id)
        {
            string sql = string.Format("Delete from Inventory WHERE Id='{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConnection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception : Car with the same id is absent!");
                }
            }
        }

        public void UpdateCarPetName(string id, string newPetName)
        {
            string sql = string.Format("UPDATE Inventory Set PetName='{0}' WHERE Id='{1}'", newPetName,id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public List<Car> GetAllInventoryAsList()
        {
            List<Car> inv = new List<Car>();
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConnection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inv.Add(new Car
                    {
                        ID = Convert.ToString(dr["Id"]),
                        Color = (string)dr["Color"],
                        Make = (string)dr["Make"],
                        PetName = (string)dr["PetName"]
                    });
                }
                dr.Close();
            }
            return inv;
        }

        public DataTable GetAllInventoryAsDataTable()
        {
            DataTable inv = new DataTable();
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConnection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                inv.Load(dr);
                dr.Close();
            }
            return inv;
        }

        public string LookUpPetName(string id)
        {
            string sql = String.Format("Select * From Inventory WHERE Id='{0}'",id);
            string result = String.Empty;
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConnection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = dr["PetName"].ToString();
                }
                dr.Close();
            }
            return result;
        }
    }
}
