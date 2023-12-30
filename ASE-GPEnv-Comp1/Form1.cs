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
        Graphics canvasPanelGraphics;
        Canvas canvas;
        CommandParser parser;
        public MainUI_AseGPL1()
        {
            InitializeComponent();
            parser = new CommandParser();
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
            this.canvasPanelGraphics = e.Graphics;
            this.canvas = new Canvas(Color.Red, 2, canvasPanel);
            //this.canvas.moveTo(50, 50);
            //this.canvas.drawTo();
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            this.canvas.clearCanvas();
      
        }

        private void resetPenBtn_Click(object sender, EventArgs e)
        {
            this.canvas.resetPen();
        }

        private void drawRectangleBtn_Click(object sender, EventArgs e)
        {
            this.canvas.drawRectangle(100, 100);
        }

        private void moveTo100Btn_Click(object sender, EventArgs e)
        {
            this.canvas.moveTo(new PenPosition(100,100));
        }

        private void drawCircleBtn_Click(object sender, EventArgs e)
        {
            this.canvas.drawCircle(50);
        }

        private void drawTrianleBtn_Click(object sender, EventArgs e)
        {
            this.canvas.drawTriangle(100);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void setPenYellowBtn_Click(object sender, EventArgs e)
        {
            this.canvas.setPenColor(Color.Yellow);

        }

        private void setPenRedBtn_Click(object sender, EventArgs e)
        {
            this.canvas.setPenColor(Color.Red);

        }

        private void toggleFillBtn_Click(object sender, EventArgs e)
        {
            this.canvas.setPenFill(!this.canvas.shouldFill);
        }

        private void commandTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void commandTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char) Keys.Enter)
            {
                MessageBox.Show(commandTextBox.Text);
            }
        }
    }
}
