using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    //delegate
    public delegate void CarShopStateHandler(string message);
    internal class Run
    {
        public void DoRun() 
        {
            CarShop cars = new CarShop();

            _ = cars.AddCar("BMW", 1500, "Bensin");
            _ = cars.AddCar("Audi", 4500, "Diesel");
            _ = cars.AddCar("Tesla", 9500, "Electric");

            //method to print the delegate
            void Display(string message)
            {
                Console.WriteLine(message);
            }


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
                Console.WriteLine("(Action) if you want to send notification to manager about new cars, press 5");
                Console.WriteLine("(Action) if you want to see cars shortage notifications, press 6");
                Console.WriteLine("if you want to exit press 7");
                var temp = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (temp)
                {
                    //need to insert a method to prevent empty console input from user
                    case 1:

                        Console.WriteLine("You chose to add a car");
                        Console.WriteLine("Please, insert car's model");
                        string brand = Console.ReadLine();
                        Console.WriteLine("Please, insert car's price");
                        double price = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Please, insert car's engine");
                        string engine = Console.ReadLine();
                        cars.RegisterHandler(Display); // Delegate is here
                        Console.WriteLine(cars.AddCar(brand, price, engine));                                                         
                       

                        break;

                    case 2:
                        Console.WriteLine("Insert a name of car's model you want ot remove from the list");
                        brand = Console.ReadLine();
                        cars.RegisterHandler(Display);// Delegate is here
                        Console.WriteLine(cars.RemoveCar(brand));
                        
                        break;

                    case 3:
                        Console.WriteLine("Here is a list of all cars in sale:");
                        Console.WriteLine(cars.ShowCars());

                        break;

                    case 4:
                        Console.WriteLine(cars.ShowCars());
                        Console.WriteLine("Enter cars model to change it's price:");
                        var carDiscount = Console.ReadLine();
                        Console.WriteLine(cars.DiscountCar(carDiscount));

                        break;

                    case 5:
                        Console.WriteLine("Goodbye!");
                        exitMenue = true;
                        
                        break;

                    default:
                        Console.WriteLine("Wrong option, please, try again");
                        Console.Clear();

                        break;

                }

               // draft of user's input control method
                //while (true)
                //{

                //    Console.WriteLine("Enter a num between 1 and 7: ");
                //    try
                //    {
                //        int userInput = Convert.ToInt32(Console.ReadLine());
                //        if (userInput < 1 || userInput > 7)
                //        {

                //            throw new Exception(); // will imidiatelly jump to the catch block with Oops! Invalid input data message
                //        }

                //        Console.WriteLine((DayOfWeek)userInput);
                //    }
                //    catch
                //    {
                //        Console.WriteLine("Oops! Invalid input data: {0} is not a number between 1 and 7. Please try again\n");

                //    }

                //}



            }
        }


    }
    
}
