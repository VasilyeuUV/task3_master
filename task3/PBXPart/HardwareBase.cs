namespace task3.PBXPart
{
    public abstract class HardwareBase
    {



        public bool IsPowered { get; protected set; } = false;

        public void PowerOn() => this.IsPowered = true;
        public void PowerOff() => this.IsPowered = false;

    }
}
