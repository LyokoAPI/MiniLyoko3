using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Frontier : Command
    {
        public override string Name { get; set; } = "frontier";
        public override string Usage { get; } = "lw.frontier.[warrior]";
        public override int MinArgs { get; set; } = 1;

        protected override void DoCommand(string[] args)
        {
            LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!");
            } 
            if (warrior.Status != Status.VIRTUALIZED)
            {
                throw new CommandException(this,"Can't frontier warrior!");
            }
            LW_FrontierEvent.Call(warrior);
            Output(warrior.WarriorName + " frontiered.");
        }
    }
}