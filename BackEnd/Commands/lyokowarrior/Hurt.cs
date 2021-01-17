using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.LyokoWarrior
{
    public class Hurt : Command
    {
        public override string Name => "hurt";
        public override string Usage => "lw.hurt.<warrior>.<amount>";
        public override int MinArgs => 2;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid Warrior!");
            } 
            if (!warrior.Statuses.Contains( LW_Status.VIRTUALIZED))
            {
                throw new CommandException(this,"Can't Hurt Warrior!");
            }
            int damage = CheckNumber(1);
            LW_HurtEvent.Call(warrior, damage);
            Output($"{warrior.WarriorName} hurt by {damage}");
            if (warrior.HP < 0) LW_DevirtEvent.Call(warrior);
        }
    }
}