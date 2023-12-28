using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1
{
    class CommandParser
    {

        public struct ParsingInfo
        {
            public int lineNumber;
            public bool isSuccessful;
            //Exceptions Class Array
        }

        public ParsingInfo checkSyntax(String command, int lineNumber)
        {
            ParsingInfo parsingInfo;
            parsingInfo.lineNumber = -1;
            parsingInfo.isSuccessful = false;

            return parsingInfo;
        }

        public void executeOneCommand(String commandTxt) {

            ParsingInfo parsingResult = checkSyntax(commandTxt, -1);
            if (parsingResult.isSuccessful) {
                // identify the command and excecute it
            }
            else
            {
                // draw or log the exception in output panels
            }


        }

        public void executeWholePrograme(String programTxt)
        {
            String[] statements = programTxt.Split('\n');
            int lineNumber = 1;
            foreach (String statement in statements) {

                ParsingInfo parsingResult = checkSyntax(statement, lineNumber++);
                if (parsingResult.isSuccessful)
                {
                    // identify the command and excecute it
                }
                else
                {
                    // draw or log the exception in output panels
                }

            }
        }

        
    }
}
