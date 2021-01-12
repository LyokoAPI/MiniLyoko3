using System.Linq;
using LyokoAPI.Events.OVEvents;
using LyokoAPI.VirtualEntities.Overvehicle;

namespace Backend.Commands.Overvehicle
{
    public class Hurt : Command
    {
        public override string Name => "hurt";
        public override string Usage => "ov.hurt.[overvehicle].[amount]";
        public override int MinArgs => 2;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.Overvehicle.Overvehicle overvehicle = Overvehicles.GetByName(args[0].ToLower());
            if (overvehicle == null)
            {
                throw new CommandException(this, "Invalid overvehicle!");
            }
            if (overvehicle.Status!=OV_Status.VIRTUALIZED)
            {
                throw new CommandException(this, "Can't hurt overvehicle!");
            }
            OV_HurtEvent.Call(overvehicle, int.Parse(args[1]));
            Output(overvehicle.OvervehicleName + " hurt by " + args[1]);
            if (overvehicle.HP < 0) OV_DevirtEvent.Call(overvehicle);
        }
    }
}
