namespace task3.PBXPart
{
    internal class ControlDeviceBase : HardwareBase
    {


        internal ControlDeviceBase()
        {
            this.OnPowerChange += ControlDeviceBase_OnPowerChange;
        }

        private void ControlDeviceBase_OnPowerChange()
        {
            if (this.IsPowered)
            {
            }
            else
            {
            }
        }








        /*
        УПРАВЛЯЮЩЕЕ УСТРОЙСТВО
        Управляет коммутатором
        •	Имеет:
        o	Состояния:
        	Вкл. / откл.;
        •	Функционал:
        o	

        •	Генерируемые события:
        o	

        •	Обрабатываемые события:
        o	

        */
    }
}
