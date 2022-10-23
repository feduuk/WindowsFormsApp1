using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MedianFilter : Filters
    {
        
        public MedianFilter()
        {
            
        }

        
    
    protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int size = 3;
            float[,] arr =  new float[size, size];
            Color[] colorArray = new Color[size * size];
            int index = 0;
            int radiusX = arr.GetLength(0) / 2;
            int radiusY = arr.GetLength(1) / 2;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    colorArray[index] = sourceImage.GetPixel(idX, idY);
                    index++;
                }
            }
            byte[] colorR = new byte[size * size];
            for(int i = 0; i < size*size; i++)
            {
                colorR[i] = colorArray[i].R;
            }
            byte[] colorG = new byte[size * size];
            for (int i = 0; i < size * size; i++)
            {
                colorG[i] = colorArray[i].G;
            }
            byte[] colorB = new byte[size * size];
            for (int i = 0; i < size * size; i++)
            {
                colorB[i] = colorArray[i].B;
            }
            Array.Sort(colorR);
            Array.Sort(colorG);
            Array.Sort(colorB);
            int middle = (size * size) / 2;
            Color resultColor = Color.FromArgb(colorR[middle], colorG[middle], colorB[middle]);
            return resultColor;
        }
        
    }
}

