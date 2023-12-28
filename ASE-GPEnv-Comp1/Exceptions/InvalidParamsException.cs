﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_GPEnv_Comp1.Exceptions
{
    

    public class InvalidParamsException : ParsingException
    {
        public string invalidParamsMessage { get; }
        public InvalidParamsException(string message, string invalidParamsMessage) : base(message)
        {
            invalidParamsMessage = invalidParamsMessage;
        }
    }
}
