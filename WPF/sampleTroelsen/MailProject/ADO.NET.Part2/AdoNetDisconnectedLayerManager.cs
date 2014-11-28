using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication;

namespace ADO.NET.Part2
{
    public class AdoNetDisconnectedLayerManager
    {
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            Sample3();
        }

        private void Sample3()
        {
            Console.WriteLine("***** Fun with Data Adapters *****\n");
            // Hard-coded connection string.
            string cnStr = @"Data Source=(LocalDB)\v11.0;Initial Catalog=AutoLot;Integrated Security=True;User ID=LIZDEVNTD\acmyk;pwd=810ambrosit";
            // Caller creates the DataSet object.
            DataSet ds = new DataSet("AutoLot");
            // Inform adapter of the Select command text and connection string.
            SqlDataAdapter dAdapt =
            new SqlDataAdapter("Select * From Inventory", cnStr);
            // Fill our DataSet with a new table, named Inventory.
            
            dAdapt.Fill(ds, "Inventory");
            // Display contents of DataSet using
            // helper method created earlier in this chapter.
            PrintDataSet(ds);
            Console.ReadLine();
        }

        [STAThread]
        private void Sample2()
        {
            Thread t = new Thread(() =>
            {
                Application app = new Application();
                app.Run(new MainWindow());
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void Sample1()
        {
            FillDataSet();
        }

        private void FillDataSet()
        {
            DataSet ds = new DataSet();

            DataTable inventoryTable = CreateDataTable();

            ds.Tables.Add(inventoryTable);

            PrintDataSet(ds);
            SaveAndLoadAsXml(ds);
        }

        public DataTable CreateDataTable()
        {
            DataColumn carIDColumn = new DataColumn("CarID", typeof(int));
            carIDColumn.ReadOnly = true;
            carIDColumn.Caption = "Car ID";
            carIDColumn.AllowDBNull = false;
            carIDColumn.Unique = true;
            carIDColumn.AutoIncrement = true;
            carIDColumn.AutoIncrementSeed = 0;
            carIDColumn.AutoIncrementStep = 1;

            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";

            DataTable inventoryTable = new DataTable("InventoryDyno");
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            DataRow row = inventoryTable.NewRow();
            row[1] = "Saab";
            row[2] = "TEST";
            row[3] = "TEST";
            inventoryTable.Rows.Add(row);

            DataRow row1 = inventoryTable.NewRow();
            row1[1] = "Saab";
            row1[2] = "TEST";
            row1[3] = "TEST1";
            inventoryTable.Rows.Add(row1);

            DataRow row2 = inventoryTable.NewRow();
            row2[1] = "Saab1";
            row2[2] = "TEST";
            row2[3] = "TEST1";
            inventoryTable.Rows.Add(row2);
            

            inventoryTable.PrimaryKey = new DataColumn[] { carIDColumn };
            return inventoryTable;
        }

        static void SaveAndLoadAsBinary(DataSet carsInventoryDS)
        {
            // Set binary serialization flag.
            carsInventoryDS.RemotingFormat = SerializationFormat.Binary;
            // Save this DataSet as binary.
            FileStream fs = new FileStream("BinaryCars.bin", FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(fs, carsInventoryDS);
            fs.Close();
            // Clear out DataSet.
            carsInventoryDS.Clear();
            // Load DataSet from binary file.
            fs = new FileStream("BinaryCars.bin", FileMode.Open);
            DataSet data = (DataSet)bFormat.Deserialize(fs);
        }

        private void SaveAndLoadAsXml(DataSet carsInventoryDS)
        {
            carsInventoryDS.WriteXml("carsDataSet.xml");
            carsInventoryDS.WriteXmlSchema("carsDataSet.xsd");

            carsInventoryDS.Clear();
            carsInventoryDS.ReadXml("carsDataSet.xml");

            PrintDataSet(carsInventoryDS);
        }

        private void PrintDataSet(DataSet ds)
        {
            // Print out the DataSet name and any extended properties.
            Console.WriteLine("DataSet is named: {0}", ds.DataSetName);
            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
            Console.WriteLine();
            // Print out each table.
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("=> {0} Table:", dt.TableName);
                // Print out the column names.
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                }
                Console.WriteLine("\n----------------------------------");

                // Print the DataTable.

                Action<DataTable> PrintTable = new Action<DataTable>((x) =>
                {
                    for (int curRow = 0; curRow < x.Rows.Count; curRow++)
                    {
                        for (int curCol = 0; curCol < x.Columns.Count; curCol++)
                        {
                            Console.Write(x.Rows[curRow][curCol].ToString() + "\t");
                        }
                        Console.WriteLine();
                    }
                });


                Action<DataTable> PrintTableWithReader = new Action<DataTable>((x) => {
                    DataTableReader dtReader = x.CreateDataReader();
                    while (dtReader.Read())
                    {
                        for (int i = 0; i < dtReader.FieldCount; i++)
                        {
                            Console.Write("{0}\t", dtReader.GetValue(i).ToString().Trim());
                        }
                        Console.WriteLine();
                    }
                    dtReader.Close();
                });

                PrintTable(dt);
                Console.WriteLine("\nPrint Table With Reader\n");
                PrintTableWithReader(dt);
            }
        }
    }
}


