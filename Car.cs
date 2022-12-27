using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    public class Car : CarShop
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

        public string GetDiscount()
        {
            Price -= (Price * 0.1);
            return $"The operation has been successfully completed! Price now is: {Price}.";
        }
    }
}
