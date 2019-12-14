using LyokoAPI.Events.LWEvents;
using LyokoAPI.RealWorld.Location;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Translate : Command
    {
        public override string Name { get; set; } = "translate";
        protected override void DoCommand(string[] args)
        {
            LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!");
                return;
            } 
            if (warrior.Status != Status.VIRTUALIZED)
            {
                throw new CommandException(this,"Can't devirt warrior!");
                return;
            }
            LW_TranslationEvent.Call(warrior,new APILocation("Brazil"));
            Output(warrior.WarriorName + " devirtualized.");
        }
    }
}