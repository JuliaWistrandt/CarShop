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

        public string AddCar(string brand, double price, string engine)
        {
            carList.Add(new Car(brand, price, engine));
            
            //want this to shows up on consolle!!
            return $"Thank you. The vehicle is ready for sale.";

        }

        public string RemoveCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
            carList.Remove(car);
            return $"Thank you. The car was sucesfully removed.";
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


    }



}
