using System;
using System.Collections.Generic;
using System.Linq;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands
{
    public class Help : Command
    {
        public override string Name => "help";
        public override string Usage => "help.[command]";
        //public override int MaxArgs { get; set; } = 1;
        private List<ICommand> _commands;

        public Help(ref List<ICommand> commands)
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
                ICommand Icommand = _commands.SingleOrDefault(command1 =>
                    command1.Name.Equals(args[0], StringComparison.CurrentCultureIgnoreCase));
                if (Icommand is Command)
                {
                    Command command = (Command)Icommand;
                    if (args.Length > 1)
                    {
                        if (command.SubCommands.Count > 0)
                        {
                            string cmd = string.Join(".", args);
                            List<string> tmp = cmd.Split('.').ToList();
                            tmp.RemoveAt(0);
                            cmd = string.Join(".", tmp);
                            Icommand = command.SubCommands.SingleOrDefault(command1 =>
                                command1.Name.Equals(cmd, StringComparison.CurrentCultureIgnoreCase));
                        }
                    }
                }

                if (Icommand == null)
                {
                    throw new CommandException(this,$"Command: {args[0]} not found!");
                }
                else
                {
                    if (Icommand is Command)
                        Output(GetUsage((Command)Icommand));
                }
            }
        }


        private string CommandList()
        {
            string list = $"help: {Usage}";
            foreach (var command in _commands.GetRange(0,_commands.Count-1))
            {
                if(command is Command)
                list += $"\n{command.Name}: {((Command)command).Usage}";
            }

            return list;
        }

        private string GetUsage(Command command)
        {
            return $"Usage: " + command.Usage;
        }
    }
}