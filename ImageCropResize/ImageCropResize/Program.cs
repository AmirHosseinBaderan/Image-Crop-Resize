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
       
    }

    void ResizeImage()
    {
       
    }
}
