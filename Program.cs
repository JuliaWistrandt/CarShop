using System.Collections.Generic;

namespace CarShop
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            CarShop cars = new CarShop();

            #region
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
            #endregion

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

                switch (temp)
                {
                    case 1:

                        Console.WriteLine("You chose to add a car");
                        Console.WriteLine("Please, insert car's brand");
                        string brand = Console.ReadLine();
                        Console.WriteLine("Please, insert car's price");
                        double price = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Please, insert car's engine");
                        string engine = Console.ReadLine();
                        cars.AddCar(brand, price, engine);
                        break;

                    case 2:
                        Console.WriteLine("Input a brand name of a car you want ot remove from the list");
                        brand = Console.ReadLine();
                        Console.WriteLine(cars.RemoveCar(brand));

                        break;
                    case 3:
                        Console.WriteLine("Here is a list of all cars in sale:");
                        Console.WriteLine(cars.ShowCars());

                        break;
                    case 4:
                        /* not working
                         * 
                        Console.WriteLine("Enter index of the car to change its price");
                        int i = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new price");
                        price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cars.DiscountCar(i, price));
                        */
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