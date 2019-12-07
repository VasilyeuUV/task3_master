using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3.PBXPart
{

    /// <summary>
    /// PBX Switching system base variant
    /// </summary>
    internal class SwitchSystemBase
    {

        private const int SWITCHDEVICE_COUNT_DEFAULT = 20;
        private IEnumerable<SwitchDeviceBase> _switchDevices = null;


        /// <summary>
        /// Number of SwitchDevices in SwitchSystem
        /// </summary>
        internal IEnumerable<SwitchDeviceBase> SwitchDevices => _switchDevices ??= new List<SwitchDeviceBase>();

        
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="switchDeviceCount"></param>
        private SwitchSystemBase(int switchDeviceCount)
        {
            for (int i = 0; i < switchDeviceCount; i++)
            {
                ((List<SwitchDeviceBase>)this.SwitchDevices).Add(SwitchDeviceBase.CreateInstance());
            }
        }

        

        /// <summary>
        /// Create new SwitchSystem
        /// </summary>
        /// <param name="switchDeviceCount">number of SwitchDevices</param>
        /// <returns>new SwitchSystem (the default number of SwitchDevices is 20</returns>
        internal SwitchSystemBase CreateInstance(int switchDeviceCount = 0) => 
            switchDeviceCount < 1 
                              ? new SwitchSystemBase(SWITCHDEVICE_COUNT_DEFAULT) 
                              : new SwitchSystemBase(switchDeviceCount);

    }
}
