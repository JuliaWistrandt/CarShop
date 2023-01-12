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
        private const int maxLengthCarList = 5;
        
        private int carCounter = 0;


        //constructor for the delegate
        public void RegisterHandler(CarShopStateHandler del)
        {
            _del = del;
        }

        

        public void AddCar(string brand, double price, string engine)
        {
            // for inner message ex : Reduce aisle width in the racking area (carList)or Reduce aisle width in the racking area.Change your storage medium.
            if (this.carList.Count == maxLengthCarList)
            {
                throw new DatabaseException(message: "Oops, looks like we are running out of warehouse space.\nPlease try again later");
            }
            else
            {
                this.carList.Add((new Car(brand, price, engine)));
                _del.Invoke($"A new car is added to the carShop!\n");
                carCounter++;
            }   
        }

        public void RemoveCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
            carList.Remove(car);
            if (car is null) throw new DatabaseException(message: $"Oops, looks like there is no such car ({brandName}) in our carShop.\nPlease try again later");
            _del.Invoke($"Thank you. The car ({brandName}) was sucesfully removed.");
            
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
