using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Devirtualize : Command
    {
        public override string Name { get; set; } = "devirt";
        public override string Usage { get; } = "devirt.[warrior]";

        protected override void DoCommand(string[] args)
        {
            LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!");
            } 
            if (warrior.Status != Status.VIRTUALIZED)
            {
                throw new CommandException(this,"Can't devirt warrior!");
            }
            LW_DevirtEvent.Call(warrior);
            Output(warrior.WarriorName + " devirtualized.");
            
        }
    }
}