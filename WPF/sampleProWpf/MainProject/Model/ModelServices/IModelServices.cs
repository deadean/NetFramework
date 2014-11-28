using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelServices
{
    public interface IModelServices
    {
        #region Company

        List<Company> GetAllCompanies();
        List<Product> GetAllProducts();
        List<Category> GetAllCategories();
        List<Order> GetAllOrders();

        ObservableCollection<Product> EditableProducts { get; }
        void AddNewEntity(IEntity entity);
        void UpdateEntity(IEntity entity);
        void RemoveEntity(IEntity entity);

        #endregion

        void SaveChanges();
    }
}
