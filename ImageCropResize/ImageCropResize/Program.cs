using static System.Console;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

while (true)
{
    Write("What is your action? Crop / Resize [C/R] : ");
    var action = ReadLine();

    Write("Your Image path : ");
    var path = ReadLine();

    Write("Enter your size for your action first width and last heigth then split with / : ");
    var size = ReadLine();

    switch (action)
    {
        case "C":
            CropImage();
            break;
        case "R":
            ResizeImage();
            break;
        default:
            WriteLine("Action Not Found :((");
            break;
    }

    void CropImage()
    {
        Image image = Bitmap.FromFile(path);

        var sizes = size.Split("/");
        var width = int.Parse(sizes[0]);
        var heigth = int.Parse(sizes[0]);

        Rectangle rectangle = new(0, 0, width, heigth);
        Bitmap cropImage = new(rectangle.Width, rectangle.Height);
        using Graphics graphics = Graphics.FromImage(cropImage);
        graphics.DrawImage(image, rectangle, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

        var extension = Path.GetExtension(path);
        var savePath = $"F:/Resizes/Resized-{Guid.NewGuid()}{extension}";

        cropImage.Save(savePath);

        WriteLine($"Image Croped and save at {savePath}");
    }

    void ResizeImage()
    {
        Image image = Bitmap.FromFile(path);

        var sizes = size.Split("/");
        var width = int.Parse(sizes[0]);
        var heigth = int.Parse(sizes[0]);

        Rectangle destRect = new(0, 0, width, heigth);
        Bitmap destImage = new(width, heigth);
        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using Graphics graphics = Graphics.FromImage(destImage);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using ImageAttributes wrapMode = new();
        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

        var extension = Path.GetExtension(path);
        var savePath = $"F:/Resizes/Resized-{Guid.NewGuid()}{extension}";

        destImage.Save(savePath);

        WriteLine($"Image Resized and save at {savePath}");
    }
}
