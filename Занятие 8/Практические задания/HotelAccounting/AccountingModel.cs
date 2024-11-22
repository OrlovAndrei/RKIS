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
    
    public double Price {
      get { return _price; }
      set {
        if (value < 0)
        {
          throw new ArgumentException("Price должна быть неотрицательной");
        }
        _price = value;
        UpdateTotal();
        Notify(nameof(Price));
      }
    }

    public int NightsCount {
      get { return _nightsCount; }
      set {
        if (value <= 0)
        {
          throw new ArgumentException("NightsCount должен быть положительным");
        }
        _nightsCount = value;
        UpdateTotal();
        Notify(nameof(NightsCount));
      }
    }

    public double Discount {
      get { return _discount; }
      set {
        _discount = value;
        UpdateTotal();
        Notify(nameof(Discount));
      }
    }

    public double Total {
      get { return _total; }
      set {
        if (value < 0)
        {
          throw new ArgumentException("Total должен быть неотрицательным");
        }
        _total = value;
        UpdateDiscount();
        Notify(nameof(Total));
      }
    }
    
    private void UpdateTotal() => _total = _price * _nightsCount * (1 - _discount / 100);

    private void UpdateDiscount() => _discount = 100 - 100 * _total / (_price * _nightsCount);
  }
}