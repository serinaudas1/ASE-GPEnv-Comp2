using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp2.ShapesClasses
{
    interface ShapesInterface
    {
        void initializeShape(Color shapeColor, PenPosition shapePosition, params int[] shapeParams);
        double calculateArea();
        double calculatePerimeter();
    }
}
