using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.LyokoWarrior
{
    public class PermXanafy : Command
    {
        public override string Name => "permxanafy";
        public override string Usage => "lw.permxanafy.<warrior>";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "Invalid Warrior!");
            }

            if (!(warrior.Statuses.Contains(LW_Status.VIRTUALIZED) && !warrior.Statuses.Contains(LW_Status.PERMXANAFIED)))
            {
                throw new CommandException(this, "Can't PermXanafy Warrior!");
            }
            LW_PermXanafyEvent.Call(warrior);
            Output($"{warrior.WarriorName} PermXanafied.");
        }
    }
}
