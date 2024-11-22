using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelAccounting;

class AccountingModel : ModelBase
{
    private double _price;
    public double Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException();

            _price = value;
            Notify(nameof(Price));
            Notify(nameof(Total));
        }
    }

    private int _nightsCount;
    public int NightsCount
    {
        get => _nightsCount;
        set
        {
            if (value <= 0)
                throw new ArgumentException();

            _nightsCount = value;
            Notify(nameof(NightsCount));
            Notify(nameof(Total));
        }
    }

    private double _discount;
    public double Discount
    {
        get => _discount;
        set
        {
            _discount = value;
            Notify(nameof(Discount));
            Notify(nameof(Total));
        }
    }

    public double Total
    {
        get => Price * NightsCount * (1 - Discount / 100);
        set
        {
            if (value < 0)
                throw new ArgumentException();

            Discount += (Total / value) * 100;
            Notify(nameof(Total));
            Notify(nameof(Discount));
        }
    }
}
