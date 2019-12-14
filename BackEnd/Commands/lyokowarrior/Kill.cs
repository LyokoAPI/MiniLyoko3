using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Kill : Command
    {
        public override string Name { get; set; } = "kill";
        public override string Usage { get; } = "kill.[warrior]";
        protected override void DoCommand(string[] args)
        {
            LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!"); 
            }
            LW_DeathEvent.Call(warrior);
            Output(warrior.WarriorName + " has been lost.");
        }
    }
}