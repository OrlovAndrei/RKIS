using System.Globalization;

namespace A
{
    internal class Program
    {
        static void Main()
        {
            var city = new City();
            city.Name = "Novorossiysk";
            city.Location = new GeoLocation();
            city.Location.Latitude = 44.43;
            city.Location.Longitude = 37.46;
            Console.WriteLine("I love {0} located at ({1}, {2})",
                city.Name,
                city.Location.Longitude.ToString(CultureInfo.InvariantCulture),
                city.Location.Latitude.ToString(CultureInfo.InvariantCulture));
        }

        class GeoLocation
        {
            public double Latitude;
            public double Longitude;
        }
        class City
        {
            public GeoLocation Location;
            public string Name;
        }

    }
}