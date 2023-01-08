using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarShop
{
    public class SalesManager : INotifyable
    {
        
        string nameSD;
       
        public SalesManager(string nameSD)
        {
            this.nameSD = nameSD;
        }
        public void Notify(Action<string> message)
        {
            message($"Notification for {nameSD} about new cars appears");
        }

    }
}
