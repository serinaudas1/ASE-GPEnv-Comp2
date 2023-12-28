using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.Exceptions
{
    public class ParsingException : Exception
    {
   
        public ParsingException(string exceptionMessage) : base(exceptionMessage)
        {
            Console.WriteLine("Initializing Parsing Exception with message : "+ exceptionMessage);
        }
    }
}
