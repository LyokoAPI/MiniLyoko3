using Domain;

namespace Backend.extensions
{
    public static class Extensions
    {
        public static string GetFullName(this Tower tower)
        {
            return $"{tower.VirtualWorld.Name}: {tower.Sector.Name} {tower.Number}";
        }
        
    }
}