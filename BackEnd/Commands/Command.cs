using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using LyokoAPI.Events;

namespace Backend.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; set; }
        public virtual int MinArgs { get; set; } = 0;
        public virtual int MaxArgs { get; set; } = Int32.MaxValue;
        public virtual string DisplayName => Name;
        public virtual string Usage => GetSubCommandsAsString();
        private string[] _args;
        public virtual List<Command> subCommands { get; protected set; } = new List<Command>();
        public void Run(string[] args = null)
        {
            _args = args ?? new string[]{};
            try
            {
                CheckLength(MinArgs, MaxArgs);
                DoCommand(_args);
            }
            catch (MiniLyokoException e)
            {
                e.Resolve();
            }
        }

        protected abstract void DoCommand(string[] args);

  

        protected bool DoSubCommand(string[] args)
        {
            if (args.Length < 1)
            {
                return false;
            }
            var subcommand = args[0];
            if (args.Length > 1)
            {
                args = args.ToList().GetRange(1, args.Length - 1).ToArray();
            }
            else
            {
                args = new string[]{};
            }

            foreach (var command in subCommands)
            {
                if (command.Name.Equals(subcommand))
                {
                    command.Run(args);
                    return true;
                }
            }

            return false;

        }
        protected bool CheckLength(int min, int max = Int32.MaxValue)
        {
            if (_args.Length < min)
            {
                throw new CommandException(this,$"not enough arguments! minimum {min}");
            }

            if (_args.Length > max)
            {
                throw new CommandException(this, $"too much arguments! maximum {max}");
            }

            return true;
        }

        //Extremely Primative Wrap Text
        private string WrapText(string text)
        {
            int i = 0;
            foreach (var letter in text)
            {
                if (i % 73 == 0)
                    text = text.Insert(i, "\n");
                i += 1;
            }
            return text;
        }

        protected void Output(string message)
        {
            CommandOutputEvent.Call(this.DisplayName,WrapText(message));
        }

        protected int CheckNumber(int index)
        {
            int result;
            bool valid = Int32.TryParse(_args[index], out result);
            if (! valid)
            {
                throw new CommandException(this, $"Invalid argument type: number on argument {index}");
            }

            return result;
        }

        private string GetSubCommandsAsString()
        {
            string sub = "[";
            foreach (var command in subCommands)
            {
                sub += $"{this.Name}.{command.Name},";
            }

            sub = sub.TrimEnd(',');
            sub+=(']');
            return sub;
        }

        private string GetUsage()
        {
            if (subCommands.Any())
            {
                return GetSubCommandsAsString();
            }
            else
            {
                return "N/A";
            }
        }
    }
}