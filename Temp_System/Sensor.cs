using System;

namespace Temp_System_Delegate
{
    internal class Sensor
    {
        public event EventHandler<TempArgs> SensorChanged;
        private int _CurrentTemperature { get; set; }

        public void ChangeTemp(int newTemperature)
        {
            this._CurrentTemperature = newTemperature;
            SensorChanged.Invoke(this, new TempArgs(newTemperature));
        }

    }
}
