using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.ShapesClasses
{
    class ShapesFactory
    {
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToUpper(); 

            if (shapeType.Equals("TRIANGLE"))
            {
                return new Triangle();

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle();

            }
            else if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }
            else
            {
                throw new ArgumentException("Factory error: " + shapeType + " does not exist.");
                
            }


        }
    }
}
