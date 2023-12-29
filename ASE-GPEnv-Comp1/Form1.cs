using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GPEnv_Comp1
{
    public partial class MainUI_AseGPL1 : Form
    {
        public MainUI_AseGPL1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {
            Canvas canvas = new Canvas(Color.Red, 2, e.Graphics);
            //canvas.moveTo(50, 50);
            canvas.drawTo();
        }
    }
}
