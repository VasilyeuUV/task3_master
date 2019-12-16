using System;

namespace task3.PBXPart
{
    public abstract class HardwareBase
    {
        internal event Action OnPowerChange = delegate { };

        public bool IsPowered { get; private set; } = false;

        internal void PowerOn()
        {
            this.IsPowered = true;
            OnPowerChange();
        }

        internal void PowerOff()
        {
            this.IsPowered = false;
            OnPowerChange();
        }
    }
}
