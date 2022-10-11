using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MotionBlurFilter: MatrixFilter
    {
        public MotionBlurFilter(int k)
        {
            createMotionBlueKernel(k);
        }
        
        public void createMotionBlueKernel(int n)
        {
            kernel = new float[n, n];
            
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        kernel[i, j] = 1;
                    }
                    else
                    {
                        kernel[i, j] = 0;
                    }
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    kernel[i, j] /= n;
        }
        
    }
}
