using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1
{


    public struct GPLCommand
    {
        public string command;
        public int numberOfValidParams;
        public string stringParam; //for example position pen- pen is a valid string param
        public bool hasStringParam;
 


        public GPLCommand(string command, int numberOfValidParams): this()
        {
            // Example commands: run; clear; reset;
            this.command = command;
            this.numberOfValidParams = numberOfValidParams;
            this.hasStringParam = true;

        }
        public GPLCommand(string command, string stringParam, int numberOfValidParams) : this()
        {
            //exmple commands: pen draw; fill on; fill off; pen {color}
            this.command = command;
            this.numberOfValidParams = numberOfValidParams;
            this.stringParam = stringParam;
            this.hasStringParam = true;
        }
    }

    class CommandParser
    {
    


        public GPLCommand [] allValidGPLCommands;
        public CommandParser() {

            allValidGPLCommands = new GPLCommand[] {
                new GPLCommand("run", 0),
                new GPLCommand("position", "pen", 3), //3 params: pen, x, y
                new GPLCommand("draw","pen", 1), //1 param: pen
                new GPLCommand("clear", 0),
                new GPLCommand("reset", 0),
                new GPLCommand("rectangle", 2),//2 params: width, height
                new GPLCommand("circle", 1),//1 param: radius
                new GPLCommand("triangle",1),//1 param: side length

                new GPLCommand("pen", "red", 1),
                new GPLCommand("pen", "green",1),
                new GPLCommand("pen", "blue",1),
                new GPLCommand("pen", "cyan",1),
                new GPLCommand("pen", "magenta",1),
                new GPLCommand("pen", "yellow",1),

                new GPLCommand("fill","on",1),
                new GPLCommand("fill","off",1)






            };
        }

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
