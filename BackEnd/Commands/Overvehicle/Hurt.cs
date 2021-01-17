using System.Linq;
using LyokoAPI.Events.OVEvents;
using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.Overvehicle
{
    public class Hurt : Command
    {
        public override string Name => "hurt";
        public override string Usage => "ov.hurt.<overvehicle>.<amount>";
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
                throw new CommandException(this, $"{overvehicle.OvervehicleName} not virtualised!");
            }
            int damage = CheckNumber(1);
            OV_HurtEvent.Call(overvehicle, damage);
            Output($"{overvehicle.OvervehicleName} hurt by {damage}");
            if (overvehicle.HP < 0) OV_DevirtEvent.Call(overvehicle);
        }
    }
}
