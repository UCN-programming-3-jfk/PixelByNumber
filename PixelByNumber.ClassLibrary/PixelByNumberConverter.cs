using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;

namespace PixelByNumber.ClassLibrary
{
    public static class PixelByNumberConverter
    {
        [SupportedOSPlatform("windows")]
        public static string ToNumberstring(this Bitmap bitmapToConvert)
        {
            if (!ContainsOnlyBlackAndWhite(bitmapToConvert))
            {
                throw new ArgumentException("Bitmap must only contain black and white pixels");
            }

            var pixelWidth = bitmapToConvert.Width;
            var pixelHeight = bitmapToConvert.Height;

            StringBuilder stringBuilder = new();
            for (int y = 0; y < pixelHeight; y++)
            {
                int x = 0;
                int currentRunLength = 0;
                var lastPixelColor = Color.White;
                do
                {
                    
                    var currentPixelColor = bitmapToConvert.GetPixel(x, y);
                    if (!currentPixelColor.ColorEquals(lastPixelColor))
                    {
                        stringBuilder.Append(currentRunLength + ",");
                        currentRunLength = 0;
                        lastPixelColor = currentPixelColor;
                        
                    }
                    currentRunLength++;
                    x++;
                } while (x < pixelWidth);
                    stringBuilder.AppendLine(currentRunLength.ToString()); 
                
            }

            return stringBuilder.ToString();
        }

        [SupportedOSPlatform("windows")]
        private static bool ContainsOnlyBlackAndWhite(this Bitmap bitmapToConvert)
        {
            if (bitmapToConvert == null)
                throw new ArgumentNullException(nameof(bitmapToConvert));

            int width = bitmapToConvert.Width;
            int height = bitmapToConvert.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = bitmapToConvert.GetPixel(x, y);
                    if (!(pixel.ToArgb() == Color.Black.ToArgb() || pixel.ToArgb() == Color.White.ToArgb()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [SupportedOSPlatform("windows")]
        public static Bitmap ToBitmap(this string numberString)
        {
            if (!IsValidPixelByNumberString(numberString))
            {
                throw new ArgumentException("Invalid format. Are you missing a comma or do the pixel sums in all lines differ?");
            }
            var size = numberString.ToSize();
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            var y = 0;
            foreach (var line in numberString.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                var runs = line.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList().Select(value => int.Parse(value));
                var currentColor = Color.White;
                var x = 0;
                foreach (var run in runs)
                {
                    for (int i = 0; i < run; i++)
                    {
                        bmp.SetPixel(x, y, currentColor);
                        x++;
                    }
                    currentColor = currentColor== Color.White ? Color.Black : Color.White;
                }
                y++;
            }
            
            return bmp;
        }


        private static bool ColorEquals(this Color color1, Color color2)
        {
            return color1.A.Equals(color2.A) &&
                color1.R.Equals(color2.R) &&
                color1.G.Equals(color2.G) &&
                color1.B.Equals(color2.B);

        }

        public static Size ToSize(this string pixelByNumberstring)
        {
            var lines = pixelByNumberstring.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var stringValues = lines[0].Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);

            var intValues = stringValues.ToList().Select(item => int.Parse(item));

            return new Size(intValues.Sum(), lines.Length);

        }

        public static bool IsValidPixelByNumberString(this string pixelByNumberstring)
        {
            var lines = pixelByNumberstring.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();

            var lineSums = lines.Select(line => line.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList().Select( l => int.Parse(l)).Sum()).ToList();

            if (!lineSums.All(intValue => intValue.Equals(lineSums[0]))) { return false; }

            return true;
        }

        public static bool IsValidBitmap(this Bitmap pixelByNumberBitmap)
        {
            return pixelByNumberBitmap.ContainsOnlyBlackAndWhite();
        }

        public static Bitmap ToMonoChrome(this Bitmap bitmap)
        {
            if (bitmap == null) { throw new ArgumentException("Bitmap is null"); }

            Bitmap monoBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color original = bitmap.GetPixel(x, y);
                    // Calculate luminance using standard formula
                    int luminance = (int)(0.299 * original.R + 0.587 * original.G + 0.114 * original.B);
                    Color bwColor = luminance < 128 ? Color.Black : Color.White;
                    monoBitmap.SetPixel(x, y, bwColor);
                }
            }

            return monoBitmap;
        }
    }
}