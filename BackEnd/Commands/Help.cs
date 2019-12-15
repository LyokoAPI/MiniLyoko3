using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Commands
{
    public class Help : Command
    {
        public override string Name { get; set; } = "help";
        public override string Usage { get; } = "help.[command]";
        public override int MaxArgs { get; set; } = 1;
        private List<Command> _commands;

        public Help(ref List<Command> commands)
        {
            _commands = commands;
        }

        protected override void DoCommand(string[] args)
        {
            //CheckLength(0, 1);
            if (args.Length == 0)
            {
                Output(CommandList());
            }
            else
            {
                Command command = _commands.SingleOrDefault(command1 =>
                    command1.Name.Equals(args[0], StringComparison.CurrentCultureIgnoreCase));
                if (command == null)
                {
                    throw new CommandException(this,"Command not found!");
                }
                else
                {
                    Output(GetUsage(command));
                }
            }
        }


        private string CommandList()
        {
            string list = "[help";
            foreach (var command in _commands.GetRange(0,_commands.Count-1))
            {
                list += $", {command.Name}";
            }

            list += ("]");

            return list;
        }

        private string GetUsage(Command command)
        {
            return $"usage: " + command.Usage;
        }

        
        
        
    }
}