using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GPEnv_Comp2
{

    public partial class MainUI_AseGPL1 : Form
    {
        public Canvas canvas;
        public CommandParser parser;
        public CheckBox clearTextCB;
        public MainUI_AseGPL1()
        {
            InitializeComponent();

            this.canvas = new Canvas(Color.Red, 2, canvasPanel, commandsHistoryTextBox, outputTextBox, commandTextBox, programTextBox, programTextBox2);
            parser = new CommandParser(this.canvas, this.shouldClearTextCheckBox);
            // I added this intentionally becuase can't directly call the UI compenent from family
            this.clearTextCB = this.shouldClearTextCheckBox;

        }


        public void setProgramText(string text)
        {
            this.programTextBox.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.canvas.handleLoadProgram();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {
           
            //this.canvas.moveTo(50, 50);
            //this.canvas.drawTo();
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            this.canvas.clearCanvas();
      
        }

        private void resetPenBtn_Click(object sender, EventArgs e)
        {
            this.canvas.resetPen();
        }

        private void drawRectangleBtn_Click(object sender, EventArgs e)
        {
            this.canvas.drawRectangle(100, 100);
        }

        private void moveTo100Btn_Click(object sender, EventArgs e)
        {
            this.canvas.moveTo(new PenPosition(100,100));
        }

        private void drawCircleBtn_Click(object sender, EventArgs e)
        {
            this.canvas.drawCircle(50);
        }

        private void drawTrianleBtn_Click(object sender, EventArgs e)
        {
            this.canvas.drawTriangle(100);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void setPenYellowBtn_Click(object sender, EventArgs e)
        {
            this.canvas.setPenColor(Color.Yellow);

        }

        private void setPenRedBtn_Click(object sender, EventArgs e)
        {
            this.canvas.setPenColor(Color.Red);

        }

        private void toggleFillBtn_Click(object sender, EventArgs e)
        {
            this.canvas.setPenFill(!this.canvas.shouldFill);
          
        }

        private void commandTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void commandTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char) Keys.Enter)
            {

                string commandText = Regex.Replace(commandTextBox.Text, @"\s+", " ");
                //MessageBox.Show("" + commandText.Split(' ').Length + "-" + commandText.Split(' ')[1].Length);
                parser.executeOneCommand(commandText,  -1);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
   
     
        }

        private void drawToButton_Click(object sender, EventArgs e)
        {
            canvas.drawTo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveProgramButton_Click(object sender, EventArgs e)
        {
            canvas.handleSaveProgram();
        }

        private void executeProgramButton_Click(object sender, EventArgs e)
        {


            ///<summary>Creating two threads with two separte function. mostly similar
            ///with just one difference that is the source program box.
            ///</summary>
            Thread thread1 = new Thread(() => handleFirstProgramBox(this));
            Thread thread2 = new Thread(() => handleSecondProgramBox(this));



            thread2.Start();
            thread1.Start();




            //parser.executeWholePrograme(canvas.getProgramFromEditor());
        }


        /// <summary>
        /// Function to be called with thread to execute program of FIRST program editor
        /// </summary>
        /// <param name="form">The form object containing shared resources</param>
        public void handleFirstProgramBox(ASE_GPEnv_Comp2.MainUI_AseGPL1 form)
        {

            
            form.Invoke(new Action(() =>
            {
                parser.executeWholePrograme(form.programTextBox.Text);
                //Thread.Sleep(100);
                //parser.executeWholePrograme(form.programTextBox2.Text);
            }));


        }

        /// <summary>
        /// Function to be called with thread to execute program of SECOND program editor
        /// </summary>
        /// <param name="form">The form object containing shared resources</param>
        public void handleSecondProgramBox(MainUI_AseGPL1 form)
        {

            
            form.Invoke(new Action(() =>
            {
                //parser.executeWholePrograme(form.programTextBox.Text);
                parser.executeWholePrograme(form.programTextBox2.Text);
                //Thread.Sleep(100);

            }));

            
        }
   

        private void programSyntaxCheckButton_Click(object sender, EventArgs e)
        {
            parser.checkProgramSyntax();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            parser.executeWholePrograme(canvas.getProgramFromSecondEditor());

        }
    }
}
