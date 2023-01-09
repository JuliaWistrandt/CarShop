using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
   
    public class CarShop 
    {

        CarShopStateHandler _del; // delegate is here
        public List<Car> carList = new List<Car>();
        private int carCounter = 0;


        //constrictor for the delegate
        public void RegisterHandler(CarShopStateHandler del)
        {
            _del = del;
        }


        public string AddCar(string brand, double price, string engine)
        {
            
            carList.Add(new Car(brand, price, engine));
            if (_del != null)
                _del.Invoke("Delegate notification new car appears!");
            carCounter++;
            return $"Thank you.";
        }

        public string RemoveCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
            if (_del != null && carList.Count == 0)
                _del("Delegate notification all cars are sold out!");
            return $"Thank you. The car ({brandName}) was sucesfully removed.";  
        }

      

        public string ShowCars()
        { 
            StringBuilder sb = new StringBuilder();

            int i = 1;
            foreach (Car car in carList)
            {
                
                sb.AppendLine($"\n Number: {i++},\n Brand: {car.Brand},\n Price: {car.Price},\n Engine: {car.Engine}\n\n");
                    
            }

            return sb.ToString();

        }

        public string DiscountCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
            return car.GetDiscount();
        }

        public void WareHouseSoldOut()
        {
            
            carList.Clear();
        
        }

        #region OldData

        //public event Action<Action<string>> OnWarehouseIsEmpty;

        //public void Notify(Action<string> message)
        //{
        //    message("The shop is running out of new cars to sell\nit's time to order some!");
        //}

        //public void Boost(Action<string> message)
        //{

        //    if (carList.Count == 0) OnWarehouseIsEmpty.Invoke(message);
        //}
        #endregion OldData

    }
}
