using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

public class AccountingModel : ModelBase
{
    private double price;
    private int nightsCount = 1;
    private double discount;
    private double total;

    public double Price
    {
        get => price;
        set
        {
            if (value < 0) throw new ArgumentException();
            price = value;
            ResetTotal();
            Notify(nameof(Price));
        }
    }

    public int NightsCount
    {
        get => nightsCount;
        set
        {
            if (value <= 0) throw new ArgumentException();
            nightsCount = value;
            ResetTotal();
            Notify(nameof(NightsCount));
        }
    }

    public double Discount
    {
        get => discount;
        set
        {
            if (value > 100) throw new ArgumentException();
            discount = value;
            ResetTotal();
            Notify(nameof(Discount));
        }
    }

    public double Total
    {
        get => total;
        set
        {
            if (value <= 0) throw new ArgumentException();
            total = value;
            discount = 100 * (1 - total / (price * nightsCount));
            Notify(nameof(Discount));
            Notify(nameof(Total));
        }
    }

    public void ResetTotal()
    {
        total = price * nightsCount * (1 - discount / 100);
        Notify(nameof(Total));
    }
}