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

    // Свойство: Цена за ночь
    public double Price
    {
        get => _price;
        set
        {
            ValidateNonNegative(value, nameof(Price));
            _price = value;
            RecalculateTotal();
            Notify(nameof(Price));
        }
    }

    // Свойство: Количество ночей
    public int NightsCount
    {
        get => _nightsCount;
        set
        {
            ValidatePositive(value, nameof(NightsCount));
            _nightsCount = value;
            RecalculateTotal();
            Notify(nameof(NightsCount));
        }
    }

    // Свойство: Скидка в процентах
    public double Discount
    {
        get => _discount;
        set
        {
            _discount = value;
            RecalculateTotal();
            Notify(nameof(Discount));
        }
    }

    // Свойство: Итоговая сумма
    public double Total
    {
        get => _total;
        set
        {
            ValidateNonNegative(value, nameof(Total));
            _total = value;
            RecalculateDiscount();
            Notify(nameof(Total));
        }
    }

    // Метод для пересчёта итоговой суммы
    private void RecalculateTotal()
    {
        if (_price >= 0 && _nightsCount > 0)
        {
            _total = _price * _nightsCount * (1 - _discount / 100);
            ValidateNonNegative(_total, nameof(Total));
            Notify(nameof(Total));
        }
    }

    // Метод для пересчёта скидки из итоговой суммы
    private void RecalculateDiscount()
    {
        if (_price > 0 && _nightsCount > 0)
        {
            _discount = 100 - (_total / (_price * _nightsCount)) * 100;
            if (_discount < 0)
                throw new ArgumentException("Скидка, рассчитанная исходя из общей суммы недействительна.");
            Notify(nameof(Discount));
        }
    }

    // Валидация: значение должно быть неотрицательным
    private void ValidateNonNegative(double value, string propertyName)
    {
        if (value < 0)
            throw new ArgumentException($"{propertyName} должна быть не меньше 0.");
    }

    // Валидация: значение должно быть положительным
    private void ValidatePositive(int value, string propertyName)
    {
        if (value <= 0)
            throw new ArgumentException($"{propertyName} должен быть больше 0.");
    }
}
