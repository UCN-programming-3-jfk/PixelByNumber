using System.Drawing;
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
                if (y < pixelHeight-1)
                {
                    stringBuilder.AppendLine(currentRunLength.ToString()); 
                }
            }

            return stringBuilder.ToString();
        }

        [SupportedOSPlatform("windows")]
        private static bool ContainsOnlyBlackAndWhite(Bitmap bitmapToConvert)
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
    }
}