using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    internal class Run
    {
        public void DoRun() 
        {
            CarShop cars = new CarShop();

            #region OldData
            /* cars.AddCar(
                 new Car
                 {
                     Brand = "Mercedes",
                     Price = 200.876,
                     Engine = "Diesel"
                 }

                 );

             cars.AddCar(
                 new Car
                 {
                     Brand = "Tesla",
                     Price = 223.344,
                     Engine = "Electric"
                 }
                 );

             cars.AddCar(
                 new Car
                 {
                     Brand = "Audi",
                     Price = 223.455,
                     Engine = "Bensin"
                 }
                 ); */
            #endregion OldData


            var exitMenue = false;
            Console.WriteLine("\nWelcome to the car shop, what do you want to do?\n");
            Console.WriteLine("***************************************************");


            while (!exitMenue)
            {
                // MENU

                Console.WriteLine("if you want to add a car, press 1");
                Console.WriteLine("if you want to remove a car, press 2");
                Console.WriteLine("if you want to show all car, press 3");
                Console.WriteLine("if you want to get a special price, press 4");
                Console.WriteLine("if you want to exit press 5");
                var temp = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (temp)
                {
                    //need to insert a method to prevent empty console input from user
                    case 1:

                        Console.WriteLine("You chose to add a car");
                        Console.WriteLine("Please, insert car's brand");
                        string brand = Console.ReadLine();
                        Console.WriteLine("Please, insert car's price");
                        double price = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Please, insert car's engine");
                        string engine = Console.ReadLine();
                        cars.AddCar(brand, price, engine);
                        Console.Clear();

                        break;

                    case 2:
                        Console.WriteLine("Input a brand name of a car you want ot remove from the list");
                        brand = Console.ReadLine();
                        Console.WriteLine(cars.RemoveCar(brand));
                        Console.Clear();

                        break;
                    case 3:
                        Console.WriteLine("Here is a list of all cars in sale:");
                        Console.WriteLine(cars.ShowCars());
                        Console.Clear();

                        break;
                    case 4:
                        Console.WriteLine(cars.ShowCars());
                        Console.WriteLine("Enter brand to change price:");
                        var carDiscount = Convert.ToString(Console.ReadLine());
                        Console.WriteLine(cars.DiscountCar(carDiscount));
                        Console.Clear();

                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        exitMenue = true;
                        break;
                    default:
                        Console.WriteLine("wrong option, please, try again");
                        break;

                }



            }
        }

    }
    
}
