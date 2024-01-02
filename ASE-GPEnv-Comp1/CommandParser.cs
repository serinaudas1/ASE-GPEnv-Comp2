using ASE_GPEnv_Comp1.Exceptions;
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


    public struct GPLCommand
    {
        public string command;
        public int numberOfValidParams;
        public string stringParam; //for example pen {color}, only string param is valid param
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
            //exmple commands: fill on; fill off; pen {color}
            this.command = command;
            this.numberOfValidParams = numberOfValidParams;
            this.stringParam = stringParam;
            this.hasStringParam = true;
        }
    }

    class CommandParser
    {
    


        public GPLCommand [] allValidGPLCommands;
        Canvas canvas;



        public CommandParser(Canvas canvas) {

            this.canvas = canvas;

            allValidGPLCommands = new GPLCommand[] {
                new GPLCommand("run", 0),
                new GPLCommand("moveto", 2), //2 params: x, y
                new GPLCommand("drawto", 1), //1 param: pen
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
            public List<ParsingException> parsingExceptions;

            public void initializeParsingInfo() {
                lineNumber = -1; //-1 means it's  coming from command box instead of program box
                isSuccessful = true;
                parsingExceptions = new List<ParsingException>();
            }
        }

        public ParsingInfo checkSyntax(String command, int lineNumber)
        {
            ParsingInfo parsingInfo = new ParsingInfo();
            parsingInfo.initializeParsingInfo();


    
            if (command.Length == 0) {

                parsingInfo.parsingExceptions.Add(new InvalidCommandException("Invalid Command","Command be an empty string"));
                parsingInfo.isSuccessful = false;
                return parsingInfo;

            }

         

            bool hasFoundCommand = false;
            string[] commandSplitBySpace = command.ToLower().Split(' ');
            string inputCommand = commandSplitBySpace[0];
            foreach (GPLCommand cmd_i in allValidGPLCommands) {

                if (cmd_i.command == inputCommand) {
                    hasFoundCommand = true;


                    //check if string command found in paramters, otherwise add exception object
                    if (cmd_i.hasStringParam)
                    {
                        if (commandSplitBySpace.Length < 2)
                        {
                            parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command Param", "Please enter complete command. Hint! Add string paramter."));
                        }
                        else
                        {
                            string inputStringParam = commandSplitBySpace[1];
                            bool hasFoundStringParam = false;
                            foreach (GPLCommand cmd_j in allValidGPLCommands)
                            {
                                if (inputStringParam == cmd_j.stringParam)
                                {
                                    hasFoundStringParam = true;
                                }

                            }
                            if (!hasFoundStringParam)
                            {
                                parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command String Param", "'" + inputStringParam + "' Not a valid param"));

                            }




                        }
                    }



                    else
                    {
                        string[] lines = command.ToLower().Split(' ');
                        int numberOfInputParams = lines.Length;
                        if (cmd_i.numberOfValidParams < numberOfInputParams)
                        {
                            parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Params", "Too much parameters passed."));

                        }
                        else if (cmd_i.numberOfValidParams > numberOfInputParams)
                        {
                            parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Params", "Insufficient parameters passed."));

                        }
                        else
                        {
                            // parameter testing passed so far. time to check paramters validity
                        }
                    }


                }
            }




            if(parsingInfo.parsingExceptions.Count>0)
                parsingInfo.isSuccessful = false;
            return parsingInfo;
        }

        public void executeOneCommand(String commandTxt) {

            ParsingInfo parsingResult = checkSyntax(commandTxt, -1);
            //MessageBox.Show(""+parsingResult.parsingExceptions.Count);
            if (parsingResult.isSuccessful) {
                // identify the command and excecute it
            }
            else
            {
                foreach (ParsingException pEx in parsingResult.parsingExceptions) {

                    string outputText = pEx.Message + "\n\t" + pEx.getParsingExceptionMessage() + "\n_______________\n";
                    canvas.appendExecutionResultsToOutput(outputText);
                    //Debug.WriteLine(pEx.Message+" "+pEx.getParsingExceptionMessage());
                }
                // draw or log the exception in output panels
            }

           



            canvas.appendCommandToHistory(commandTxt, parsingResult.isSuccessful);


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
