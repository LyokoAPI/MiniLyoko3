using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Heal : Command
    {
        public override string Name { get; set; } = "heal";
        public override string Usage { get; } = "heal.[warrior].[amount]";

        protected override void DoCommand(string[] args)
        {
            LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!");
            } 
            if (warrior.Status != Status.VIRTUALIZED)
            {
                throw new CommandException(this,"Can't heal warrior!");
            }
            LW_HealEvent.Call(warrior,int.Parse(args[1]));
            Output(warrior.WarriorName + " healed.");
        }
    }
}