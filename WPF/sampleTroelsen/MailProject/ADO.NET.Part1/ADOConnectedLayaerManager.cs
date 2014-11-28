using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConnectedLayer;
using AutoLotDAL;
using System.Data;

namespace ADO.NET.Part1
{
    public class ADOConnectedLayaerManager
    {
        const string csProviderName = "provider";
        const string csDataBaseName = "dataBase";
        const string csDataBaseConfigStart = "dataBaseConfigStart";
        const string csDataBaseConfigEnd = "dataBaseConfigEnd";
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            //Sample3();
            //Sample4();
            Sample5();
        }

        private void Sample5()
        {
            Console.WriteLine("***** The AutoLot Console UI *****\n");
            bool userDone = false;
            string userCommand = "";
            using (AutLotConnDAL dalAutoLot = new AutLotConnDAL())
            {
                dalAutoLot.ConnectionString = GetAppSettingsDataBase();
                try
                {
                    ShowInstructions();
                    do
                    {
                        Console.Write("\nPlease enter your command: ");
                        userCommand = Console.ReadLine();
                        Console.WriteLine();
                        switch (userCommand.ToUpper())
                        {
                            case "I":
                                InsertNewCar(dalAutoLot);
                                break;
                            case "U":
                                UpdateCarPetName(dalAutoLot);
                                break;
                            case "D":
                                DeleteCar(dalAutoLot);
                                break;
                            case "L":
                                ListInventory(dalAutoLot);
                                break;
                            case "S":
                                ShowInstructions();
                                break;
                            case "P":
                                LookUpPetName(dalAutoLot);
                                break;
                            case "Q":
                                userDone = true;
                                break;
                            default:
                                Console.WriteLine("Bad data! Try again");
                                break;
                        }
                    }
                    while (!userDone);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void DeleteCar(AutLotConnDAL dalAutoLot)
        {
            Console.Write("Enter ID of Car to delete: ");
            string id = Console.ReadLine();
            try
            {
                dalAutoLot.DeleteCar(id);
            }
            catch (Exception ex) { }
        }
        

        private void ListInventory(AutLotConnDAL dalAutoLot)
        {
            DataTable dt = dalAutoLot.GetAllInventoryCarsAsDataTable();
            DisplayTable(dt);
        }
        private static void DisplayTable(DataTable dt)
        {
            // Print out the column names.
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n----------------------------------");
            // Print the DataTable.
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }


        private void LookUpPetName(AutLotConnDAL dalAutoLot)
        {
            Console.Write("Enter ID of Car to look up: ");
            string id = Console.ReadLine();
            Console.WriteLine("Petname of {0} is {1}.",id, dalAutoLot.LookUpPetName(id).TrimEnd()); 
        }

        private void UpdateCarPetName(AutLotConnDAL dalAutoLot)
        {
            string carID;
            string newCarPetName;

            Console.Write("Enter Car ID: ");
            carID = Console.ReadLine();

            Console.Write("Enter New Pet Name: ");
            newCarPetName = Console.ReadLine();

            dalAutoLot.UpdateCarPetName(carID, newCarPetName);
        }

        private void InsertNewCar(AutLotConnDAL dal)
        {
            int newCarID;
            string newCarColor, newCarMake, newCarPetName;

            Console.Write("Enter Car ID: ");
            newCarID = int.Parse(Console.ReadLine());

            Console.Write("Enter Car Color: ");
            newCarColor = Console.ReadLine();

            Console.Write("Enter Car Make: ");
            newCarMake = Console.ReadLine();

            Console.Write("Enter Pet Name: ");
            newCarPetName = Console.ReadLine();

            dal.AddCar(new Car()
            {
                ID = newCarID.ToString(),
                Color = newCarColor,
                Make = newCarMake,
                PetName = newCarPetName
            });
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("I: Inserts a new car.");
            Console.WriteLine("U: Updates an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: Lists current inventory.");
            Console.WriteLine("S: Shows these instructions.");
            Console.WriteLine("P: Looks up pet name.");
            Console.WriteLine("Q: Quits program.");
        }

        private void Sample4()
        {
            Car car = new Car();
            car.ID = new Random().Next(100).ToString();
            car.Make = "INSERT";
            car.PetName = "Dean";
            car.Color = "Green";
            AutLotConnDAL dalAutoLot = new AutLotConnDAL();
            dalAutoLot.ConnectionString = GetAppSettingsDataBase();
            dalAutoLot.AddCar(car);
        }

        private void Sample3()
        {
            Console.WriteLine("***** Fun with Data Readers *****\n");
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = GetAppSettingsDataBase();
                cn.Open();

                string strSQL = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(strSQL, cn);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        Console.WriteLine("-> Make: {0}, PetName: {1}, Color: {2}.",
                        myDataReader["Make"].ToString(),
                        myDataReader["PetName"].ToString(),
                        myDataReader["Color"].ToString());
                    }
                }
            }
            Console.ReadLine();
        }

        private void Sample2()
        {
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory(GetAppSettingsProvider());
            using (DbConnection cn = sqlFactory.CreateConnection())
            {
                cn.ConnectionString = GetAppSettingsDataBase();
                cn.Open();

                DbCommand cmd = sqlFactory.CreateCommand();
                Console.WriteLine("Your command object is a: {0}", cmd.GetType().Name);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Inventory";

                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    Console.WriteLine("Your data reader object is a: {0}", dr.GetType().Name);
                    Console.WriteLine("\n***** Current Inventory *****");
                    while (dr.Read())
                        Console.WriteLine("-> Car #{0} is a {1}.", dr["Id"], dr["Make"].ToString());
                }
            }
        }

        private void Sample1()
        {
            string providerName = ConfigurationManager.AppSettings[csProviderName];
            Console.WriteLine(providerName);
        }

        private string GetAppSettingsProvider()
        {
            return ConfigurationManager.AppSettings[csProviderName];
        }

        public static string GetAppSettingsDataBase()
        {
            return ConfigurationManager.AppSettings[csDataBaseConfigStart] + AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings[csDataBaseName] + ConfigurationManager.AppSettings[csDataBaseConfigEnd];
        }
    }
}
