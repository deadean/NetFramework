using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ViewModelLib.Types;

using AutoLotConnectedLayer;
using ADO.NET.Part1;
using AutoLotDAL;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample5Tab4Vm:ViewModelBase
    {
        public Sample5Tab4Vm()
        {
            using (AutLotConnDAL context = new AutLotConnDAL())
            {
                context.ConnectionString = ADOConnectedLayaerManager.GetAppSettingsDataBase();
                var cars = context.GetAllCars();
                cars.ForEach(x => Cars.Add(x));
            }
        }

        private ObservableCollection<Car> mvCars = new ObservableCollection<Car>();
        public ObservableCollection<Car> Cars
        {
            get { return mvCars; }
            set
            {
                mvCars = value;
                this.OnPropertyChanged(x=>x.Cars);

            }
        }
    }
}
