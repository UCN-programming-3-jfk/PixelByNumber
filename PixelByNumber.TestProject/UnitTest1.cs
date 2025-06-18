using PixelByNumber.ClassLibrary;
using System.Drawing;

namespace PixelByNumber.TestProject;

public class Tests
{
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
}