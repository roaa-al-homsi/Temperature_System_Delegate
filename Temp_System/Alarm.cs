using System;

namespace Temp_System_Delegate
{
    public class Alarm
    {
        private int _CurrentAlarmValue { get; set; }//Threshold..

        public Alarm(int alarmValue)
        {
            this._CurrentAlarmValue = alarmValue;
        }
        public void ChangeAlarmValue(int newAlarmValue)
        {
            this._CurrentAlarmValue = newAlarmValue;
        }
        public void FireAlarm(object obj, TempArgs tempArgs)
        {
            if (tempArgs.tempValue > this._CurrentAlarmValue)
            {
                Console.WriteLine("Take care..the input value is greater than threshold..");
            }
        }
    }
}
