using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GPEnv_Comp1
{
    public partial class MainUI_AseGPL1 : Form
    {
        Graphics canvasPanelGraphics;
        Canvas canvas;
        CommandParser parser;
        public MainUI_AseGPL1()
        {
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileBrowser = new OpenFileDialog();

            openFileBrowser.Title = "Browse for a .gpl file";
            openFileBrowser.Filter = "Graphics Programming Language files (.gpl)|*.gpl"; 

            if (openFileBrowser.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileBrowser.FileName;

                if (Path.GetExtension(selectedFilePath).Equals(".gpl"))
                {
                    try
                    {
                        string graphicsProgram = File.ReadAllText(selectedFilePath);
                        this.programTextBox.Text = graphicsProgram;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading the file. Try other file."+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a text file with the .txt extension.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
            this.canvasPanelGraphics = e.Graphics;

            this.canvas = new Canvas(Color.Red, 2, canvasPanel, commandsHistoryTextBox, outputTextBox, commandTextBox);
            parser = new CommandParser(this.canvas, this.shouldClearTextCheckBox);
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
                parser.executeOneCommand(commandText);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string s = "Serina  ";
     
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
            SaveFileDialog saveBrowser = new SaveFileDialog();

            saveBrowser.Title = "Save to a .gpl file";
            saveBrowser.Filter = "Graphics Programming Language files (.gpl)|*.gpl"; ;

           

            if (saveBrowser.ShowDialog() == DialogResult.OK)
            {
                string gplFilePath = saveBrowser.FileName;

                try
                {
                    string graphicsProgram = programTextBox.Text;
                    File.WriteAllText(gplFilePath, graphicsProgram);

                    MessageBox.Show("Program saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving program file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
