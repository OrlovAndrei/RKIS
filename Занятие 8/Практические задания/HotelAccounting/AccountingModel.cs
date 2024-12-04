using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

class AccountingModel : ModelBase
{
    private double _price;
    private int _nightsCount;
    private double _discount;
    private double _total;

    public double Price
    {
        get { return _price; }
        set
        {
            if (value >= 0) _price = value;
            else throw new ArgumentException();

            Notify(nameof(Total));
            Notify(nameof(Price));
        }
    }

    public int NightsCount
    {
        get { return _nightsCount; }
        set
        {
            if (value > 0) _nightsCount = value;
            else throw new ArgumentException();

            Notify(nameof(Total));
            Notify(nameof(NightsCount));
        }
    }

    public double Discount
    {
        get { return _discount; }
        set
        {
            _discount = value;

            Notify(nameof(Total));
            Notify(nameof(Discount));
        }
    }

    public double Total
    {
        get { return Price * NightsCount * (1 - Discount / 100); }
        set
        {
            if (value < 0)
            throw new ArgumentException();

            Discount += (Total / value) * 100;

            Notify(nameof(Discount));
            Notify(nameof(Total));
        }
    }
}

//В файле AccountingModel.cs создайте класс AccountingModel,
//унаследованный от ModelBase, со следующими свойствами.


//- double Price — цена за одну ночь. Должна быть неотрицательной.
//- int NightsCount — количество ночей. Должно быть положительным.
//- double Discount — скидка в процентах.Никаких дополнительных ограничений.
//- double Total — сумма счёта. 
//  Должна быть не отрицательна и должна быть согласована с предыдущими тремя свойствами по правилу: 
//  Total == Price* NightsCount * (1-Discount/100).


//Все поля должны иметь сеттеры.При установке Price, NightsCount и Discount
//должна соответствующим образом устанавливаться Total,
//при установке Total — соответствующим образом меняться Discount.
//В случае установки значения, нарушающего хоть одно условие целостности, необходимо выкидывать ArgumentException.


//При изменении значения любого свойства необходимо дополнительно
//сигнализировать об этом с помощью вызова метода Notify,
//передавая ему имя изменяемого свойства.
//Здесь можно воспользоваться ключевым словом nameof.