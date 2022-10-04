using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BrightnessFilter : Filters
    {
        int k;
        public BrightnessFilter(int k) => this.k = k;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(k + sourceColor.R, 0, 255), Clamp(k + sourceColor.G, 0, 255), Clamp(k + sourceColor.B, 0, 255));
            return resultColor;
        }
    }
}
