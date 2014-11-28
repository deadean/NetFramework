using MainProject.View.Data;
using Model.Entity;
using Model.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.Data
{
    public class CSample22Vm :ViewModelBase
    {
        #region Fields

        private IModelServices modModel = ModelServices.GetInstance();

        #endregion

        public List<Product> Products
        {
            get
            {
                return modModel.GetAllProducts();
            }
        }

        public List<Node> CategoriesNodes
        {
            get
            {
                
                var nodes = new List<Node>();

                modModel.GetAllCategories().ForEach(x =>
                {
                    var innerNodes = new List<NodeProduct>();
                    var node = new Node();
                    node.Header = x.Name;
                    node.Instance = x;
                    innerNodes.Clear();
                    x.Products.ToList().ForEach(y => innerNodes.Add(new NodeProduct() { Header = y.Name, Instance = y }));
                    node.Nodes = innerNodes;
                    nodes.Add(node);
                });

                return nodes;
            }
        }

        public List<Category> Categories
        {
            get
            {
                var res = modModel.GetAllCategories();
                Instance.dtgrdCategories.ItemsSource = res;
                return res;
            }
        }

        private string mvText = "asdfghjklkjhgfds";
        public string Text
        {
            get { return mvText; }
            set { mvText = value; this.OnPropertyChanged(x=>x.Text); }
        }

        public ICommand ChangePropertiesCommand
        {
            get { return new DelegateCommand(ChangeProperties); }
        }

        private void ChangeProperties()
        {
            Text = "UPDATE";
        }

        public CSample22 Instance { get; set; }
    }
}
