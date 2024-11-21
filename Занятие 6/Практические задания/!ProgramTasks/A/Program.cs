using System.Globalization;

namespace A
{
     public class City
    {
        public string Name { get; set; }
        public GeoLocation Location { get; set; }
    }

     
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
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
    }
}