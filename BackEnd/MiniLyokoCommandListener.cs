using System.Collections.Generic;
using System.Linq;
using BackEnd.Commands;
using LyokoAPI.Events;
using BackEnd.Commands.Aelita;
using BackEnd.Commands.LyokoWarrior;
using BackEnd.Commands.Xana;
using LyokoAPI.Commands;

namespace BackEnd
{
    public class MiniLyokoCommandListener : CommandListener
    {
        protected override string Prefix => "";

        public override void onCommandInput(string arg)
        {
            List<ICommand> Commands = GetCommands();
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
            if (command != null)
            {
                command?.Run(commandargs);
            }
            else
            {
                //CommandOutputEvent.Call("Error",$"The command \"{commandname}\" does not exist."); remember: this will be called for commands that aren't part of minilyoko as well
            }
        }
    }
}