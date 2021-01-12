using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Events.OVEvents;
using Backend.extensions;

namespace Backend.Commands.Overvehicle
{
    public class GetOff : Command
    {
        public override string Name => "getoff";
        public override string Usage => "ov.getoff.[overvehicle].[warrior]";
        public override int MinArgs => 2;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.Overvehicle.Overvehicle overvehicle = Overvehicles.GetByName(args[0].ToLower());
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[1].ToLower());
            if (overvehicle == null)
            {
                throw new CommandException(this, "Invalid overvehicle!");
            }
            if (warrior == null)
            {
                throw new CommandException(this, "Invalid warrior!");
            }
            if (overvehicle.Status != OV_Status.VIRTUALIZED)
            {
                throw new CommandException(this, $"Can't ride {overvehicle.OvervehicleName}!");
            }
            if (!warrior.Statuses.Contains(LW_Status.VIRTUALIZED))
            {
                throw new CommandException(this, $"Can't ride {warrior.WarriorName}!");
            }
            if (overvehicle.IsEmpty()) throw new CommandException(this, $"{overvehicle.OvervehicleName} is empty!");
            if (!overvehicle.IsRiding(warrior)) throw new CommandException(this, $"{warrior.WarriorName} not riding overvehicle!");
            OV_GetOffEvent.Call(overvehicle, warrior);
            Output($"{warrior.WarriorName} gets off {overvehicle.OvervehicleName}");
        }
    }
}
