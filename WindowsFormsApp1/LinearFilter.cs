using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class LinearFilter: Filters
    {
        byte colorRMax;
        byte colorGMax;
        byte colorBMax;
        byte colorRMin;
        byte colorGMin;
        byte colorBMin;
        public LinearFilter()
        {

        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            colorRMax = sourceImage.GetPixel(0, 0).R;
            colorGMax = sourceImage.GetPixel(0, 0).G;
            colorBMax = sourceImage.GetPixel(0, 0).B;
            colorRMin = sourceImage.GetPixel(0, 0).R;
            colorGMin = sourceImage.GetPixel(0, 0).G;
            colorBMin = sourceImage.GetPixel(0, 0).B;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    if (colorRMax < color.R) colorRMax = color.R;
                    if (colorGMax < color.G) colorGMax = color.G;
                    if (colorBMax < color.B) colorBMax = color.B;

                    if (colorRMin > color.R) colorRMin = color.R;
                    if (colorGMin > color.G) colorGMin = color.G;
                    if (colorBMin > color.B) colorBMin = color.B;
                }
            }



            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {


            Color sourceColor = sourceImage.GetPixel(x, y);

            byte red = (byte)((sourceColor.R - colorRMin) * ((255 - 0) / (byte)(colorRMax - colorRMin)));
            
            byte green = (byte)((sourceColor.G - colorGMin) * ((255 - 0) / (byte)(colorGMax - colorGMin)));
            
            byte blue = (byte)((sourceColor.B - colorBMin) * ((255 - 0) / (byte)(colorBMax - colorBMin)));
            
            Color resultColor = Color.FromArgb(red, green, blue);
            return resultColor;
        }

    
    }
}
