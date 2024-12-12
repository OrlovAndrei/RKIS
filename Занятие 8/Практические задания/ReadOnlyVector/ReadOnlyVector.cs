using System;

namespace ReadOnlyVector
{
    public class ReadOnlyVector
    {
        // Публичные свойства X и Y, доступные только для чтения
        public double X { get; }
        public double Y { get; }

        // Конструктор для инициализации вектора
        public ReadOnlyVector(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Метод для сложения векторов
        public ReadOnlyVector Add(ReadOnlyVector other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return new ReadOnlyVector(this.X + other.X, this.Y + other.Y);
        }

        // Метод для создания нового вектора с другим значением X
        public ReadOnlyVector WithX(double newX)
        {
            return new ReadOnlyVector(newX, this.Y);
        }

        // Метод для создания нового вектора с другим значением Y
        public ReadOnlyVector WithY(double newY)
        {
            return new ReadOnlyVector(this.X, newY);
        }
    }
}
