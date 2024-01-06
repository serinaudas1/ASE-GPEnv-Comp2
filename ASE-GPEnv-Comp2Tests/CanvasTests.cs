using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_GPEnv_Comp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp2.Tests
{
    [TestClass()]
    public class CanvasTests
    {
        string sampleProgram = "circle 10";
        string sampleProgramPath = "c:\\gpl_workspace\\sample_script.gpl";

        /// <summary>
        /// Unit test for saving program to file, to check if button press event handler saves the program file to storage.
        /// Example Commands:
        ///     Click on Save button and Select Location to save along with program file name.
        /// Expected Behaviours: Store the whole program typed in editor to a file
        /// Generated Result: Stored the whole program typed in editor to a file
        /// Test Status: Passed
        /// </summary>
        [TestMethod()]
        public void storeProgramToFileTest()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;

            try
            {
                bool hasStoreSuccessFully = mainUI.canvas.storeProgramToFile(sampleProgramPath, sampleProgram);
                Assert.IsTrue(hasStoreSuccessFully);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed: " + ex.Message);
            }

        }



        /// <summary>
        /// Unit test for loading program from saved file to program editor, 
        /// to check if button press event handler loads the program from file correctly on editor. 
        /// Example Commands:
        ///     Click on Load button and Select Location of program file (only .gpl)
        /// Expected Behaviours: Load the program from selected file to Program Editor box.
        /// Generated Result: Loaded the program from selected file to Program Editor box.
        /// Test Status: Passed
        /// </summary>
        [TestMethod()]
        public void readProgramFromFileTest()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;

            try
            {
                string loadedProgram  = mainUI.canvas.readProgramFromFile(sampleProgramPath);
                StringAssert.Contains(loadedProgram, sampleProgram, "Test Passed. Programm Loaded: "+loadedProgram);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed: " + ex.Message);
            }

        }
    }
}