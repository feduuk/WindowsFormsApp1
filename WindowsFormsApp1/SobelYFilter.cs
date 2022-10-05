using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SobelYFilter: SobelFilter
    {
        public SobelYFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 0] = -1;
            kernel[0, 1] = -2;
            kernel[0, 2] = -1;
              
            kernel[1, 0] = 0; 
            kernel[1, 1] = 0;
            kernel[1, 2] = 0;

            kernel[2, 0] = 1;
            kernel[2, 1] = 2;
            kernel[2, 2] = 1;
        }

}
}
