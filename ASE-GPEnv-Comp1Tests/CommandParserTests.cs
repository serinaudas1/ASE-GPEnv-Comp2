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
                StringAssert.Contains(ex.getParsingExceptionMessage().ToLower(), "invalid command");
                Assert.Fail();
            }

            // added this to see the result of execution on screen
            MessageBox.Show("Test Completed");
        }

        
    }
}