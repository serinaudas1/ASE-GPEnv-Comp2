using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1
{
    public struct PenPosition
    {
        int posX;
        int posY;
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
        public Canvas(Color penColor, float penWidth)
        {
            pen = new Pen(Color.Red, penWidth);

        }


        public void moveTo(PenPosition  penPosition)
        {
            this.penPosition = penPosition;
        }

        public void moveTo(int posX, int posY)
        {
            this.penPosition = new PenPosition(posX, posY);

        }


    }
}
