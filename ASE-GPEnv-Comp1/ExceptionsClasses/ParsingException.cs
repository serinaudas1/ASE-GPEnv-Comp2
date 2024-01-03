using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.Exceptions
{
    public abstract class ParsingException : Exception
    {

        public abstract string getParsingExceptionMessage();
        public ParsingException(string exceptionMessage) : base(exceptionMessage)
        {

        }

        
    }
}
