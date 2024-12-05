namespace ReadOnlyVector
{
    public class ReadOnlyVector
    {
        // Read-only поля
        public readonly double X;
        public readonly double Y;

        // Конструктор для инициализации
        public ReadOnlyVector(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Метод Add для сложения векторов
        public ReadOnlyVector Add(ReadOnlyVector other)
        {
            return new ReadOnlyVector(X + other.X, Y + other.Y);
        }

        // Метод WithX для создания нового вектора с другим значением X
        public ReadOnlyVector WithX(double newX)
        {
            return new ReadOnlyVector(newX, Y);
        }

        // Метод WithY для создания нового вектора с другим значением Y
        public ReadOnlyVector WithY(double newY)
        {
            return new ReadOnlyVector(X, newY);
        }

        // Переопределение ToString для удобства вывода
        public override string ToString()
        {
            return $"ReadOnlyVector(X: {X}, Y: {Y})";
        }
    }
}