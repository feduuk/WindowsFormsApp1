using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int color = Clamp((int)(0.36 * sourceColor.R + sourceColor.G + sourceColor.B), 0, 255);
            Color resultColor = Color.FromArgb(color, color, color);
            return resultColor;
        }
    }
}
