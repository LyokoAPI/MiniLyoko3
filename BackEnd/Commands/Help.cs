using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Commands
{
    public class Help : Command
    {
        public override string Name { get; set; } = "help";
        public override string Usage { get; } = "help.[command]";
        //public override int MaxArgs { get; set; } = 1;
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
                if (args.Length > 1)
                {
                    if (command.subCommands.Count > 0)
                    {
                        string cmd = string.Join(".", args);
                        List<string> tmp = cmd.Split('.').ToList();
                        tmp.RemoveAt(0);
                        cmd = string.Join(".", tmp);
                        command = command.subCommands.SingleOrDefault(command1 =>
                            command1.Name.Equals(cmd, StringComparison.CurrentCultureIgnoreCase));
                    }
                }

                if (command == null)
                {
                    throw new CommandException(this,$"Command: {args[0]} not found!");
                }
                else
                {
                    Output(GetUsage(command));
                }
            }
        }


        private string CommandList()
        {
            string list = $"help: {Usage}";
            foreach (var command in _commands.GetRange(0,_commands.Count-1))
            {
                list += $"\n{command.Name}: {GetReadableUsage(command)}";
            }

            return list;
        }

        private string GetUsage(Command command)
        {
            return $"Usage: " + GetReadableUsage(command);
        }

        private string GetReadableUsage(Command command)
        {
            string list = command.Usage;
            list = list.Replace(", ", ",\n");
            return list;
        }




    }
}