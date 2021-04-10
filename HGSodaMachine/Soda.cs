using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HGSodaMachine
{
    public class Soda
    {
        public string Name { get; set; }        
        public int Price { get; set; }
        public int Stock { get; set; }
        
        public Soda(string name, int price,int stock)
        {
            this.Name = name;            
            this.Price = price;
            this.Stock = stock;
        }
    }
}
