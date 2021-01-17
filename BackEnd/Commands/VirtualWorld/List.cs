using BackEnd.Extensions;
using Domain;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.VirtualWorldCommand
{
    public class List : Command
    {
        public override string Name => "list";
        public override string Usage => "world.list";

        protected override void DoCommand(string[] args)
        {
            string list = "";
            foreach (VirtualWorld virtualWorld in Network.GetOrCreate().VirtualWorlds)
            {
                list += $"{virtualWorld.Name}, ";
            }
            list = list.Trim(' ');
            list = list.Trim(',');
            list = list.Replace(", ", "\n");
            Output(list);
        }
    }
}
