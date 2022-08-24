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
        
        
        
        public void Activate(APIActivator activator = APIActivator.XANA)
        {
            if (!Activated)
            {
                if (activator == APIActivator.NONE)
                {
                    return;
                }

                Activator = activator;
                TowerActivationEvent.Call(new APITower(VirtualWorld.Name, Sector.Name, Number), activator);
            }
            else
            {
                if (activator == APIActivator.NONE)
                {
                    Deactivate();
                    return;
                }
                if (activator != Activator)
                {
                    Hijack(activator);
                }
                
            }
        }

        public void Hijack(APIActivator activator)
        {
            if (!Activated)
            {
                Activate(activator);
            }
            else if(activator == APIActivator.NONE)
            {
                Deactivate();
            }else if (activator != Activator)
            {
                TowerHijackEvent.Call(new APITower(VirtualWorld.Name,Sector.Name,Number),Activator,activator);
                Activator = activator;
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