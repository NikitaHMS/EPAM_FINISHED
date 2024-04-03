using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Design_Principles
{
    internal class CommandInvoker
    {
        Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void Invoke()
        {
            command.Execute();
        }
    }
}
