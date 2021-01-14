using LyokoAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Events.OVEvents;
using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;
using LyokoAPI.Exceptions;

namespace Backend.Commands.Overvehicle
{
    public class Virtualize : Command
    {
        public override string Name => "virt";

        public override string Usage => "ov.virt.[overvehicle]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.Overvehicle.Overvehicle overvehicle = null;
            try
            {
                overvehicle = Overvehicles.GetByName(args[0].ToLower());
            }
            catch (Exception e)
            {
                LyokoLogger.Log(Name, e.ToString());
            }
            if (overvehicle == null)
            {
                Output("No Overvehicle");
                throw new CommandException(this, "Invalid Overvehicle!");
            }
            Output("Overvehicle: " + overvehicle.OvervehicleName);
            OV_VirtEvent.Call(overvehicle, "forest");
            Output(overvehicle.OvervehicleName + " Virtualized.");
        }
    }
}
