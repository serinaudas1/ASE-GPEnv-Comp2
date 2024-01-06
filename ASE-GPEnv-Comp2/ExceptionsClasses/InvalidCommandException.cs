using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp2.Exceptions
{
    public class InvalidCommandException : ParsingException
    {
        public string invalidCommandMessage { get; }
        public InvalidCommandException(string message, string invalidCommandMessage) : base(message)
        {
            this.invalidCommandMessage = invalidCommandMessage;
        }
        public override string getParsingExceptionMessage()
        {
            return invalidCommandMessage;
        }
    }
}
