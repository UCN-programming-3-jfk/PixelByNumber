using PixelByNumber.ClassLibrary;
using System.Drawing;

namespace PixelByNumber.TestProject;

public class Tests
{
    private readonly string STRING_CONTENT = @"1,3,1
0,1,3,1
0,1,3,1
1,3,1
0,1,3,1
0,1,3,1
0,1,3,1
1,3,1";
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestBitmapToStringConversion()
    {
        //arrange
        Bitmap bmp = (Bitmap)Bitmap.FromFile("testbitmap.png");
        
        //act
        var bmpString = bmp.ToNumberstring();

        //assert

        Assert.That(bmpString.Length, Is.AtLeast(1));
    }

    [Test]
    public void TestStringToSizeConversion()
    {
        //arrange
       
        //act
        var size = STRING_CONTENT.ToSize();

        //assert

        Assert.That(size, Is.EqualTo(new Size(5,8)));
    }

    [Test]
    public void TestStringToBitmapConversion()
    {
        //arrange

        var localBitmap = (Bitmap)Image.FromFile("testbitmap.png");

        //act
        var bitmap = STRING_CONTENT.ToBitmap();
        bitmap.Save("c:\\temp\\bitmap.png");
        //assert
        Assert.That(AreBitmapsIdentical(localBitmap, bitmap), Is.True);
    }


    public static bool AreBitmapsIdentical(Bitmap bmp1, Bitmap bmp2)
    {
        if (bmp1 == null || bmp2 == null)
            throw new ArgumentNullException(bmp1 == null ? nameof(bmp1) : nameof(bmp2));

        if (bmp1.Width != bmp2.Width || bmp1.Height != bmp2.Height)
            return false;

        int width = bmp1.Width;
        int height = bmp1.Height;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (bmp1.GetPixel(x, y).ToArgb() != bmp2.GetPixel(x, y).ToArgb())
                    return false;
            }
        }
        return true;
    }

}