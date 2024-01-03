using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.ShapesClasses
{
    class Triangle: Shape
    {
        public int sideLength;

        public Triangle() : base()
        {

        }

        public Triangle(Color color, int posX, int posY, int sideLength) : base(color, posX, posY)
        {

            this.sideLength = sideLength; //the only thingthat is different from shape
        }


        public override void initializeShape(Color colour, PenPosition shapePosition, params int[] list)
        {
            // list[0] is radius
            base.initializeShape(colour, shapePosition);
            this.sideLength = list[0];


        }


        public override double calculateArea()
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(this.sideLength, 2);
        }

        public override double calculatePerimeter()
        {
            return 3 * this.sideLength;
        }

        public override string ToString()
        {
            String text = base.ToString() + "  " + this.sideLength;
            return text;
        }
    }
}
