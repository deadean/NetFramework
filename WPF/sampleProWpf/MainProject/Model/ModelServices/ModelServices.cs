using EntitySqlite;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Commands;

namespace Model.ModelServices
{
    public class ModelServices:IModelServices
    {
        #region Fields

        private static IModelServices modInstance;
        private ModelContext modDbContext = new ModelContext();
        private string connectionString = @"data source=";

        const string csProviderName = "provider";
        const string csDataBaseName = "dataBase";
        const string csDataBaseConfigStart = "dataBaseConfigStart";
        const string csDataBaseConfigEnd = "dataBaseConfigEnd";
        
        #endregion

        #region Properties

        public ObservableCollection<Product> EditableProducts
        {
            get
            {
                return this.modDbContext.PRODUCTS.Local;
            }
        }

        public bool IsUseEntityFrameWork { get; set; }

        #endregion

        #region Public Services

        public ModelServices()
        {
            IsUseEntityFrameWork = true;
        }

        public static IModelServices GetInstance()
        {
            if (modInstance == null)
                modInstance = new ModelServices() { IsUseEntityFrameWork = true };
            return modInstance;
        }

        public List<Company> GetAllCompanies()
        {
            return modDbContext.COMPANY.ToList();
        }

        public List<Category> GetAllCategories()
        {
            return modDbContext.CATEGORIES.ToList();
        }

        public List<Order> GetAllOrders()
        {
            return modDbContext.ORDER.ToList();
        }

        public void SaveChanges()
        {
            this.modDbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            if (IsUseEntityFrameWork)
            {
                return modDbContext.PRODUCTS.ToList();
            }
            SQLiteConnection con = new SQLiteConnection(connectionString+this.GetAppSettingsDataBase());
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Products", con);
            List<Product> res = new List<Product>();
            try
            {
                con.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product();
                    product.ID = Convert.ToInt32(reader["id"]);
                    product.Name = reader.GetString(3);
                    res.Add(product);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }
            return res;
        }

        public void AddNewEntity(IEntity entity)
        {
            Dictionary<Type, Action<IEntity>> dict = new Dictionary<Type, Action<IEntity>>() 
            { 
                {typeof(Order),(x)=>{this.modDbContext.ORDER.Add(x as Order);}},
                {typeof(Company),(x)=>{this.modDbContext.COMPANY.Add(x as Company);}},
                {typeof(Product),(x)=>{this.modDbContext.PRODUCTS.Add(x as Product);}},
                {typeof(Category),(x)=>{this.modDbContext.CATEGORIES.Add(x as Category);}}
            };
            entity.With(x => dict.If(y => y.ContainsKey(x.GetType()), y => y[x.GetType()].Invoke(x)));
            this.modDbContext.SaveChanges();
        }

        public void UpdateEntity(IEntity entity)
        {
            this.TryCatch(() =>
            {
                Dictionary<Type, Action<IEntity>> dict = new Dictionary<Type, Action<IEntity>>() 
                { 
                    { typeof(Product),(x) => 
                        { 
                            this.modDbContext.PRODUCTS.Find(x.ID).With(y => modDbContext.Entry(y).CurrentValues.SetValues(x));
                            if (this.modDbContext.PRODUCTS.Find(x.ID) == null)
                                AddNewEntity(x);
                        }}
                };
                entity.With(x => dict.If(y => y.ContainsKey(x.GetType()), y => y[x.GetType()].Invoke(x)));
                this.modDbContext.SaveChanges();
            }, "UpdateEntity");
        }

        public void RemoveEntity(IEntity entity)
        {
            this.TryCatch(() =>
            {
                Dictionary<Type, Action<IEntity>> dict = new Dictionary<Type, Action<IEntity>>() 
                { 
                    { typeof(Product),(x) => 
                        { 
                            this.modDbContext.PRODUCTS.Find(x.ID).With(y => modDbContext.PRODUCTS.Remove((Product)x));
                        }}
                };
                entity.With(x => dict.If(y => y.ContainsKey(x.GetType()), y => y[x.GetType()].Invoke(x)));
                this.modDbContext.SaveChanges();
            }, "RemoveEntity");
        }

        public string GetAppSettingsDataBase()
        {
            return ConfigurationManager.AppSettings[csDataBaseName];
        }
        
        #endregion






    
    }
}
