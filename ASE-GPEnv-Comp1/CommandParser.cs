using ASE_GPEnv_Comp1.Exceptions;
using ASE_GPEnv_Comp1.ShapesClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = ASE_GPEnv_Comp1.ShapesClasses.Rectangle;

namespace ASE_GPEnv_Comp1
{


    public struct GPLCommand
    {
        public string command;
        public int numberOfValidParams;
        public string[] validParams; 
        public bool hasStringParam;
        public string commandFormat;
        public GPLCommand(string command) : this()
        {
            // Example commands: run; clear; reset;
            this.command = command;
            this.numberOfValidParams = 0;
            this.commandFormat = command;

        }


        public GPLCommand(string command, string [] validStringParams, int numberOfValidParams, string commandFormat) : this()
        {
            //exmple commands: fill on; fill off; pen {color}
            this.command = command;
            this.numberOfValidParams = numberOfValidParams;
            this.validParams = validStringParams;
            this.hasStringParam = true;
            this.commandFormat = commandFormat;
        }

        public GPLCommand(string command, int numberOfValidParams, string commandFormat) : this()
        {
            // Example commands: drawing commands;
            this.command = command;
            this.numberOfValidParams = numberOfValidParams;
            this.commandFormat = commandFormat;

        }
    }

    class CommandParser
    {
    


        public GPLCommand [] allValidGPLCommands;
        Canvas canvas;
        CheckBox shouldClearCommandCheckBox;
        ShapesFactory shapesFactory;



        public CommandParser(Canvas canvas, CheckBox shouldClearCommandCheckBox) {

            this.canvas = canvas;
            this.shouldClearCommandCheckBox = shouldClearCommandCheckBox;
            this.shapesFactory = new ShapesFactory();

            allValidGPLCommands = new GPLCommand[] {
                new GPLCommand("run"),
                new GPLCommand("moveto", 2, "moveto {x}, {y}"), //2 params: x, y
                new GPLCommand("drawto", 2, "draw {x}, {y}"), //2 params: x, y
                new GPLCommand("clear"),
                new GPLCommand("reset"),
                new GPLCommand("rectangle", 2, "rectangle {width}, {height}" ),//2 params: width, height
                new GPLCommand("circle", 1, "draw {radius}"),//1 param: radius
                new GPLCommand("triangle",1, "draw {side-length}"),//1 param: side length

                new GPLCommand("pen",
                    new string []{"red", "green", "blue", "cyan", "magenta", "yellow"},
                    1, 
                    "pen {color}"),

                new GPLCommand("fill",
                    new string []{"on", "off"},
                    1, 
                    "fill {on|off}"),

            };
        }

        public struct ParsingInfo
        {
            public int lineNumber;
            public bool isSuccessful;
            public List<ParsingException> parsingExceptions;

            public string[] parsedParameters;
            public string parsedCommand;
            



            public void initializeParsingInfo() {
                lineNumber = -1; //-1 means it's  coming from command box instead of program box
                isSuccessful = true;
                parsingExceptions = new List<ParsingException>();
            }
        }

        public string[] extractParamsFromCommand(string command) {  
            //List<string> paramsArray = new List<string>();
            string[] commandSplitBySpace = command.ToLower().Split(' ');
            string restString = "";

            int count = 0;
            foreach (string split in commandSplitBySpace) {
                if(count++>0)
                    restString = restString + split;
            }
            restString = restString.Trim();

            string[] paramsArray = restString.Split(',');
            return restString == ""? new string[] { }: paramsArray;

        }
        public ParsingInfo checkSyntax(String command, int lineNumber)
        {
            ParsingInfo parsingInfo = new ParsingInfo();
            parsingInfo.initializeParsingInfo();


    
            if (command.Length == 0) {

                parsingInfo.parsingExceptions.Add(new InvalidCommandException("Invalid Command:","Command be an empty string"));
                parsingInfo.isSuccessful = false;
                return parsingInfo;

            }

         

            bool hasFoundCommand = false;
            string[] commandSplitBySpace = command.ToLower().Split(' ');
            string inputCommand = commandSplitBySpace[0];

            string[] paramsArray = extractParamsFromCommand(command);
            parsingInfo.parsedCommand = inputCommand;
            parsingInfo.parsedParameters = paramsArray;


            //checking command validity here
            foreach (GPLCommand cmd_i in allValidGPLCommands) {

                if (cmd_i.command == inputCommand) {
                    hasFoundCommand = true;
                    break;
                }
            }
            if (!hasFoundCommand) {
                    parsingInfo.parsingExceptions.Add(new InvalidCommandException("Invalid Command:", "'" + command + "' not a valid command."));
            }
            // end of command validity check




            foreach (GPLCommand cmd_i in allValidGPLCommands)
            {
                if (cmd_i.command == inputCommand)
                {

                    //check for COUNT of required parameters
                    if (paramsArray.Length == 0 && cmd_i.numberOfValidParams!=0)
                    {
                        parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command Param:", "Please enter complete command. \n\tHint! " + cmd_i.commandFormat));
                        break;
                    }

                    else if (paramsArray.Length < cmd_i.numberOfValidParams)
                    {
                        parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command Param:", "Insufficient parameters supplied. Please enter complete command. \n\tHint! " + cmd_i.commandFormat));
                        break;
                    }
                    else if (paramsArray.Length > cmd_i.numberOfValidParams)
                    {
                        parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command Param:", "Too much parameters supplied. Please follow command format. \n\tHint! " + cmd_i.commandFormat));
                        break;
                    }

                    //check if string command found in paramters, otherwise add exception object
                    if (cmd_i.hasStringParam)
                    {
                        string validParamsString = "'" + string.Join("', '", cmd_i.validParams) + "'";


                        string inputStringParam = commandSplitBySpace[1];
                        bool hasFoundStringParam = false;

                        foreach (string validStringParam in cmd_i.validParams)
                        {
                            if (validStringParam == inputStringParam)
                            {
                                hasFoundStringParam = true;
                                break;
                            }
                        }

                        if (!hasFoundStringParam)
                        {
                            parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command String Param:", "'" + inputStringParam + "' is not a valid param for command '" + inputCommand + "'.\n\tHint: Use any of " + validParamsString));

                        }

                    }

                    // commands with integer one or more paramters
                    else
                    {

                        for (int paramNumber = 0; paramNumber < cmd_i.numberOfValidParams; paramNumber++)
                        {

                            {
                                if (!int.TryParse(paramsArray[paramNumber], out int result))
                                {
                                    parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Param Type", "Invalid paramter '"+paramsArray[paramNumber]+"'. Command '" + inputCommand + "' only accept integer paramters."));

                                }

                            }

                        }

                    }


                }
            }



            if (parsingInfo.parsingExceptions.Count>0)
                parsingInfo.isSuccessful = false;
            return parsingInfo;
        }



        void runValidGPLCommand(ParsingInfo parsingResult) {


            if (parsingResult.parsedCommand == "moveto")
            {
                int x = int.Parse(parsingResult.parsedParameters[0]);
                int y = int.Parse(parsingResult.parsedParameters[1]);
                PenPosition drawing = new PenPosition(x, y);
                canvas.moveTo(drawing);
            }

            else if (parsingResult.parsedCommand == "drawto")
            {
                int x = int.Parse(parsingResult.parsedParameters[0]);
                int y = int.Parse(parsingResult.parsedParameters[1]);
                PenPosition drawing = new PenPosition(x, y);
                canvas.drawTo(drawing);
            }

            else if (parsingResult.parsedCommand == "clear")
            {

                canvas.clearCanvas();
            }

            else if (parsingResult.parsedCommand == "reset")
            {

                canvas.resetPen();
            }

            else if (parsingResult.parsedCommand == "rectangle")
            {
                int width = int.Parse(parsingResult.parsedParameters[0]);
                int height = int.Parse(parsingResult.parsedParameters[1]);

                Rectangle rectangle = (Rectangle) shapesFactory.getShape("rectangle");
                rectangle.initializeShape(canvas.getPen().Color, canvas.getPenPosition(), width, height);

                canvas.drawRectangle(rectangle);
            }

            else if (parsingResult.parsedCommand == "rectangle")
            {
                int width = int.Parse(parsingResult.parsedParameters[0]);
                int height = int.Parse(parsingResult.parsedParameters[1]);

                Rectangle rectangle = (Rectangle)shapesFactory.getShape("rectangle");
                rectangle.initializeShape(canvas.getPen().Color, canvas.getPenPosition(), width, height);

                canvas.drawRectangle(rectangle);
            }
        }

        void throwAndLogExceptions(ParsingInfo parsingResult) {
            foreach (ParsingException parsingException in parsingResult.parsingExceptions)
            {
                try
                {
                    throw parsingException;
                }
                catch (ParsingException pEx)
                {

                    string outputText = (parsingResult.lineNumber == -1 ? "" : "[ Line No."+parsingResult.lineNumber+"]")+ pEx.Message + "\n\t" + pEx.getParsingExceptionMessage() + "\n_____________________________________________";
                    canvas.appendExecutionResultsToOutput(outputText);
                    //Debug.WriteLine(pEx.Message+" "+pEx.getParsingExceptionMessage());

                }
            }
        }


        public void executeOneCommand(String commandTxt) {

            ParsingInfo parsingResult = checkSyntax(commandTxt, -1);
            if (parsingResult.isSuccessful) {
                // identify the command and excecute it
                runValidGPLCommand(parsingResult);
            }
            else
            {
                throwAndLogExceptions(parsingResult);
            }

            canvas.appendCommandToHistory(commandTxt, parsingResult.isSuccessful);

            if (parsingResult.isSuccessful && shouldClearCommandCheckBox.Checked)
            {
                canvas.clearCommandInputBox();
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
