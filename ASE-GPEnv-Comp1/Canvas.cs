using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    class Canvas
    {
        Pen pen;
        float penWidth;
        Color penColor;
        PenPosition penPosition;

        Graphics graphics;

        bool hasInitializedPosition = false;


        public Canvas(Color penColor, float penWidth, Graphics  graphics)
        {
            this.pen = new Pen(Color.Red, penWidth);
            this.graphics = graphics;
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
                Debug.WriteLine("Waring! No position defined, setting position to (25,25)");
                this.penPosition = new PenPosition(25, 25);
            }

            int radius = 5;
            this.graphics.DrawEllipse(pen, this.penPosition.posX - radius, this.penPosition.posY - radius, 2 * radius, 2 * radius);
        }

        public void clearCanvas() {
            this.graphics.Clear(Color.White);

        }


    }
}
