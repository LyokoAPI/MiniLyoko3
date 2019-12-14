using Domain;
using LyokoAPI.Events;

namespace Backend.Commands
{
    public class CommandException : MiniLyokoException
    {
        public string ErrorMessage { get; }
        public string Command { get; }
        public CommandException(Command command,string messagge)
        {
            ErrorMessage = messagge;
            Command = command.DisplayName;
        }

        public override void Resolve(string parameter = "")
        {
            CommandOutputEvent.Call(Command, ErrorMessage);
        }
    }
}