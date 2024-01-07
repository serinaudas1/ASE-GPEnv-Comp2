using ASE_GPEnv_Comp2.Exceptions;
using ASE_GPEnv_Comp2.ShapesClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = ASE_GPEnv_Comp2.ShapesClasses.Rectangle;

namespace ASE_GPEnv_Comp2
{



    /// <summary>
    /// Struct to save following:
    /// 1) valid command
    /// 2) number of valid params [for quick checking]
    /// 3) all vallid params for that command
    /// 4) valid format to show as a hint
    /// </summary>
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


    public struct IfBlock {
        public bool parsedComparisonResult;
        public List<string> ifBlockStatements;
        public bool isMultilineBlock;
        public int atLineNumber;
        public void initializeIfBlock()
        {
            this.parsedComparisonResult = false;
            this.ifBlockStatements = new List<string>();
            this.isMultilineBlock = false;
        }


    }

    /// <summary>
    /// Command Parser class which parses one command or multiple line program.
    /// </summary>
   public class CommandParser
    {
    


        public GPLCommand [] allValidGPLCommands;
        Canvas canvas;
        CheckBox shouldClearCommandCheckBox;
        ShapesFactory shapesFactory;

        public List<string> allDeclaredVariables = new List<string>();
        public List<int> allDeclaredVariableValues = new List<int>();
        public List<IfBlock> allIfBlocks = new List<IfBlock>();
        public List<int> linesToIgnoreExecution = new List<int>();

        public List<ParsingException> innerExceptions = new List<ParsingException>();
        


        /// <summary>
        /// Consturctor Initializes the all valid commands
        /// </summary>
        /// <param name="canvas">Canvas class object to perform  all UI related operations.</param>
        /// <param name="shouldClearCommandCheckBox">Checkbox for clearing the command on successful execution</param>
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
                    new string []{"red", "green", "blue", "cyan", "magenta", "yellow", "black"},
                    1, 
                    "pen {color}"),

                new GPLCommand("fill",
                    new string []{"on", "off"},
                    1, 
                    "fill {on|off}"),

              

            };
        }
        /// <summary>
        /// Struct to hold parsing information of any given command
        /// </summary>
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

        /// <summary>
        /// Function extracts the parameters from input command
        /// </summary>
        /// <param name="command">Input command</param>
        /// <returns>Array of command input parameters.</returns>
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

            int paramIndex = 0;
            foreach (string param in paramsArray) {
                int matchingAtIndex = Array.IndexOf(this.allDeclaredVariables.ToArray(), param);
                if (matchingAtIndex != -1) {
                    paramsArray[paramIndex] = this.allDeclaredVariableValues[matchingAtIndex]+"";
                }
                paramIndex++;
            }
            

            return restString == ""? new string[] { }: paramsArray;

        }

        public int resolveVariableValue(string expression) {

            if (int.TryParse(expression, out int varValue))
            {
                return varValue;
            }


            if (expression.Contains("-"))
            {
                string[] splitByOperator = expression.Split('-');
                string rightOperand = string.Join("-", splitByOperator, 1, splitByOperator.Length - 1);
                return resolveVariableValue(splitByOperator[0]) - resolveVariableValue(rightOperand);
            }

            else if (expression.Contains("+"))
            {
                string[] splitByOperator = expression.Split('+');
                string rightOperand = string.Join("+", splitByOperator, 1, splitByOperator.Length - 1);
                return resolveVariableValue(splitByOperator[0]) + resolveVariableValue(rightOperand);
            }

            else if (expression.Contains("*"))
            {
                string[] splitByOperator = expression.Split('*');
                string rightOperand = string.Join("*", splitByOperator, 1, splitByOperator.Length - 1);
                return resolveVariableValue(splitByOperator[0]) * resolveVariableValue(rightOperand);
            }


            else if (expression.Contains("/"))
            {
                string[] splitByOperator = expression.Split('/');
                string rightOperand = string.Join("/", splitByOperator, 1, splitByOperator.Length - 1);
                return resolveVariableValue(splitByOperator[0]) / resolveVariableValue(rightOperand);
            }

            else {
                int index = 0;
                foreach (string varName in allDeclaredVariables)
                {
                    if (varName == expression.Trim()) {
                        return allDeclaredVariableValues[index];
                    }
                    index++;
            }
            }
            this.innerExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Unknown variable or expression'"+expression+"'"));
            return 0;


        }

        public int getOperandValue(string operand)
        {
            if (int.TryParse(operand, out int operandValue))
            {
                return operandValue;
            }
            else {
                int valueIdx = this.getStringIndexFromArray(operand, this.allDeclaredVariables.ToArray(), false);
                if (valueIdx != -1) {
                    return this.allDeclaredVariableValues[valueIdx];
                }
            }

            this.innerExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Unknown variable or expression'" + operand + "'"));
            return 0;


        }


        public bool getComparisonResult(string[] expressionSplit, string operator_) {
            if (expressionSplit.Length < 2) {
                this.innerExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Incomplete expression."));
                return false;
            }


            string leftOperand = expressionSplit[0].Trim();
            string rightOperand = expressionSplit[1].Trim();

            if (leftOperand.Equals(rightOperand) || operator_ == "=") {
                this.canvas.appendExecutionResultsToOutput("Warning!!!! Truth assertion for '"+leftOperand+operator_+rightOperand+"'. Always returns true");
                return true;
            }

            int leftOperandValue = getOperandValue(leftOperand);
            int rightOperandValue = getOperandValue(rightOperand);
            switch (operator_) {
                case "==":
                    return leftOperandValue == rightOperandValue;
                case "<":
                    return leftOperandValue < rightOperandValue;
                case ">":
                    return leftOperandValue > rightOperandValue;
                case ">=":
                    return leftOperandValue >= rightOperandValue;
                case "<=":
                    return leftOperandValue <= rightOperandValue;
            }
            return false;

        }
        public bool resolveComparisonExpression(string expression) {


            if (expression.Contains("==")) {
                string [] expressionSplit = expression.Split("==".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                return getComparisonResult(expressionSplit, "==");
            }
            else if (expression.Contains("<="))
            {
                string[] expressionSplit = expression.Split("<=".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                return getComparisonResult(expressionSplit, "<=");
            }
            else if (expression.Contains(">="))
            {
                string[] expressionSplit = expression.Split(">=".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                return getComparisonResult(expressionSplit, ">=");
            }
            else if (expression.Contains(">="))
            {
                string[] expressionSplit = expression.Split("<".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                return getComparisonResult(expressionSplit, "<");
            }
            if (expression.Contains(">"))
            {
                string[] expressionSplit = expression.Split(">".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                return getComparisonResult(expressionSplit, ">");
            }
            if (expression.Contains("="))
            {
                // Truth assertion: Handled by one function above.
                string[] expressionSplit = expression.Split("=".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                return getComparisonResult(expressionSplit, "=");

            }
            else
            {
                this.innerExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Incomplete Expression for comparison."));
                return false;
            }
        }


        /// <summary>
        /// Function finds the string from an array
        /// </summary>
        /// <param name="str">string to find</param>
        /// <param name="array">Source array to find the string from</param>
        /// <param name="shouldTrim">Whether  to remove spaces in commands i.e 'endif '</param>
        /// <returns>Index of target string, -1 string not found</returns>
        int getStringIndexFromArray(string str, string[] array, bool shouldTrim) {
            
            if(shouldTrim)
                array = Array.ConvertAll(array, s => s.Replace(" ", ""));

            return Array.IndexOf(array, str);



        }


        /// <summary>
        /// Function checks following things:
        /// 1) Empty command
        /// 2) Only allowed commands- [Case Insensitive]
        /// 3) Valid parameter names
        /// 4) Valid parameter count
        /// 5) Valid parameter types
        /// 6) IMPORTANT: Also checks the if run command is typed inside program editor
        /// , which can cause recursive calls. 
        /// </summary>
        /// <param name="command">Command needs to be checked</param>
        /// <param name="lineNumber">Lines number of the command. -1 in case of single command.</param>
        /// <returns>
        ///   /// Method returns the object of ParsingInfo struct which have:
        /// 1) Parsed Command 2) Parsed Params and 3) Successflag along with other info
        /// </returns>
        public ParsingInfo checkSyntax(String command, int lineNumber)
        {
            ParsingInfo parsingInfo = new ParsingInfo();
            parsingInfo.initializeParsingInfo();


    
            if (command.Length == 0) {

                parsingInfo.parsingExceptions.Add(new InvalidCommandException("Invalid Command:","Command cannot be an empty string"));
                parsingInfo.isSuccessful = false;
                return parsingInfo;

            }

         

            bool hasFoundCommand = false;
            string[] commandSplitBySpace = command.ToLower().Split(' ');
            string inputCommand = commandSplitBySpace[0];
            string[] paramsArray = extractParamsFromCommand(command);


            parsingInfo.parsedCommand = inputCommand;
            parsingInfo.parsedParameters = paramsArray;
            parsingInfo.lineNumber = lineNumber;




            ///<summary>
            /// [Variable Declaration Check]
            ///checking if input command is a variable declaration
            ///if command is starting with var, following things are checked
            ///1) number of params for insuffcient or too much 2) type of param 
            ///4) If a variable is already declared or not
            ///</summary>
            if (inputCommand == "var") {
                if (paramsArray.Length > 1) {

                    parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command Param:", "Too much parameters supplied. Please follow command format. \n\tHint! var {variableName}"));
                    parsingInfo.isSuccessful = false;
                    return parsingInfo;
                }
                else if (paramsArray.Length < 1)
                {
                    parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Command Param:", "Insufficient parameters supplied. Please enter complete command. \n\tHint! var {variableName} "));
                    parsingInfo.isSuccessful = false;
                    return parsingInfo;
                }

                else if (int.TryParse(paramsArray[0], out int varValue))
                {
                    parsingInfo.parsingExceptions.Add(new InvalidParamsException("Invalid Param Type", "Invalid paramter passed as variable name"));
                    parsingInfo.isSuccessful = false;
                    return parsingInfo;
                }
                else {
                    string newVariableName = paramsArray[0];
                    int searchIndex = Array.IndexOf(allDeclaredVariables.ToArray(), newVariableName);

                    if (searchIndex == -1)
                    {
                        this.allDeclaredVariables.Add(newVariableName);
                        this.allDeclaredVariableValues.Add(0);
                    }
                    else {
                        parsingInfo.parsingExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Variable '"+newVariableName+"' Already declared."));
                        parsingInfo.isSuccessful = false;
                        return parsingInfo;
                    }
                }

                return parsingInfo;
            }

            ///<summary>
            /// [Variable Assignment Check]
            ///checking if command is to assing a created variable 
            ///if command is starting with var, following things are checked
            ///1) number of params for insuffcient or too much 2) type of param 
            ///</summary>

            int variableIndex = 0;
            foreach (string variableName in allDeclaredVariables) {
                if (inputCommand == variableName)
                {
                    string[] expressionSplit = command.Trim().Split('=');
                    
                    if (expressionSplit.Length <=1) {
                        parsingInfo.parsingExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Incorrect manipulation of variable '" + inputCommand + "'"));
                        parsingInfo.isSuccessful = false;
                        return parsingInfo;
                    }
                    string expression = expressionSplit[1];
                    if (expression.Length == 0) {
                        parsingInfo.parsingExceptions.Add(new InvalidSyntaxException("Invalid Syntax","Incorrect manipulation of variable '"+inputCommand+"'"));
                        parsingInfo.isSuccessful = false;
                        return parsingInfo;
                    }
                
                        //MessageBox.Show("Correct Assignment");
                        allDeclaredVariableValues[variableIndex] = resolveVariableValue(expression.Trim());

                    int calculatedValue = allDeclaredVariableValues[variableIndex];
                    this.canvas.appendExecutionResultsToOutput("***** Variable: '"+ inputCommand + "="+ calculatedValue + "' declared. ****");

                    return parsingInfo;
                   
                    //variableValues[variableIndex++] = resolveVariableValue(expression);
                   
                }
                variableIndex++;

            }


            ///<summary>
            ///[if block parsing and checking- both one line and multiline]
            ///</summary>

            if (inputCommand == "if") {
                IfBlock ifBlock = new IfBlock();
                ifBlock.initializeIfBlock();
                ifBlock.atLineNumber = lineNumber;
                string [] cleanedStatments = this.cleanAndConvertProgramToStatements(canvas.getProgramFromEditor());

                string[] ifCompExpression = command.Trim().Split("if".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (ifCompExpression.Length == 0)
                {
                    parsingInfo.parsingExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Empty expression for if statement"));
                    parsingInfo.isSuccessful = false;
                    return parsingInfo;
                }
                ifBlock.parsedComparisonResult = this.resolveComparisonExpression(ifCompExpression[0]);
              
        

                if (lineNumber == cleanedStatments.Length)
                {
                    parsingInfo.parsingExceptions.Add(new InvalidSyntaxException("Invalid Syntax", "Incomplete program. Nothing found after if statement"));
                    parsingInfo.isSuccessful = false;
                    return parsingInfo;
                }

                int startingLineFor_If = lineNumber;
                int lineFor_EndIf = getStringIndexFromArray("endif", cleanedStatments, true);
                if (lineFor_EndIf == -1)
                {
                    //one line if
                    ifBlock.ifBlockStatements.Add(cleanedStatments[startingLineFor_If]);
                    ifBlock.isMultilineBlock = false;
                    linesToIgnoreExecution.Add(startingLineFor_If);
                }
                else {
                    // multiline if block block with end if
                    for (int ifBlockLineIdx = startingLineFor_If; ifBlockLineIdx <= lineFor_EndIf-1; ifBlockLineIdx++)
                    {
                        ifBlock.ifBlockStatements.Add(cleanedStatments[ifBlockLineIdx]);
                        ifBlock.isMultilineBlock = true;
                        linesToIgnoreExecution.Add(ifBlockLineIdx);


                    }
                }

                foreach (int line in linesToIgnoreExecution) {
                    Debug.WriteLine(line+ "+" +cleanedStatments[line]);
                }
                this.allIfBlocks.Add(ifBlock);
                return parsingInfo;

    
                
            }








            //checking command validity here
            foreach (GPLCommand cmd_i in allValidGPLCommands) {

                if (cmd_i.command == inputCommand) {
                    hasFoundCommand = true;
                    break;
                }
            }
            if (!hasFoundCommand) {

                if(command.Contains("="))
                    parsingInfo.parsingExceptions.Add(new InvalidCommandException("Invalid Command or Variable name:", "'" + inputCommand + "' is accessed before declaration."));
   
                else
                    parsingInfo.parsingExceptions.Add(new InvalidCommandException("Invalid Command:", "'" + command + "' not a valid command."));
            }
            // end of command validity check







            /*
             * here I am checking three things:
             * 1) Valid count of params
             * 2) Valid name of params
             * 3) Valid type of params
             */
            
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
                    if (cmd_i.hasStringParam && inputCommand !="var")
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

            if(parsingInfo.parsedCommand == "run" && parsingInfo.lineNumber!=-1)
            {
                parsingInfo.parsingExceptions.Add(new InvalidCommandException("Recursive Run Found", "The program box cannot have a 'run' command."));
                parsingInfo.isSuccessful = false;

            }

            return parsingInfo;
        }


        /// <summary>
        /// On Succesful parsing of command, this method identifies the command and
        /// triggers the right handler for that command
        /// </summary>
        /// <param name="parsingResult"></param>
        public void runValidGPLCommand(ParsingInfo parsingResult) {


            if (parsingResult.parsedCommand == "if")
            {

                int ifIndex = Array.FindIndex(this.allIfBlocks.ToArray(), element => element.atLineNumber == parsingResult.lineNumber);

                IfBlock ifBlock = this.allIfBlocks[ifIndex];

                //MessageBox.Show("Execute If Block")
                if (ifBlock.parsedComparisonResult)
                {

                    foreach (string statement in ifBlock.ifBlockStatements)
                    {
                        this.executeOneCommand(statement, -1);
                    }
                }
            }


            ///<summary>
            ///After successful parsing checks, moveto command is executed here.
            ///x and y are initialized from the parsed input params.
            ///PenPosition struct is used to store the position of cursor.
            ///call is made to moveTo handler from canvas class.
            ///</summary>
            if (parsingResult.parsedCommand == "moveto")
            {
                int x = int.Parse(parsingResult.parsedParameters[0]);
                int y = int.Parse(parsingResult.parsedParameters[1]);
                PenPosition drawing = new PenPosition(x, y);
                canvas.moveTo(drawing);
            }

            ///<summary>
            ///After successful parsing checks, drawto command is executed here.
            ///PenPosition struct is used to store the position of cursor.
            ///call is made to drawTo handler from canvas class to draw a small cursor on canvas.
            ///</summary>
            else if (parsingResult.parsedCommand == "drawto")
            {
                int x = int.Parse(parsingResult.parsedParameters[0]);
                int y = int.Parse(parsingResult.parsedParameters[1]);
                PenPosition drawing = new PenPosition(x, y);
                canvas.drawTo(drawing);
            }

            ///<summary>
            ///Command to clear the canvas. It makes calls to the clearCanvas method of Canvas class.
            ///</summary>
            else if (parsingResult.parsedCommand == "clear")
            {

                canvas.clearCanvas();
            }

            ///<summary>
            ///Command to reset the position of pen cursor. It makes calls to the resetPen method of Canvas class.
            ///</summary>
            else if (parsingResult.parsedCommand == "reset")
            {

                canvas.resetPen();
            }

           ///<summary>
           ///rectangle command execution based on the parameters width and heigh received by user
           ///Rectangle object is prepared from Factory Class
           ///Rectangle is drawn on the canvas using drawRectangle method of Canvas class
           ///</summary>
            else if (parsingResult.parsedCommand == "rectangle")
            {
                int width = int.Parse(parsingResult.parsedParameters[0]);
                int height = int.Parse(parsingResult.parsedParameters[1]);

                Rectangle rectangle = (Rectangle)shapesFactory.getShape("rectangle");
                rectangle.initializeShape(canvas.getPen().Color, canvas.getPenPosition(), width, height);

                canvas.drawRectangle(rectangle);
            }

            ///<summary>
            ///circle command execution based on the parameters radius received by user
            ///Circle object is prepared from Factory Class
            ///Circle is drawn on the canvas using drawCircle method of Canvas class
            ///</summary>
            else if (parsingResult.parsedCommand == "circle")
            {
                int radius = int.Parse(parsingResult.parsedParameters[0]);


                Circle circle = (Circle)shapesFactory.getShape("circle");
                circle.initializeShape(canvas.getPen().Color, canvas.getPenPosition(), radius);

                canvas.drawCircle(circle);
            }

            ///<summary>
            ///triangle command execution based on the parameters side length received by user
            // I am drawing equi-lateral triangle based on side length
            ///Triangle object is prepared from Factory Class
            ///Triangle is drawn on the canvas using drawTriangle method of Canvas class
            ///</summary>
            else if (parsingResult.parsedCommand == "triangle")
            {
                int sideLength = int.Parse(parsingResult.parsedParameters[0]);


                Triangle triangle = (Triangle)shapesFactory.getShape("triangle");
                triangle.initializeShape(canvas.getPen().Color, canvas.getPenPosition(), sideLength);

                canvas.drawTriangle(triangle);
            }

            ///<summary>
            /// Command to change the color of drawing pen/brush.
            /// Parsed input color is in String type, it's converted to right Color class object
            /// Pen color is changed using the setPenColor method of canvas class.
            ///</summary>
            else if (parsingResult.parsedCommand == "pen")
            {
                Color color;
                string inputColor = parsingResult.parsedParameters[0].ToUpper();
                switch (inputColor)
                {
                    case "RED":
                        color = Color.Red;
                        break;

                    case "GREEN":
                        color = Color.Green;
                        break;
                    case "BLUE":
                        color = Color.Blue;
                        break;
                    case "CYAN":
                        color = Color.Cyan;
                        break;
                    case "MAGENTA":
                        color = Color.Magenta;
                        break;
                    case "YELLOW":
                        color = Color.Yellow;
                        break;
                    case "BLACK":
                        color = Color.Black;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }



                canvas.setPenColor(color);
            }

            ///<summary>
            ///Command to change the fill move of pen/brush.
            ///Fill mode is changed using setPenFill function of Canvas class.
            ///</summary>
            else if (parsingResult.parsedCommand == "fill")
            {
                string fillParam = parsingResult.parsedParameters[0].ToUpper();
                if (fillParam == "ON")
                    canvas.setPenFill(true);
                else if (fillParam == "OFF")
                    canvas.setPenFill(false);
                //else case will never reach. I am sure

            }
            ///<summary>
            ///this is to avoid run command being called from code editor. (To avoid recursion)
            ///</summary>
            else if (parsingResult.parsedCommand == "run") {

                executeWholePrograme(canvas.getProgramFromEditor());
            }
        }

        public void throwAndLogExceptions(ParsingInfo parsingResult) {
            foreach (ParsingException parsingException in parsingResult.parsingExceptions)
            {
                try
                {
                    throw parsingException;
                }
                catch (ParsingException pEx)
                {

                    string outputText = (parsingResult.lineNumber == -1 ? "" : "[Line No."+parsingResult.lineNumber+"]-")+ pEx.Message + "\n\t" + pEx.getParsingExceptionMessage() + "\n_____________________________________________";
                    canvas.appendExecutionResultsToOutput(outputText);
                    
                }
            }
        }

        /// <summary>
        /// Receives one line command either coming from
        /// command input box or multiple program statement splits.
        /// It has three methods. 
        /// 1) To check the validity of command
        /// 2) To execute the command only If command is successfully parsed
        /// 3) Logging of exceptions if command parsing was unsuccessful.
        /// </summary>
        /// <param name="commandTxt">
        /// Command text which needs to be parsed followed by execution of the command
        /// </param>
        /// <param name="lineNumber">
        /// It's -1 in case of one line command and have a proper line number if
        /// method is called from statement splits of program execution
        /// </param>
        /// <returns>
        /// Method returns the object of ParsingInfo struct which have:
        /// 1) Parsed Command 2) Parsed Params and 3) Successflag along with other info
        /// </returns>
        public ParsingInfo executeOneCommand(String commandTxt, int lineNumber) {
            commandTxt = commandTxt.ToLower();
            ParsingInfo parsingResult = checkSyntax(commandTxt, lineNumber);

            //appending inner exceptions
            parsingResult.parsingExceptions.AddRange(this.innerExceptions);
            this.innerExceptions.Clear();

            bool exists = Array.Exists(this.linesToIgnoreExecution.ToArray(), element => element == parsingResult.lineNumber -1);

            if (parsingResult.isSuccessful && !exists) {
                
                // identify the command and excecute it
                runValidGPLCommand(parsingResult);
            }
            else
            {
                throwAndLogExceptions(parsingResult);
            }

            if(lineNumber==-1)
            canvas.appendCommandToHistory(commandTxt, parsingResult.isSuccessful);

            if (parsingResult.isSuccessful && shouldClearCommandCheckBox.Checked)
            {
                canvas.clearCommandInputBox();
            }

            Debug.Write(parsingResult.parsedCommand+ "-" +parsingResult.isSuccessful);
            return parsingResult;

        }

        public void resetUI()
        {
            this.allDeclaredVariables.Clear();
            this.allDeclaredVariableValues.Clear();
            this.linesToIgnoreExecution.Clear();
            this.allIfBlocks.Clear();

            this.canvas.resetPen();
            this.canvas.clearCanvas();
            this.canvas.clearOutputBox();
        }

        public string[] cleanAndConvertProgramToStatements(string programText) {
            Regex regex = new Regex("\\s{2,}");
            string[] statements = programText.Split('\n');
            List<string> cleanedStatements = new List<string>();
            foreach (string statement in statements)
            {
                string cleanedStatement = statement.Replace('\r'.ToString(), "");

                cleanedStatement = regex.Replace(cleanedStatement, "");

                if (cleanedStatement == "")
                    continue;

                cleanedStatements.Add(cleanedStatement.ToLower());
            }

            return cleanedStatements.ToArray();
        }

        public string[] statementsToIgnore = new string[] { "endif"};

        /// <summary>
        /// Function to read all statements in the program editor and execute one by one
        /// </summary>
        /// <param name="programTxt">Whole program typed/loaded in program box.</param>
        /// <returns>
        /// Method returns the list of objects of ParsingInfo struct, where each object have:
        /// 1) Parsed Command 2) Parsed Params and 3) Successflag along with other info
        /// </returns>
        public List<ParsingInfo> executeWholePrograme(String programTxt)
        {
            this.resetUI();

            List<ParsingInfo> parsingInfos = new List<ParsingInfo>();
            int lineNumber = 1;
            string[] cleanedStatements = this.cleanAndConvertProgramToStatements(programTxt);
            foreach (string cleanedStatement in cleanedStatements) {

                bool foundInArray = Array.Exists(this.statementsToIgnore, element => element.Contains(cleanedStatement.Trim()));

                if (foundInArray) {
                    continue;
                }

                ParsingInfo parsingInfo = executeOneCommand(cleanedStatement, lineNumber++);
                parsingInfos.Add(parsingInfo);
            }
            return parsingInfos;
        }

        
    }
}
