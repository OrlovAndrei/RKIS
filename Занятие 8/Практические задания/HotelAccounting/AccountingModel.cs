using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

public class AccountingModel : ModelBase
{
    private double _price;
    private int _nightsCount;
    private double _discount;
    private double _total;

    public double Price {
        get => _price;
        set {
            if (value < 0) throw new ArgumentException("Price должна быть не меньше 0");
            _price = value;
            UpdateTotal();
            Notify(nameof(Price));
        }
    }

    public int NightsCount {
        get => _nightsCount;
        set {
            if (value <= 0) throw new ArgumentException("NightsCount должен быть больше 0");
            _nightsCount = value;
            UpdateTotal();
            Notify(nameof(NightsCount));
        }
    }

    public double Discount {
        get => _discount;
        set {
            _discount = value;
            UpdateTotal();
            Notify(nameof(Discount));
        }
    }

    public double Total {
        get => _total;
        set {
            if (value < 0) throw new ArgumentException("Total не должен быть меньше 0");
            _total = value;

            if (_price > 0 && _nightsCount > 0) {
                _discount = 100 - (_total / (_price * _nightsCount)) * 100;
                if (_discount < 0) throw new ArgumentException("Скидка, рассчитанная исходя из общей суммы недействительна.");
            }
            Notify(nameof(Total));
        }
    }

    private void UpdateTotal()
    {
        if (_price >= 0 && _nightsCount > 0) {
            _total = _price * _nightsCount * (1 - _discount / 100);
            if (_total < 0) throw new ArgumentException("Неверное число");
            Notify(nameof(Total));
        }
    }
}
