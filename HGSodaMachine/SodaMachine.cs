using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HGSodaMachine
{
    public class SodaMachine
    {       
        private Interface _interface;
        private List<Soda> _inventory;
        private MoneyBank _money;
        public SodaMachine()
        {
            _interface = new Interface();
            _money = new MoneyBank();
            _inventory = new List<Soda>
            {
                new Soda("coke",15,5),
                new Soda("fanta",15,5),
                new Soda("sprite",15,5)
            };
        }
        public void Start()
        {
            
            bool power = true;
            while (power) 
            {
                _interface.DisplayInstructions();

                string command = Console.ReadLine();
                if (command.StartsWith("insert"))
                {
                    this.insertCoins(command);
                } 
                else if(command.StartsWith("order"))
                {
                    var sodaName = command.Split(' ')[1].ToLower();
                    this.processOrder(sodaName,"local");
                }
                else if (command.StartsWith("sms order"))
                {
                    var sodaName = command.Split(' ')[2].ToLower();
                    this.processOrder(sodaName,"sms");
                }
                else if (command.StartsWith("recall"))                
                {
                    if (_money.CurrentUserCredit > 0)
                    {
                        _interface.SendMessage("Please collect remaining " + _money.ReturnCredit().ToString() + " NOK");
                    }
                    else
                    {
                        _interface.SendMessage("There was nothing left");
                    }                    
                }
            }            
            Console.ReadLine();
        }
        private void dispenceSoda(Soda soda) 
        {
            _interface.SendMessage(soda.Name + " is coming out");
            soda.Stock--;            
            
        }

        private void checkOrder(Soda soda, string name,string orderType) 
        {
            if (soda.Stock > 0 && orderType == "local")
            {
                if (_money.CurrentUserCredit >= soda.Price)
                {
                    if (_money.ProcessTransaction(soda.Price))
                    {
                        dispenceSoda(soda);
                    }
                }
            }
            else if (soda.Stock > 0 && orderType == "sms") 
            {
                dispenceSoda(soda);
            }
            else if (soda.Stock == 0)
            {
                _interface.SendMessage("Sorry, no more " + soda.Name + "left");
            }
            else if (soda.Price > _money.CurrentUserCredit)
            {
                Console.WriteLine("Need NOK " + (soda.Price - _money.CurrentUserCredit) + " more");
            }
        }
        public void processOrder(string name,string orderType) {
            
            var soda = _inventory.Find(item => item.Name == name);
            if (soda != null)
            {
                checkOrder(soda, name,orderType);
            }
            else 
            {
                _interface.SendMessage("No such soda");
            }            
        }
        public void insertCoins(string input) 
        {
            if (_money.InsertCoin(int.Parse(input.Split(' ')[1])))
            {
                _interface.SendMessage("Current balance is: "+ _money.CurrentUserCredit.ToString());
            }
            else {
                _interface.SendMessage("Invalid coin, please insert valid coin");
            }
        }
    }
}
