using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

public class AccountingModel
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
            if (value < 0)
                throw new ArgumentException("Цена не может быть отрицательной.");
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
            if (value <= 0)
                throw new ArgumentException("NightsCount должно быть больше нуля.");
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
            _discount = value; // Нет ограничений на значение Discount
            UpdateTotal();
            Notify(nameof(Discount));
        }
    }

    public double Total
    {
        get => _total;
        set
        {
            if (value < 0)
                throw new ArgumentException("Сумма не может быть отрицательной.");
            _total = value;
            UpdateDiscount();
            Notify(nameof(Total));
        }
    }

    private void UpdateTotal()
    {
        _total = _price * _nightsCount * (1 - _discount / 100);
        if (_total < 0)
            throw new ArgumentException("Общая сумма не может быть отрицательной на основе текущих значений.");
    }

    private void UpdateDiscount()
    {
        if (_price > 0 && _nightsCount > 0)
        {
            _discount = 100 * (1 - _total / (_price * _nightsCount));
        }
    }

    private void Notify(string propertyName)
    {
        Console.WriteLine($"Свойство '{propertyName}' было обновлено.");
    }
}