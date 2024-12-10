using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    class AccountingModel : ModelBase
    {
        private double price;
        private int nightsCount;
        private double discount;

        public double Price
        {
            get => price;
            set
            {
                if (value < 0) throw new ArgumentException("Price must be non-negative.");
                price = value;
                Notify(nameof(Price));
                UpdateTotal();
            }
        }

        public int NightsCount
        {
            get => nightsCount;
            set
            {
                if (value <= 0) throw new ArgumentException("NightsCount must be positive.");
                nightsCount = value;
                Notify(nameof(NightsCount));
                UpdateTotal();
            }
        }

        public double Discount
        {
            get => discount;
            set
            {
                discount = value;
                Notify(nameof(Discount));
                UpdateTotal();
            }
        }

        public double Total => CalculateTotal();

        public AccountingModel()
        {
            Price = 0;
            NightsCount = 1;
            Discount = 0;
        }

        private void UpdateTotal()
        {
            Notify(nameof(Total));
        }

        private double CalculateTotal()
        {
            double calculatedTotal = Price * NightsCount * (1 - Discount / 100);
            return Math.Max(calculatedTotal, 0);
        }
    }
}