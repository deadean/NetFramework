using AutoLotDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotConnectedLayer
{
    public class AutLotConnDAL:IDisposable
    {
        public void AddCar(Car car)
        {
            using (InventoryDAL dal = new InventoryDAL(this.ConnectionString))
            {
                //dal.InsertAuto(car);
                //dal.InsertAuto(Convert.ToInt32(car.ID), car.Color, car.Make, car.PetName);
                dal.InsertCarUsingTransaction(car);
            }
        }

        public string ConnectionString { get; set; }

        public void Dispose() { }

        public void UpdateCarPetName(string carID, string newCarPetName)
        {
            using (InventoryDAL dal = new InventoryDAL(this.ConnectionString))
            {
                dal.UpdateCarPetName(carID,newCarPetName);
            }
        }

        public string LookUpPetName(string id)
        {
            using (InventoryDAL dal = new InventoryDAL(this.ConnectionString))
            {
                return dal.LookUpPetName(id);
            }
        }

        public DataTable GetAllInventoryCarsAsDataTable()
        {
            using (InventoryDAL dal = new InventoryDAL(this.ConnectionString))
            {
                return dal.GetAllInventoryAsDataTable();
            }
        }

        public List<Car> GetAllCars()
        {
            //using (InventoryDAL dal = new InventoryDAL(this.ConnectionString))
            //{
            //    return dal.GetAllInventoryAsList();
            //}
            return new List<Car>();
        }

        public void DeleteCar(string id)
        {
            using (InventoryDAL dal = new InventoryDAL(this.ConnectionString))
            {
                dal.DeleteCar(id);
            }
        }
    }
}
