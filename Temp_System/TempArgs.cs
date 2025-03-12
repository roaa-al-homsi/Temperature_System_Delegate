using System;

namespace Temp_System_Delegate
{
    public class TempArgs : EventArgs
    {
        public int tempValue { get; set; }
        public TempArgs(int tempValue)
        {
            this.tempValue = tempValue;
        }

    }
}
