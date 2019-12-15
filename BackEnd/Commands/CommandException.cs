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

        //Extremely Primative Wrap Text
        private string WrapText(string text)
        {
            int i = 0;
            foreach (var letter in text)
            {
                if (i % 73 == 0&&i!=0)
                    text = text.Insert(i, "\n");
                i += 1;
            }
            return text;
        }

        public override void Resolve(string parameter = "")
        {
            CommandOutputEvent.Call(Command, WrapText(ErrorMessage));
        }
    }
}