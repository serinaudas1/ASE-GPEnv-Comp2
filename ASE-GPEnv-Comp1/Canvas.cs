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
        RichTextBox commandsHistoryTextBox;
        RichTextBox outputTextBox;


        bool hasInitializedPosition = false;
        public bool shouldFill= false;


        public Canvas(Color penColor, float penWidth, Panel panel, RichTextBox commandsHistoryTextBox, RichTextBox outputTextBox)
        {
            this.pen = new Pen(Color.Red, penWidth);
            this.canvasPanel = panel;
            this.graphics = panel.CreateGraphics();
            this.penPosition =new PenPosition();
            this.penPosition.setDefaultPosition();

            this.commandsHistoryTextBox = commandsHistoryTextBox;
            this.outputTextBox = outputTextBox;
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

        public void drawCurrentPosition(PenPosition position) {

            int radius = 1;
            this.graphics.DrawEllipse(pen, position.posX - radius, position.posY - radius, 2 * radius, 2 * radius);

        }
        public void drawTo()
        {

            if (!hasInitializedPosition)
            {
                Debug.WriteLine("Waring! No position defined, setting position to (0,0)");
                this.appendExecutionResultsToOutput("Waring! No position defined, setting position to (0,0)");
                this.penPosition.setDefaultPosition();
            }
            drawCurrentPosition(this.penPosition);
        }
            
        public void drawTo(PenPosition penPosition)
        {
            drawCurrentPosition(penPosition);

        }

        public void clearCanvas() {
            this.graphics.Clear(canvasPanel.BackColor);

        }

        public void resetPen() {
            this.penPosition.setDefaultPosition();

        }

        public void drawRectangle(int width, int height)
        {
            if (shouldFill)
            {
                Brush fillingBrush = new SolidBrush(this.pen.Color);
                this.graphics.FillRectangle(fillingBrush, this.penPosition.posX, this.penPosition.posY, width, height);
            }
            this.graphics.DrawRectangle(this.pen, this.penPosition.posX, this.penPosition.posY, width, height);

        }

        public void drawCircle(int radius)
        {
            int translatedX = this.penPosition.posX - radius;
            int translatedY = this.penPosition.posY - radius;

            if(shouldFill)
            {
                Brush fillingBrush = new SolidBrush(this.pen.Color);
                this.graphics.FillEllipse(fillingBrush, translatedX, translatedY, 2 * radius, 2 * radius);
            }
            else
                this.graphics.DrawEllipse(pen, translatedX, translatedY, 2 * radius, 2 * radius);

        }

        public void drawTriangle(int sideLength)
        {

            int halfSide = sideLength / 2;
       
            Point firstPoint = new Point(this.penPosition.posX, this.penPosition.posY - halfSide);
            Point secondPoint = new Point(this.penPosition.posX + halfSide, this.penPosition.posY);
            Point thirdPoint = new Point(this.penPosition.posX - halfSide, this.penPosition.posY);


            if (shouldFill)
            {
                Brush fillingBrush = new SolidBrush(this.pen.Color);
                this.graphics.FillPolygon(fillingBrush, new Point[] { firstPoint, secondPoint, thirdPoint });

            }
            else
            {
                this.graphics.DrawLine(pen, firstPoint, secondPoint);
                this.graphics.DrawLine(pen, secondPoint, thirdPoint);
                this.graphics.DrawLine(pen, thirdPoint, firstPoint);
            }


        }

        public void setPenColor(Color newColor) {
            this.pen.Color = newColor;
        }

        public void setPenFill(bool shouldFill)
        {
            this.shouldFill = shouldFill;
        }



        public void appendCommandToHistory(string text, bool isSuccess) {

            Color color = isSuccess ? Color.Green : Color.Red;

            text = (isSuccess? "[SUCCESS]-  ":"[FAILURE]- ")+ text + "\n";
            this.commandsHistoryTextBox.SelectionStart = commandsHistoryTextBox.TextLength;
            this.commandsHistoryTextBox.SelectionLength = 0;

            this.commandsHistoryTextBox.SelectionColor = color;
            this.commandsHistoryTextBox.AppendText(text);
            this.commandsHistoryTextBox.SelectionColor = commandsHistoryTextBox.ForeColor;
            this.commandsHistoryTextBox.ScrollToCaret();


        }
        public void appendExecutionResultsToOutput(string text) {
            text = text + "\n";
            this.outputTextBox.AppendText(text);
            this.outputTextBox.ScrollToCaret();

        }
    }
}
