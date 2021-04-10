using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HGSodaMachine
{
    class Interface
    {
        public void DisplayInstructions()
        {

            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine("order (coke, sprite, fanta) - Order from machines buttons");
            Console.WriteLine("sms order (coke, sprite, fanta) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");

        }

        public void SendMessage(string message) {
            Console.WriteLine(message);
        }

        public void sendSms(string message) {
            // send sms using sms/api
            Console.WriteLine(message);
        }


    }
}
