using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GreyWorldFilter: Filters
    {
        
        int averageR, averageG, averageB;
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            int sumR=0, sumG=0, sumB=0;
            int numberOfPixels = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    numberOfPixels++;
                    Color color = sourceImage.GetPixel(i, j);
                    sumR += color.R;
                    sumG += color.G;
                    sumB += color.B;
                }
            }
            averageR = sumR/numberOfPixels;
            averageG = sumG/numberOfPixels;
            averageB = sumB/numberOfPixels;


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
            int R, G, B;

            Color sourceColor = sourceImage.GetPixel(x, y);
            int avg = (averageR + averageG + averageB) / 3;

            R = sourceColor.R * avg / averageR;
            G = sourceColor.G * avg / averageG;
            B = sourceColor.B * avg / averageB;

            Color resultColor = Color.FromArgb(Clamp(R, 0, 255), Clamp(G, 0, 255), Clamp(B, 0, 255));
            return resultColor;
        }

    }
}
