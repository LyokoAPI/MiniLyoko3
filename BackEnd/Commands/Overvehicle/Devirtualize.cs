using LyokoAPI.Events.OVEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.Overvehicle
{
    public class Devirtualize : Command
    {
        public override string Name => "devirt";

        public override string Usage => "ov.devirt.[overvehicle]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.Overvehicle.Overvehicle warrior = LyokoAPI.VirtualEntities.Overvehicle.Overvehicles.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "Invalid Overvehicle!");
            }
            OV_DevirtEvent.Call(warrior);
            Output(warrior.OvervehicleName + " devirtualized.");
        }
    }
}
