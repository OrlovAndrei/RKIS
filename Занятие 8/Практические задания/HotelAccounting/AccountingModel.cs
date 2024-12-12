using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

{
    public class AccountingModel : ModelBase
    {
        private double _price;
        private int _nightsCount;
        private double _discount;
        private double _total;

        public double Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new ArgumentException("Price cannot be negative.");
                _price = value;
                UpdateTotal();
                Notify(nameof(Price));
            }
        }

        public int NightsCount
        {
            get => _nightsCount;
            set
            {
                if (value <= 0) throw new ArgumentException("NightsCount must be positive.");
                _nightsCount = value;
                UpdateTotal();
                Notify(nameof(NightsCount));
            }
        }

        public double Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                UpdateTotal();
                Notify(nameof(Discount));
            }
        }

        public double Total
        {
            get => _total;
            set
            {
                if (value < 0) throw new ArgumentException("Total cannot be negative.");
                // Обновление Discount на основании Total
                if (Price * NightsCount == 0)
                {
                    if (value > 0) throw new ArgumentException("Cannot set Total when Price * NightsCount is zero.");
                    _total = value;
                }
                else
                {
                    _discount = 100 * (1 - (value / (Price * NightsCount)));
                    _total = value;
                }
                Notify(nameof(Total));
            }
        }

        private void UpdateTotal()
        {
            Total = Price * NightsCount * (1 - Discount / 100);
        }
    }
}
