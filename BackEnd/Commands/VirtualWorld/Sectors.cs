using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.VirtualWorldCommand
{
    public class Sectors : Command
    {
        public override string Name => "sectors";
        public override string Usage => "world.sectors.[world]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            var virtualworld = Network.GetOrCreate().GetVirtualWorld(args[0]);
            if (virtualworld == null)
            {
                throw new CommandException(this, "That virtual world does not exist!");
            }
            string list = "";
            foreach (Sector sector in virtualworld.Sectors)
            {
                list += $"{sector.Name}, ";
            }
            list = list.Trim(' ');
            list = list.Trim(',');
            list = list.Replace(", ", "\n");
            Output(list);
        }
    }
}
