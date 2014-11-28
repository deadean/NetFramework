using MainProject.View.Data;
using Model.Entity;
using Model.ModelServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.Data
{
    public class CSample21Vm:ViewModelBase
    {
        #region Fields

        private IModelServices modModel = ModelServices.GetInstance();
        private string mvAllProducts;
        private Product mvProduct;
        private int mvIdProduct;
        private ListCollectionView view;
        private CSample21 mvInstance;

        #endregion

        #region Ctor

        #endregion

        #region Properties

        public CSample21 Instance
        {
            get { return mvInstance; }
            set
            {
                mvInstance = value;
                
            }
        }

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

        public ICommand PriviousItemCommand
        {
            get { return new DelegateCommand(PreviousItem, () => { return view != null && view.CurrentPosition > 0; }); }
        }

        public ICommand StartCommand
        {
            get { return new DelegateCommand(Start); }
        }

        public ICommand NextItemCommand
        {
            get { return new DelegateCommand(NextItem, () => { return view!=null && view.CurrentPosition <view.Count - 1; }); }
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

        private void view_CurrentChanged(object sender, EventArgs e)
        {
            this.mvInstance.lblPosition.Text = "Record " + (view.CurrentPosition + 1).ToString() + " of " + view.Count.ToString();
        }

        private void PreviousItem()
        {

            view.MoveCurrentToPrevious();
        }

        private void Start()
        {
            if (view == null)
            {
                view = (ListCollectionView)CollectionViewSource.GetDefaultView(this.mvInstance.lstProducts.ItemsSource);
                view.CurrentChanged += view_CurrentChanged;
                view.SortDescriptions.Add(new SortDescription("Name",ListSortDirection.Descending));
                view.MoveCurrentToFirst();
                view.MoveCurrentToLast();
            }
        }

        private void NextItem()
        {
            view.MoveCurrentToNext();
        }

        private void OnDeleteItem()
        {
            this.modModel.RemoveEntity(Product);
            this.OnPropertyChanged(x => x.Products);
        }

        private void GetProduct()
        {
            Product = this.modModel.GetAllProducts().FirstOrDefault(x => x.ID == IdProduct);
            Product = Product ?? new Product() { ID = 0 };
        }

        private void SaveProduct()
        {
            this.modModel.UpdateEntity(Product);
            this.OnPropertyChanged(x => x.Products);
        }

        private void Save()
        {
            this.modModel.SaveChanges();
            this.OnPropertyChanged(x => x.Products);
        }

        #endregion
    }
}
