using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Avalonia.Controls;
using Avalonia.Media;
using Color = System.Drawing.Color;
using Image = Avalonia.Controls.Image;

namespace Fractals.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Opened += (_,__) =>
        {
            ShowImageInWindow(CreateImage());
        };
    }

    private static Bitmap CreateImage()
    {
        var pixels = new Pixels();
        var image = new Bitmap(800, 800, PixelFormat.Format24bppRgb);
        using (var g = Graphics.FromImage(image))
        {
            g.Clear(Color.Black);
        }

        DragonFractalTask.DrawDragonFractal(pixels, 100000, 123456);
        pixels.DrawToBitmap(image);

        return image;
    }

    private void ShowImageInWindow(Bitmap image)
    {
        var imageControl = this.Find<Image>("Bitmap");
        var stream = new MemoryStream();
        image.Save(stream, ImageFormat.Bmp);
        stream.Position = 0;
        imageControl.Source = new Avalonia.Media.Imaging.Bitmap(stream);
    }
}