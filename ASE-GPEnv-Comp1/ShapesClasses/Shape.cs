using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.ShapesClasses
{
    abstract class Shape : ShapesInterface
    {
        protected Color shapeColor; 
        protected int posX, posY; 
        public Shape()
        {
            shapeColor = Color.Red;
            posX = posY = 25;
        }


        public Shape(Color color, int posX, int posY)
        {

            this.shapeColor = color;
            this.posX = posX; 
            this.posY = posY; 
           
        }

        public virtual void initializeShape(Color color, PenPosition shapePosition, params int[] shapeParams)
        {
            this.shapeColor = color;
            this.posX = shapePosition.posX;
            this.posY = shapePosition.posY;
        }


        public override string ToString()
        {
            String text = base.ToString();
            String[] sut = text.Split('.');
            text = sut[sut.Length - 1];
            return text;
        }

        public abstract double calculateArea(); 
        public abstract double calculatePerimeter(); 


    }
}
