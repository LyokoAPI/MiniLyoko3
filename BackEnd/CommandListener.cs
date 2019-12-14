using System.Collections.Generic;
using System.Linq;
using Backend.Commands;
using Backend.Commands.aelita;
using Backend.Commands.lyokowarrior;
using Backend.Commands.xana;

namespace BackEnd
{
    public class CommandListener
    {
        private List<Command> Commands;

        public CommandListener()
        {
            Commands = new List<Command>(){new Xana(), new Aelita(), new Devirtualize(), new Hurt(), new Kill(), new Virtualize(), new Heal(), new Frontier(),new Xanafy(), new Translate()};

        }
        
        
        public void OnCommand(string arg)
        {
            string[] commandargs = arg.Split('.');
            var commandname = commandargs[0];
            if (commandargs.Length > 1)
            {
                commandargs = commandargs.ToList().GetRange(1, commandargs.Length - 1).ToArray();
            }
            else
            {
                commandargs = new string[] { };
            }
            var command = Commands.Find(commandd => commandd.Name.Equals(commandname));
            command?.Run(commandargs);
        }
    }
}