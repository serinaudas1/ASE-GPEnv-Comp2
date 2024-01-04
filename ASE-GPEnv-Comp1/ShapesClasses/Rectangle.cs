using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.ShapesClasses
{
    /// <summary>
    /// Rectangle class that inherits shape and have width and height as specific properties.
    /// </summary>
    public class Rectangle : Shape
    {
        public int width, height;
        public Rectangle() : base()
        {
            width = 25;
            height = 25;
        }
        public Rectangle(Color color, int posX, int posY, int width, int height) : base(color, posX, posY)
        {

            this.width = width; 
            this.height = height;
        }

        public override void initializeShape(Color color, PenPosition shapePosition, params int[] shapeParams)
        {
            //list[0] is width, list[1] is height
            base.initializeShape(color, shapePosition);
            this.width = shapeParams[0];
            this.height = shapeParams[1];

        }

        public override double calculateArea()
        {
            return width * height;
        }

        public override double calculatePerimeter()
        {
            return 2 * width + 2 * height;
        }


        public override string ToString()
        {
            String text = base.ToString() + "  " + this.width+","+this.height;
            return text;
        }
    }
}
