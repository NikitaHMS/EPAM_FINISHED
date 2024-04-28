using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Design_Principles
{
    internal class CarInfo
    {
        private string brand;
        private int quantity;
        private double price;
        private string model;
        public string Brand
        {
            get { return brand; }
            set
            {
                if (brand == null)
                {
                    brand = value;
                }
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != 0)
                {
                    return;
                }
                quantity = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (price != 0)
                {
                    return;
                }
                price = value;
            }
        } 
        public string Model
        {
            get { return model; }
            set
            {
                if (model == null)
                {
                    model = value;
                }
            }
        }
        
        private CarInfo() { }

        private static CarInfo _instance;

        public static CarInfo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CarInfo();
            }
            
            return _instance;
        }
    }
}
