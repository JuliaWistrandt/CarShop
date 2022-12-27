using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    public class CarShop 
    {
        public List<Car> carList = new List<Car>();

        public void AddCar(string brand, double price, string engine)
        {
            carList.Add(new Car(brand, price, engine));
           
        }

        public string RemoveCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
            carList.Remove(car);
            return $"Sucesfully removed";
        }

        // Not working method
        /*
         * public string DiscountCar(int i, int price)
        {
            var car = carList[i+1];
            car.Price = price;
            return $"The price has been changed to {price}.";
  
        } */

            

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


    }

    public class Car 
    {
        public Car(string brand, double price, string engine)
        {
            Brand = brand;
            Price = price;
            Engine = engine;
        }

        public string Brand { get; set; }
        public double Price { get; set; }
        public string Engine { get; set; }

     

    }



}
