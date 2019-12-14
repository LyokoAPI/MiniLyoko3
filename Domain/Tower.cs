using System;
using LyokoAPI.API;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;


namespace Domain
{
    public class Tower
    {
        public int Number { get; set; }
        public Sector Sector { get; set; }
        public VirtualWorld VirtualWorld => Sector.VirtualWorld;
        public APIActivator Activator { get; set; }
        public bool Activated => Activator != APIActivator.NONE;

        public Tower(Sector sector, int id)
        {
            this.Sector = sector;
            Number = id;
        }
        
        
        
        public void Activate(string activator = "XANA")
        {
            var newactivator = LyokoParser.ParseActivator(activator.ToUpper());
            if (!Activated)
            {
                if (newactivator == APIActivator.NONE)
                {
                    return;
                }

                Activator = newactivator;
                TowerActivationEvent.Call(VirtualWorld.Name, Sector.Name, Number, newactivator.ToString());
            }
            else
            {
                if (newactivator == APIActivator.NONE)
                {
                    Deactivate();
                    return;
                }
                if (newactivator != Activator)
                {
                    Hijack(newactivator.ToString());
                }
                
            }
        }

        public void Hijack(string activator)
        {
            var newactivator = LyokoParser.ParseActivator(activator.ToUpper());

            if (!Activated)
            {
                Activate(activator);
            }
            else if(newactivator == APIActivator.NONE)
            {
                Deactivate();
            }else if (newactivator != Activator)
            {
                TowerHijackEvent.Call(new APITower(VirtualWorld.Name,Sector.Name,Number),newactivator,Activator);
                Activator = newactivator;
            }
        }

        public void Deactivate()
        {
            if (Activated)
            {
                Activator = APIActivator.NONE;
                TowerDeactivationEvent.Call(VirtualWorld.Name,Sector.Name,Number);
            }
        }
    }
}