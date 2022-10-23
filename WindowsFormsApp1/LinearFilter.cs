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
            colorRMax = 0;
            colorGMax = 0;
            colorBMax = 0;
            colorRMin = 255;
            colorGMin = 255;
            colorBMin = 255;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    if (colorRMax < color.R) colorRMax = color.R;
                    if (colorGMax < color.G) colorRMax = color.G;
                    if (colorBMax < color.B) colorRMax = color.B;

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
            byte a = (byte)(colorRMax - colorRMin);
            if (a == 0) a = 1;
            byte red = (byte)((sourceColor.R - colorRMin) * ((255 - 0) / a));
            a = (byte)(colorGMax - colorGMin);
            if (a == 0) a = 1;
            byte green = (byte)((sourceColor.G - colorGMin) * ((255 - 0) / a));
            a = (byte)(colorBMax - colorBMin);
            if (a == 0) a = 1;
            byte blue = (byte)((sourceColor.B - colorBMin) * ((255 - 0) / a));


            //byte red = (byte)((sourceColor.R - colorRMin) * ((255 - 0) / (colorRMax - colorRMin)));
            //byte green = (byte)((sourceColor.G - colorGMin) * ((255 - 0) / (colorGMax - colorGMin)));
            //byte blue = (byte)((sourceColor.B - colorBMin) * ((255 - 0) / (colorBMax - colorBMin)));




            Color resultColor = Color.FromArgb(red, green, blue);
            return resultColor;
        }





    
    }
}
