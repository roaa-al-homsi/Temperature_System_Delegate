using System;

namespace Temp_System_Delegate
{
    internal class Display
    {
        public void ShowTemperature(object obj, TempArgs tempArgs)
        {
            Console.WriteLine($"The new temperature set to {tempArgs.tempValue}");

        }
    }
}
