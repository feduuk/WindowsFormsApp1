using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Opening : Filters
    {

        protected float[,] kernel = null;
        public Opening()
        {
            int MH = 3;
            int MW = 3;
            kernel = new float[MH, MW];

            kernel[0, 0] = 0;
            kernel[0, 1] = 1;
            kernel[0, 2] = 0;

            kernel[1, 0] = 1;
            kernel[1, 1] = 1;
            kernel[1, 2] = 1;

            kernel[2, 0] = 0;
            kernel[2, 1] = 1;
            kernel[2, 2] = 0;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            int MH = kernel.GetLength(0);
            int MW = kernel.GetLength(1);
            int Height = (int)sourceImage.Height;
            int Width = (int)sourceImage.Width;
            Bitmap resultImage = new Bitmap(Width, Height);
            for (int y = MH / 2; y < Height - MH / 2; y++)
            {
                worker.ReportProgress((int)((float)y / (Height - MH / 2) * 100));
                if (worker.CancellationPending)
                    return null;
                for (int x = MW / 2; x < Width - MW / 2; x++)
                {
                    Color min = Color.FromArgb(255, 255, 255);
                    for (int j = -MH / 2; j <= MH / 2; j++)
                    {
                        for (int i = -MW / 2; i <= MW / 2; i++)
                        {

                            Color source = sourceImage.GetPixel(x + i, y + j);
                            if ((kernel[i + MW / 2, j + MH / 2] != 0) && (source.R < min.R))
                            {
                                min = Color.FromArgb(source.R, min.G, min.B);
                            }
                            if ((kernel[i + MW / 2, j + MH / 2] != 0) && (source.G < min.G))
                            {
                                min = Color.FromArgb(min.R, source.G, min.B);
                            }
                            if ((kernel[i + MW / 2, j + MH / 2] != 0) && (source.B < min.B))
                            {
                                min = Color.FromArgb(min.R, min.G, source.B);
                            }
                        }
                    }

                    resultImage.SetPixel(x, y, min);

                }

            }


            return resultImage;



        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
