using Domain;
using LyokoAPI.VirtualEntities.Overvehicle;

namespace BackEnd.Extensions
{
    public static class Extensions
    {
        public static string GetFullName(this Tower tower)
        {
            return $"{tower.VirtualWorld.Name}: {tower.Sector.Name} {tower.Number}";
        }

        public static bool IsFull(this Overvehicle overvehicle)
        {
            return overvehicle.WarriorPassenger != null && overvehicle.WarriorRider != null;
        }

        public static bool IsEmpty(this Overvehicle overvehicle)
        {
            return overvehicle.WarriorPassenger == null && overvehicle.WarriorRider == null;
        }
        
    }
}