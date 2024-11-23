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
        private double total;

        public double Price
        {
            get { return price: }
            set
            {
                if (value < 0) throw new ArgumentException("Price must be non-negative.");
                price = value;
                SetNewTotal();
                Notify(nameof(Price));
            }
        }

        public int NightsCount
        {
            get { return nightsCount; }
            set
            {
                discount = value;
                SetNewTotal();
                Notyfy(nameof(Discount));
            }
        }

        public double Total
        {
            get { return total; }
            set
            {
                if (value < 0) throw new ArgumentException("Totall must be non-negative.");
                total = value;

                if (total != Price * NightsCount * (1 - discount / 100))
                    SetNewDiscount();
                Notifi(nameof(Total));
            }
        }
        public AccountingModel()
        {
            price = 0;
            nightsCount = 1;
            discount = 0;
            total = 0;
        }

        private void SetNewTotal()
        {
            Total = Price * NightsCount * (1 - discount / 100);
        }

        private void SetNewDiscount()
        {
            if (Price > 0 && NightsCount > 0)
            {
                Discount = (1 - Total / (Price * NightsCount)) * 100;
            }
            else
            {
                Discount = 0;
            }
        }
    }
}


        



