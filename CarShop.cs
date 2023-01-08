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
    public class CarShop : INotifyable
    {

        public List<Car> carList = new List<Car>();
        public event Action<Action<string>> OnWarehouseIsEmpty;
        private int carCounter = 0;
     
        public void Notify(Action<string> message)
        {
            message("The shop is running out of new cars to sell\nit's time to order some!");
        }

        public void Boost(Action<string> message)
        {
            
            if (carList.Count == 0) OnWarehouseIsEmpty.Invoke(message);
        }


        public string AddCar(string brand, double price, string engine)
        {
            
            carList.Add(new Car(brand, price, engine));
            carCounter++;
            return $"Thank you. The vehicle is ready for sale.";

        }

        public string RemoveCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
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

    }
}
