using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GPEnv_Comp1
{
    public struct PenPosition
    {
        public int posX;
        public int posY;

    
        public PenPosition(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void setDefaultPosition() {
            posX = 0;
            posY = 0;
        }
    }
    class Canvas
    {
        Pen pen;
        //float penWidth;
        //Color penColor;
        PenPosition penPosition;

        Graphics graphics;
        Panel canvasPanel;

        bool hasInitializedPosition = false;


        public Canvas(Color penColor, float penWidth, Panel panel)
        {
            this.pen = new Pen(Color.Red, penWidth);
            this.canvasPanel = panel;
            this.graphics = panel.CreateGraphics();
            this.penPosition =new PenPosition();
            this.penPosition.setDefaultPosition();
        }


        public void moveTo(PenPosition  penPosition)
        {
            this.hasInitializedPosition = true;
            this.penPosition = penPosition;
        }
 
        public void moveTo(int posX, int posY)
        {
            this.hasInitializedPosition = true;
            this.penPosition = new PenPosition(posX, posY);

        }

        public void drawTo() {

            if (!hasInitializedPosition)
            {
                Debug.WriteLine("Waring! No position defined, setting position to (0,0)");
                this.penPosition.setDefaultPosition();
            }

            int radius = 5;
            this.graphics.DrawEllipse(pen, this.penPosition.posX - radius, this.penPosition.posY - radius, 2 * radius, 2 * radius);
        }

        public void clearCanvas() {
            this.graphics.Clear(canvasPanel.BackColor);

        }

        public void resetPen() {
            this.penPosition.setDefaultPosition();

        }

        public void drawRectangle(int width, int height)
        {
            this.graphics.DrawRectangle(this.pen, this.penPosition.posX, this.penPosition.posY, width, height);

        }

        public void drawCircle(int radius)
        {
            int translatedX = this.penPosition.posX - radius;
            int translatedY = this.penPosition.posY - radius;
            this.graphics.DrawEllipse(pen, translatedX, translatedY, 2 * radius, 2 * radius);

        }

        public void drawTriangle(int sideLength)
        {

            int halfSide = sideLength / 2;
       
            Point firstPoint = new Point(this.penPosition.posX, this.penPosition.posY - halfSide);
            Point secondPoint = new Point(this.penPosition.posX + halfSide, this.penPosition.posY);
            Point thirdPoint = new Point(this.penPosition.posX - halfSide, this.penPosition.posY);


        
            this.graphics.DrawLine(pen, firstPoint, secondPoint);
            this.graphics.DrawLine(pen, secondPoint, thirdPoint);
            this.graphics.DrawLine(pen, thirdPoint, firstPoint);


        }

        public void setPenColor(Color newColor) {
            this.pen.Color = newColor;
        }

    }
}
