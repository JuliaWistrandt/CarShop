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
            int temp;
            
            CarShop cars = new CarShop();

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
                Console.WriteLine("if you want to exit press 5");

                temp = int.Parse(Console.ReadLine());
                if (temp < 1 || temp > 5) throw new Exception("That wasn't a number, please try again.");
        
                try
                {
                    

                    switch (temp)
                    {
                        //need to insert a method to prevent empty console input from user kind of 
                        case 1:

                            Console.WriteLine("You chose to add a car");
                            Console.WriteLine("Please, insert car's model");
                            string brand = Console.ReadLine();
                            Console.WriteLine("Please, insert car's price");
                            double price = Convert.ToDouble(Console.ReadLine()); // find a method to parce string to double with current culture aim, does not read "." for the moment
                            Console.WriteLine("Please, insert car's engine");
                            string engine = Console.ReadLine();
                            cars.RegisterHandler(Display); // Delegate is here
                            cars.AddCar(brand, price, engine);

                            break;

                        case 2:
                            Console.WriteLine("Insert a name of car's model you want ot remove from the list");
                            brand = Console.ReadLine();
                            cars.RegisterHandler(Display);// Delegate is here
                            cars.RemoveCar(brand);

                            break;

                        case 3:
                            Console.WriteLine("Here is a list of all cars in sale:");
                            cars.ShowCars();
                           
                            break;

                        case 4:
                            Console.WriteLine("Here is the list of all cars we have in our shop for the moment:");
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
            
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Oops! Invalid input data: {ex.Message}\n");

                }// add few more catch bocks
                //catch (String.IsNullOrEmpty(brand)) 
                //{
                //    Console.WriteLine("y не должен быть равен 0");
                //}



                #region InputControlIdeas
                //static void Main(String[] args)
                //{
                //    int i;
                //    Console.Write(" Enter a number: ");
                //    bool result = int.TryParse(Console.ReadLine(), out i);
                //    if (result)
                //    {
                //        // your normal code
                //    }
                //    else
                //    {
                //        Console.WriteLine("That wasn't a number.");
                //    }
                //}


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

                #endregion InputControlIdeas

                }
        }


    }
    
}
