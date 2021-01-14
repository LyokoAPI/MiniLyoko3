using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Events;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.VirtualWorldCommand
{
    public class Destroy : Command
    {
        public override string Name => "destroy";
        public override string Usage => "world.destroy.[world]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            VirtualWorld virtualWorld = Network.GetOrCreate().GetVirtualWorld(args[0]);
            if (virtualWorld == null)
            {
                throw new CommandException(this, $"World {args[0]} doesnt exists!");
            }
            VirtualWorldDestructionEvent.Call(args[0]);
            Network.GetOrCreate().RemoveVirtualWorld(args[0]);
            Output($"World {args[0]} destroyed!");
        }
    }
}
