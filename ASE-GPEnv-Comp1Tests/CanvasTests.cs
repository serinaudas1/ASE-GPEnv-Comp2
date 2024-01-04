using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_GPEnv_Comp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.Tests
{
    [TestClass()]
    public class CanvasTests
    {
        string sampleProgram = "moveto 10,10";
        string sampleProgramPath = "c:\\gpl_workspace\\sample_program.gpl";

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