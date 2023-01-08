using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    public class Retailer : INotifyable
    {
        public event Action<Action<string>> OnNewCarAppears;

        public void Notify(Action<string> message)
        {
            message("New cars arrives from the dealership.\n");
        }
        public void Raise(Action<string> message)
        {
            var day = DateTime.Now;
            while (true)
            {
                Console.WriteLine($"Today is {day}");
                if (day.Day == 25)
                {
                    OnNewCarAppears.Invoke(message);
                }

                day = day.AddDays(1);

                Thread.Sleep(500);
            }
        }
    }
}
