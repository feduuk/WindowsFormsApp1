using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private TextBox[] textBox;
        private int size;
        //public int size
        //{
        //    get { return Int32.Parse(textBox1.Text); }
        //}
        public int[,] kernel
        {
            get {
                int[,] kernel = new int[size, size];
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        kernel[i, j] = Int32.Parse(textBox[index].Text);
                        index++;
                    }
                }
                return kernel;
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            size = Int32.Parse(textBox1.Text);
            textBox = new TextBox[size * size];
            Button buttonOk = new Button();
            Controls.Add(buttonOk);
            buttonOk.Text = "Ok";
            buttonOk.Location = new Point(0, 0);
            buttonOk.DialogResult = DialogResult.OK;
            int index = 0;
            for (int i = 0; i < (size); i++)
            {
                for (int j = 0; j < (size); j++)
                {

                    textBox[index] = new TextBox();
                    Controls.Add(textBox[index]);
                    textBox[index].Location = new Point(50 + i*30, 50 + j*30);
                    textBox[index].Size = new System.Drawing.Size(20, 20); ;
                    index++;
                }
            }
            
        }
    }
}
