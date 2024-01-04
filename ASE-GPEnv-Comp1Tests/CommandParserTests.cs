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
                Assert.Fail(failedTestMessage(ex));


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

        [TestMethod()]
        public void checkSyntaxTest_InvalidCommands()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            //mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);

            string[] invalidTestCommands = {
                "invalid",
                "crcle 50",
                "movto 100,100"
            };
            foreach (string invalidCommand in invalidTestCommands)
            {
                try
                {
                    ParsingInfo info = parser.checkSyntax(invalidCommand, -1);
                    foreach (ParsingException parsingException in info.parsingExceptions)
                    {
                        throw parsingException;
                    }
                    Assert.Fail("Test Failed for " + invalidCommand);

                }
                catch (InvalidCommandException ex)
                {
                    StringAssert.Contains(ex.Message.ToLower(), "invalid command");

                }
            }
        }

        [TestMethod()]
        public void checkSyntaxTest_InvalidCommandParams()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            //mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);

            string[] invalidTestCommandParams = {
                "circle x",
                "moveto 100",
                "drawto 100,100,100"
            };
            foreach (string invalidCommandParam in invalidTestCommandParams)
            {
                try
                {
                    ParsingInfo info = parser.checkSyntax(invalidCommandParam, -1);
                    foreach (ParsingException parsingException in info.parsingExceptions)
                    {
                        throw parsingException;
                    }
                    Assert.Fail("Test Failed for " + invalidCommandParam);

                }
                catch (InvalidParamsException ex)
                {

                    if (invalidCommandParam == "circle x")
                        StringAssert.Contains(ex.Message.ToLower(), "invalid param type");

                    else if (invalidCommandParam == "moveto 100")
                        StringAssert.Contains(ex.invalidParamsMessage.ToLower(), "insufficient param");
                    else
                        StringAssert.Contains(ex.invalidParamsMessage.ToLower(), "too much param");


                }
            }
        }

        [TestMethod]
        public void executeOneCommandTest_moveTo()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);
            string command = "moveto 100, 100";

            try
            {
                ParsingInfo parsingResult = parser.executeOneCommand(command, -1);
                Assert.IsTrue(parsingResult.isSuccessful);
            }
            catch (InvalidCommandException ex)
            {
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command", failedTestMessage(ex));
                Assert.Fail(failedTestMessage(ex));
            
            }

            // added this to see the result of execution on screen
            MessageBox.Show("Test Completed");
        }



        [TestMethod]
        public void executeOneCommandTest_drawTo()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);
            string command = "drawto 100, 100";

            try
            {
                ParsingInfo parsingResult = parser.executeOneCommand(command, -1);
                Assert.IsTrue(parsingResult.isSuccessful);
            }
            catch (InvalidCommandException ex)
            {
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command", failedTestMessage(ex));
                Assert.Fail(failedTestMessage(ex));

            }

            // added this to see the result of execution on screen
            MessageBox.Show("Test Completed");
        }


        [TestMethod]
        public void executeOneCommandTest_clear()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);
            string command = "clear";

            MessageBox.Show("Drawing a rectangle of 200,200 at 20,20");
            parser.executeOneCommand("moveto 20, 20", -1);
            parser.executeOneCommand("rectangle 200, 200", -1);


            try
            {
                MessageBox.Show("Clearing Canvas now.");
                ParsingInfo parsingResult = parser.executeOneCommand(command, -1);
                Assert.IsTrue(parsingResult.isSuccessful);
            }
            catch (InvalidCommandException ex)
            {
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command", failedTestMessage(ex));
                Assert.Fail(failedTestMessage(ex));

            }


            MessageBox.Show("To check position reset redrawing a rectangle of 200,200");
            parser.executeOneCommand("rectangle 200, 200", -1);


            // added this to see the result of execution on screen
            MessageBox.Show("Test Completed");
        }


        [TestMethod]
        public void executeOneCommandTest_reset()
        {
            MainUI_AseGPL1 mainUI = new MainUI_AseGPL1();
            mainUI.Visible = true;
            CommandParser parser = new CommandParser(mainUI.canvas, mainUI.clearTextCB);
            string command = "reset";

            MessageBox.Show("Drawing a rectangle of 200,200 at 20,20");
            parser.executeOneCommand("moveto 20, 20", -1);
            parser.executeOneCommand("rectangle 200, 200", -1);


            try
            {
                MessageBox.Show("Clearing Cursor and Canvas now.");
                parser.executeOneCommand("clear");
                ParsingInfo parsingResult = parser.executeOneCommand(command, -1);
                Assert.IsTrue(parsingResult.isSuccessful);
            }
            catch (InvalidCommandException ex)
            {
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command", failedTestMessage(ex));
                Assert.Fail(failedTestMessage(ex));

            }


            MessageBox.Show("To check position reset redrawing a rectangle of 200,200");
            parser.executeOneCommand("rectangle 200, 200", -1);


            // added this to see the result of execution on screen
            MessageBox.Show("Test Completed");
        }

    }
}
