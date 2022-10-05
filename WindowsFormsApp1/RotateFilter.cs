using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class RotateFilter : Filters
    {
        int k;
        public RotateFilter(int k) => this.k = k;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int x0 = sourceImage.Width / 2;
            int y0 = sourceImage.Height / 2;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, Clamp((int)((i - x0) * Math.Cos(k) - (j - y0) * Math.Sin(k) + x0), 0, sourceImage.Width - 1), Clamp((int)((i - x0) * Math.Sin(k) - (j - y0) * Math.Cos(k) + y0), 0, sourceImage.Height - 1)));
                }
            }
            return resultImage;
        }
    }
}
