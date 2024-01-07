using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp2.Exceptions
{

    public class InvalidSyntaxException : ParsingException
    {
        public string invalidSyntaxMessage { get; }
        public InvalidSyntaxException(string message, string invalidSyntaxMessage) : base(message)
        {
            this.invalidSyntaxMessage = invalidSyntaxMessage;
        }

        public override string getParsingExceptionMessage()
        {
            return invalidSyntaxMessage;
        }




    }

}
