using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Bitmap originalImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                originalImage = image;
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            /*Bitmap resultImage = filter.processImage(image);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();*/
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гауссToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(Form2 form = new Form2())
            {
                if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int k = Int32.Parse(form.txt);
                    Filters filter = new SepiaFilter(k);
                    backgroundWorker1.RunWorkerAsync(filter);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            image = originalImage;
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int k = Int32.Parse(form.txt);
                    Filters filter = new BrightnessFilter(k);
                    backgroundWorker1.RunWorkerAsync(filter);
                }
            }
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельПоОсиYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelYFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void собельПоОсиXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelXFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter1 = new TisnenieFilter();
            backgroundWorker1.RunWorkerAsync(filter1);

        }

        

        private void сдвигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter1 = new ShiftFilter();
            backgroundWorker1.RunWorkerAsync(filter1);
        }

        private void вращениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int k = Int32.Parse(form.txt);
                    Filters filter = new RotateFilter(k);
                    backgroundWorker1.RunWorkerAsync(filter);
                }
            }

        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter1 = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter1);
        }

        private void резкостьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter1 = new Sharpness2Filter();
            backgroundWorker1.RunWorkerAsync(filter1);
        }

        private void размытиеДвиженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int k = Int32.Parse(form.txt);
                    Filters filter = new MotionBlurFilter(k);
                    backgroundWorker1.RunWorkerAsync(filter);
                }
            }
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dilation filter1 = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter1);
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Erosion filter1 = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter1);
        }

        
    }
}
