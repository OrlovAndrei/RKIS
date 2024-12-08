using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyVector
{
    public class ReadOnlyVector
    {
        public double X { get; }
        public double Y { get; }

        public ReadOnlyVector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public ReadOnlyVector Add(ReadOnlyVector other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return new ReadOnlyVector(X + other.X, Y + other.Y);
        }

        public ReadOnlyVector WithX(double newX)
        {
            return new ReadOnlyVector(newX, Y);
        }

        public ReadOnlyVector WithY(double newY)
        {
            return new ReadOnlyVector(X, newY);
        }
    }
}
