using System;

namespace ReadOnlyVector
{
    public class ReadOnlyVector
    {
        public double XCoordinate { get; }
        public double YCoordinate { get; }

        public ReadOnlyVector(double x, double y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public ReadOnlyVector Add(ReadOnlyVector otherVector)
        {
            if (otherVector == null)
                throw new ArgumentNullException(nameof(otherVector), "Parameter cannot be null.");

            return new ReadOnlyVector(XCoordinate + otherVector.XCoordinate, YCoordinate + otherVector.YCoordinate);
        }

        public ReadOnlyVector WithNewX(double newX)
        {
            return new ReadOnlyVector(newX, YCoordinate);
        }

        public ReadOnlyVector WithNewY(double newY)
        {
            return new ReadOnlyVector(XCoordinate, newY);
        }
    }
}