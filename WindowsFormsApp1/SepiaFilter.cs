using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SepiaFilter : Filters
    {
        int k;
        public SepiaFilter(int k) => this.k = k;  
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.36 * sourceColor.R + sourceColor.G + sourceColor.B);
            Color resultColor = Color.FromArgb(Clamp(intensity + 2*k, 0, 255), Clamp((int)(intensity + 0.5*k), 0, 255), Clamp(intensity - 1*k, 0, 255));
            return resultColor;
        }
    }
}
