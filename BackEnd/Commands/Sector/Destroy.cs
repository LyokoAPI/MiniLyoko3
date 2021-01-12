using Backend.extensions;
using Domain;
using LyokoAPI.API;
using LyokoAPI.Events;

namespace Backend.Commands.SectorCommand
{
    public class Destroy : Command
    {
        public override string Name => "destroy";
        public override string Usage => "sector.destroy.[world].[sector]";
        public override int MinArgs => 2;

        protected override void DoCommand(string[] args)
        {
            var virtualworld = Network.GetOrCreate().GetVirtualWorld(args[0]);
            if (virtualworld == null)
            {
                throw new CommandException(this, "That virtual world does not exist!");
            }
            if (virtualworld.GetSector(args[1]) != null)
            {
                SectorDestructionEvent.Call(virtualworld.Name, args[1]);
                virtualworld.RemoveSector(args[1]);
                Output($"Destroyed Sector {args[1]} in {virtualworld.Name}");
            }
            else
            {
                Output($"Sector {args[1]} doesnt exist!");
            }
        }
    }
}
