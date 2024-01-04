using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.ShapesClasses
{
    /// <summary>
    /// Circle class that inherits shape and have radius as specific property.
    /// </summary>
    public class Circle : Shape
    {
        public int radius;

        public Circle() : base()
        {

        }

        public Circle(Color color, int posX, int posY, int radius) : base(color, posX, posY)
        {

            this.radius = radius; //the only thingthat is different from shape
        }


        public override void initializeShape(Color colour, PenPosition shapePosition, params int[] list)
        {
            // list[0] is radius
            base.initializeShape(colour, shapePosition);
            this.radius = list[0];


        }


        public override double calculateArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double calculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            String text = base.ToString() + "  " + this.radius;
            return text;
        }
    }
}
