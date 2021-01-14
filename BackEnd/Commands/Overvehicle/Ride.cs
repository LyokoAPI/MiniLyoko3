using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Events.OVEvents;
using Backend.extensions;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.Overvehicle
{
    public class Ride : Command
    {
        public override string Name => "ride";
        public override string Usage => "ov.ride.[overvechicle].[warrior]";
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
            if (overvehicle.IsFull()) throw new CommandException(this, $"{overvehicle.OvervehicleName} is full!");
            if (overvehicle.IsRiding(warrior)) throw new CommandException(this, $"{warrior.WarriorName} is riding overvehicle!");
            OV_RideEvent.Call(overvehicle, warrior);
            Output($"{warrior.WarriorName} rides {overvehicle.OvervehicleName}");
        }
    }
}
