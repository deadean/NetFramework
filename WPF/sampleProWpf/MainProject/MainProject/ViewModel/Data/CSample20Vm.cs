﻿using Model.Entity;
using Model.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.Data
{
    public class CSample20Vm:ViewModelBase
    {
        #region Fields

        private IModelServices modModel = ModelServices.GetInstance();
        private string mvAllProducts;
        private Product mvProduct;
        private int mvIdProduct;

        #endregion

        #region Ctor

        #endregion

        #region Properties

        public Product Product
        {
            get { return mvProduct; }
            set { mvProduct = value; this.OnPropertyChanged(x => x.Product); }
        }

        public string AllProducts
        {
            get { return mvAllProducts; }
            set { mvAllProducts = value; this.OnPropertyChanged(x => x.AllProducts); }
        }

        public List<Product> Products
        {
            get
            {
                try { return modModel.GetAllProducts(); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return null;
            }
        }

        public List<Order> Orders
        {
            get { return modModel.GetAllOrders(); }
        }

        public int IdProduct
        {
            get { return mvIdProduct; }
            set { mvIdProduct = value; this.OnPropertyChanged(x => x.IdProduct); }
        }

        public List<Category> Categories
        {
            get
            {
                return modModel.GetAllCategories();
            }
        }
        
        #endregion

        #region Commands

        public ICommand ReadDb
        {
            get { return new DelegateCommand(OnReadDb); }
        }

        public ICommand GetProductCommand
        {
            get { return new DelegateCommand(GetProduct); }
        }

        public ICommand SaveProductCommand
        {
            get { return new DelegateCommand(SaveProduct); }
        }

        public ICommand SaveCommand
        {
            get { return new DelegateCommand(Save); }
        }

        

        #endregion

        #region Private Services

        private void OnDeleteItem()
        {
            this.modModel.RemoveEntity(Product);
            this.OnPropertyChanged(x=>x.Products);
        }

        private void OnReadDb()
        {
            this.TryCatch(() =>
            {
                var res1 = this.modModel.GetAllOrders();
                this.modModel.AddNewEntity(new Order() { ID = 1, Name = "UPDATE" });
                var res = this.modModel.GetAllProducts();
                AllProducts = res.Count.ToString();
                this.modModel.AddNewEntity(new Product() { ID = 1, Name = "UPDATE" });
            }, "OnReadDb");
        }

        private void GetProduct()
        {
            Product = this.modModel.GetAllProducts().FirstOrDefault(x=>x.ID==IdProduct);
            Product = Product ?? new Product() { ID = 0 };
        }

        private void SaveProduct()
        {
            this.modModel.UpdateEntity(Product);
            this.OnPropertyChanged(x=>x.Products);
        }

        private void Save()
        {
            this.modModel.SaveChanges();
            this.OnPropertyChanged(x=>x.Products);
        }
        
        #endregion
    }
}
