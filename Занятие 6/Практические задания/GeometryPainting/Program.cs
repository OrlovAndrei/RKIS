using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using GeometryLibrary;
using GeometryPainting;

class Program
{
    static void Main()
    {
        
        Segment segment = new Segment(new Vector(0, 0), new Vector(4, 3));

         
        segment.SetColor(Colors.Red);

         
        Color segmentColor = segment.GetColor();
        Console.WriteLine($"Цвет сегмента: {segmentColor}");  

         
        Segment anotherSegment = new Segment(new Vector(1, 1), new Vector(2, 2));
        Console.WriteLine($"Цвет другого сегмента: {anotherSegment.GetColor()}");  

         
        Console.ReadKey();
    }
}
