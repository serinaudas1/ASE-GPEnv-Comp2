using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_GPEnv_Comp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASE_GPEnv_Comp1.Exceptions;
using static ASE_GPEnv_Comp1.CommandParser;
using System.Windows.Forms;

namespace ASE_GPEnv_Comp1.Tests
{
    [TestClass()]
    public class CommandParserTests
    {
        public string failedTestMessage(ParsingException ex)
        {
            string message = ex.Message + " " + ex.getParsingExceptionMessage();
            message = message + "Test Failed! Exception should not be raised. Message: ";
            return message;    
        }
        [TestMethod()]
        public void executeOneCommandTest_ValidCommandTest()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);

            try
            {
                ParsingInfo parsingResult = parser.executeOneCommand("drawto 100, 100", -1);
                Assert.IsTrue(parsingResult.isSuccessful);
            }
            catch (InvalidCommandException ex)
            {
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command", failedTestMessage(ex));


            }

            // added this to see the result of execution on screen
            MessageBox.Show("Test Completed");
        }


        [TestMethod()]
        public void executeWholeProgramTest_ValidProgramTest()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);

            string testProgram = @"
            moveto 100,100
            pen cyan
            rectangle 100,100
            fill on
            pen yellow
            circle 20";
            mainUI.setProgramText(testProgram);

            try
            {
                bool hasPassedAll = true;
                List<ParsingInfo> parsingResults = parser.executeWholePrograme(testProgram);
                foreach (ParsingInfo parsingResult in parsingResults)
                {
                    if (!parsingResult.isSuccessful)
                    {
                        hasPassedAll = false;
                        break;
                    }
                }
                Assert.IsTrue(hasPassedAll);
   
            }
            catch (InvalidCommandException ex)
            {
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command", failedTestMessage(ex));
           
            }
            catch (InvalidParamsException ex)
            {
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command params", failedTestMessage(ex));
            }
            // added this to see the result of execution on screen
            MessageBox.Show("Test Completed");
        }


    }
}