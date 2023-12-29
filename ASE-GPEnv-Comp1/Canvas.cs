using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1
{
    class Canvas
    {
        Pen pen;
        float penWidth;
        Color penColor;
        public Canvas(Color penColor, float penWidth)
        {
            pen = new Pen(Color.Red, penWidth);

        }
    }
}
