using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Sharpness2Filter: MatrixFilter
    {
        public Sharpness2Filter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 0] = -1;
            kernel[0, 1] = -1;
            kernel[0, 2] = -1;

            kernel[1, 0] = -1;
            kernel[1, 1] = 9;
            kernel[1, 2] = -1;

            kernel[2, 0] = -1;
            kernel[2, 1] = -1;
            kernel[2, 2] = -1;


        }
    }
}
