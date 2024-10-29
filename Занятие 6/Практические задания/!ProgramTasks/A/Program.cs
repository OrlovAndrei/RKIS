namespace A
{
    internal class Program
    {
        static void Main()
        {
            var city = new City();
            city.Name = "Novorossiysk";
	@@ -16,5 +14,17 @@ static void Main(string[] args)
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