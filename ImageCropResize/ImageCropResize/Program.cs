using Aspose.Imaging;
using static System.Console;


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
        RasterImage rasterImage = (RasterImage)Image.Load(path);

        var sizes = size.Split("/");

        // Define shift values for all four sides
        int leftShift = int.Parse(sizes[0]) / 2;
        int rightShift = int.Parse(sizes[0]) / 2;
        int topShift = int.Parse(sizes[1]) / 2;
        int bottomShift = int.Parse(sizes[1]) / 2;

        //Crop and save image 
        rasterImage.Crop(leftShift, rightShift, topShift, bottomShift);

        var extension = Path.GetExtension(path);
        var savePath = $"F:/Resizes/croped-{Guid.NewGuid()}{extension}";

        rasterImage.Save(savePath);
        WriteLine($"Image Croped and save in {savePath}");
    }

    void ResizeImage()
    {
        Image image = Image.Load(path);
        var sizes = size.Split("/");

        image.Resize(int.Parse(sizes[0]), int.Parse(sizes[1]));
       

        var extension = Path.GetExtension(path);
        var savePath = $"F:/Resizes/croped-{Guid.NewGuid()}{extension}";

        image.Save(savePath);
        WriteLine($"Image Resized and save in {savePath}");
    }
}
