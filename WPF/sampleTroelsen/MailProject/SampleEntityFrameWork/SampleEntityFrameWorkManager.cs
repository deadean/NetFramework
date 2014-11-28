using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFrameWork
{
    public class SampleEntityFrameWorkManager
    {
        public void StartSample()
        {
            Sample1();
        }

        private void Sample1()
        {
            Console.WriteLine("***** Fun with ADO.NET EF *****\n");
            AddNewRecord();
            PrintAllInventory();
            Console.WriteLine("->After remove operation<-");
            RemoveLastRecord();
            PrintAllInventory();
            Console.WriteLine("->After UPDAtTE LAST record<-");
            UpdateRecord();
            PrintAllInventory();
            Console.ReadLine();
        }

        private void UpdateRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {
                    Inventory item = context.Inventories.ToList().Last();
                    item.PetName = "UPDATE";
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddNewRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {
                    int lastID = context.Inventories.Count();
                    context.Inventories.Add(new Inventory()
                    {
                        Id = lastID,
                        Make = "Yugo",
                        Color = "Brown",
                        PetName = "Danny"
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private void RemoveLastRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {
                    Inventory inv = context.Inventories.ToList().Last();
                    context.Inventories.Remove(inv);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static void PrintAllInventory()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                foreach (Inventory c in context.Inventories)
                    Console.WriteLine(c);
            }
        }
    }
}
