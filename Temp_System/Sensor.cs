namespace Temp_System_Delegate
{
    internal class Sensor
    {
        private Broker _broker;
        public Sensor(Broker broker)
        {
            this._broker = broker;
        }
        //public event EventHandler<TempArgs> SensorChanged; // using when coding by OBSERVER PATTERN NOT PUB/SUB PATTERN
        private int _CurrentTemperature { get; set; }

        public void ChangeTemp(int newTemperature)
        {
            this._CurrentTemperature = newTemperature;
            //SensorChanged.Invoke(this, new TempArgs(newTemperature));
            _broker.Publish("TemperatureChanged", new TempArgs(newTemperature));
        }

    }
}
