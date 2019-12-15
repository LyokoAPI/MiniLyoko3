using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Hurt : Command
    {
        public override string Name { get; set; } = "hurt";
        public override string Usage { get; } = "lw.hurt.[warrior].[amount]";
        public override int MinArgs { get; set; } = 2;

        protected override void DoCommand(string[] args)
        {
            LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!");
            } 
            if (warrior.Status != Status.VIRTUALIZED)
            {
                throw new CommandException(this,"Can't hurt warrior!");
            }
            LW_HurtEvent.Call(warrior,int.Parse(args[1]));
            Output(warrior.WarriorName + " hurt by "+args[1]);
        }
    }
}