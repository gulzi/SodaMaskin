using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HGSodaMachine
{
    public class MoneyBank
    {
        public int TotalMoneyIn { get; private set; }
        public int CurrentUserCredit { get; private set; }
        public int TotalTransactions { get; private set; }
       

        public MoneyBank()
        {
            CurrentUserCredit = 0;
            TotalMoneyIn = 0;
            TotalTransactions = 0;
        }

        public bool InsertCoin(int coin)
        {        

            switch (coin)
            {
                case 1:
                    CurrentUserCredit += 1;
                    return true;
                case 5:
                    CurrentUserCredit += 5;
                    return true;
                case 10:
                    CurrentUserCredit += 10;
                    return true;
                case 20:
                    CurrentUserCredit += 20;
                    return true;
                default:                    
                    return false;
            }
        }

        public bool ProcessTransaction(int amount)
        {
            if (CurrentUserCredit >= amount)
            {                
                CurrentUserCredit -= amount;
                return true;
            }
            return false;
        }

        public int ReturnCredit()
        {
            int toCustomer = CurrentUserCredit;
            CurrentUserCredit = 0;
            return toCustomer;
        }
    }
}
