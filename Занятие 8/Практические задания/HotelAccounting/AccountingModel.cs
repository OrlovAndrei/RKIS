using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

//создайте класс AccountingModel здесь
class AccountingModel : ModelBase
{
    private double _Price;
    public double Price
    {
        get { return _Price; }
        set
        {
            if (value < 0) throw new ArgumentException();
            else
            {
                _Price = value;
                Notify(nameof(Price));
                Notify(nameof(Total));
            }
        }
    }
    private int _NightsCount;
    public int NightsCount
    {
        get { return _NightsCount; }
        set
        {
            if (value <= 0) throw new ArgumentException();
            else
            {
                _NightsCount = value;
                Notify(nameof(NightsCount));
                Notify(nameof(Total));
            }
        }
    }
    private double _Discount;
    public double Discount
    {
        get { return _Discount; }
        set
        {
            _Discount = value;
            Notify(nameof(Discount));
            Notify(nameof(this.Total));
        }
    }
    public double Total
    {
        get
        {
            return Price * NightsCount * (1 - Discount / 100);
        }
        set
        {
            if (value < 0) throw new ArgumentException();
            else
            {
                Discount += (Total / value) * 100;
                Notify(nameof(this.Total));
                Notify(nameof(Discount));
            }
        }
    }
}
