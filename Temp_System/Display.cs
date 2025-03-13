using System;

namespace Temp_System_Delegate
{
    internal class Display
    {
        public void Subscribe(Broker broker)
        {
            broker.Subscribe("TemperatureChanged", ShowTemperature);
        }
        public void ShowTemperature(TempArgs tempArgs)
        {
            Console.WriteLine($"The new temperature set to {tempArgs.tempValue}");

        }
    }
}
