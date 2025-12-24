
using System.Text;

namespace ProductApp
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("=== Тест 1: Корректный товар ===");
            try
            {
                Product apple = new Product("Яблоки", 150.50m, 10);
                apple.PrintInfo();

               
                apple.Quantity = 20;
                Console.WriteLine($"Новое количество яблок: {apple.Quantity}");
                Console.WriteLine($"Новая общая стоимость: {apple.GetTotalCost():C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();

         
            Console.WriteLine("=== Тест 2: Ошибка в цене ===");
            try
            {
                
                Product badPriceProduct = new Product("Золото", -100m, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Перехвачено исключение]: {ex.Message}");
            }

            Console.WriteLine();

            
            Console.WriteLine("=== Тест 3: Ошибка при изменении количества ===");
            try
            {
                Product milk = new Product("Молоко", 80m, 5);
                milk.PrintInfo();

                Console.WriteLine("Пытаемся установить количество: -3");
                milk.Quantity = -3; 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Перехвачено исключение]: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}