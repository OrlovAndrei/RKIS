using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class ModelBase
    {
        protected void Notify(string propertyName)
        {
            // Логика уведомления об изменении свойства
            Console.WriteLine($"{propertyName} has been changed.");
        }
    }

    public class AccountingModel : ModelBase
    {
        private double price;
        private int nightsCount;
        private double discount;
        private double total;

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price must be non-negative.");
                price = value;
                UpdateTotal();
                Notify(nameof(Price));
            }
        }

        public int NightsCount
        {
            get => nightsCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("NightsCount must be positive.");
                nightsCount = value;
                UpdateTotal();
                Notify(nameof(NightsCount));
            }
        }

        public double Discount
        {
            get => discount;
            set
            {
                discount = value;
                UpdateTotal();
                Notify(nameof(Discount));
            }
        }

        public double Total
        {
            get => total;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total must be non-negative.");
                // Обновляем discount на основе нового total
                if (NightsCount > 0 && Price > 0)
                {
                    discount = 100 * (1 - (value / (Price * NightsCount)));
                    if (discount < 0)
                        discount = 0; // Убедитесь, что скидка неотрицательная
                }
                total = value;
                Notify(nameof(Total));
            }
        }

        private void UpdateTotal()
        {
            Total = Price * NightsCount * (1 - Discount / 100);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AccountingModel accounting = new AccountingModel();

            // Пример использования
            try
            {
                accounting.Price = 100; // Установите цену
                accounting.NightsCount = 2; // Установите количество ночей
                accounting.Discount = 10; // Установите скидку

                Console.WriteLine($"Total: {accounting.Total}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
