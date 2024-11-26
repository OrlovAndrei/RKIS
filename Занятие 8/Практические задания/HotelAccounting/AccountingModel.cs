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
            set => SetProperty(ref price, value, "Price", v => v >= 0, "Price must be non-negative.");
        }

        public int NightsCount
        {
            get => nightsCount;
            set => SetProperty(ref nightsCount, value, "NightsCount", v => v > 0, "NightsCount must be positive.");
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
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Total must be non-negative.");
                total = value;
                Notify(nameof(Total));
            }
        }

        private void SetProperty<T>(ref T field, T value, string propertyName, Func<T, bool> validation, string errorMessage)
        {
            if (!validation(value))
                throw new ArgumentException(errorMessage);

            field = value;
            UpdateTotal();
            Notify(propertyName);
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
            var accounting = new AccountingModel();

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
