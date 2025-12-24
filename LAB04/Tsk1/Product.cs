using System;

namespace ProductApp
{
    public class Product
    {
        
        private string _name;
        private decimal _price;
        private int _quantity;

        
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            
            Price = price;
            Quantity = quantity;
        }

    
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

     
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Цена не может быть отрицательной.");
                }
                _price = value;
            }
        }

   
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количество не может быть отрицательным.");
                }
                _quantity = value;
            }
        }


        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }

        public void PrintInfo()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Товар: {Name}");
            Console.WriteLine($"Цена за ед.: {Price:C}"); 
            Console.WriteLine($"Количество: {Quantity} шт.");
            Console.WriteLine($"Общая стоимость: {GetTotalCost():C}");
            Console.WriteLine("--------------------------------");
        }
    }
}