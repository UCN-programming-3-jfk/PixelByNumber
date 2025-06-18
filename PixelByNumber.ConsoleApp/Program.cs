


using PixelByNumber.ClassLibrary;
using System.Drawing;

namespace PixelByNumber.ConsoleApp;

internal class Program
{
    
    static void Main(string[] args)
    {
        if (!ValidateParametersAndWriteErrorsIfNecessary(args))
        {
            return;
        }

        FileInfo fileInfo = new FileInfo(args[0]);

        switch (fileInfo.Extension.ToUpper())
        {
            case ".PBN":
                ConvertToBitmap(fileInfo);
                return;
            case ".BMP":
            case ".PNG":
                ConvertToPbn(fileInfo);
                return;
            default:
                break;
        }
    }

    private static void ConvertToBitmap(FileInfo fileInfo)
    {
        var newFile = Path.Combine(fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(fileInfo.Name)) + ".png";
        var pixelByNumberString = File.ReadAllText(fileInfo.FullName);
        var bitmap = pixelByNumberString.ToBitmap();
        bitmap.Save(newFile);
    }

    private static void ConvertToPbn(FileInfo fileInfo)
    {
        var newFile = Path.Combine(fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(fileInfo.Name)) + ".pbn";
        var bitmap = (Bitmap)Image.FromFile(fileInfo.FullName);
        var pixelByNumberString = bitmap.ToNumberstring();
        File.WriteAllText(newFile, pixelByNumberString);
    }

    private static bool ValidateParametersAndWriteErrorsIfNecessary(string[] args)
    {
        if (args.Length != 1)
        {
            WriteUsage();
            return false;
        }

        FileInfo fileInfo = new FileInfo(args[0]);
        if (!fileInfo.Exists) {
            Console.WriteLine($"File '{fileInfo.FullName}' not found.");
            WriteUsage();
            return false;
        }

        if (!IsValidFileFormat(fileInfo))
        {
            Console.WriteLine($"File '{fileInfo.FullName}' is not a valid format. Valid formats are *.pbn, *.bmp, *.png.");
            return false;
        }

        return true;
    }

    private static bool IsValidFileFormat(FileInfo fileInfo)
    {
        return ".pbn.bmp.png".Contains(fileInfo.Extension, StringComparison.OrdinalIgnoreCase);
    }

    private static void WriteUsage()
    {
        Console.WriteLine();
        Console.WriteLine("PIXEL BY NUMBER CONSOLE CONVERTER");
        Console.WriteLine();
        Console.WriteLine("A tool for conversion between .PBN files and bitmap formats");
        Console.WriteLine("Usage: PixelByNumberConverter.exe [File to convert]");
        Console.WriteLine("Example: ");
        Console.WriteLine("Example: PixelByNumberConverter.exe 'c:\\files\\drawing.png'");
    }
}
