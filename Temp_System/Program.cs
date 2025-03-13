using System;

namespace Temp_System_Delegate
{
    internal class Program
    {
        public enum Choices { setTemp = 1, alarmValue = 2, exist = 3 };
        static bool alarmValueIsChanged = false;
        static int alarmValue = 20;
        public static Choices ReadChoice()
        {

            Console.WriteLine("\tChoice What do you want to do ? \n\t[1]:Set new temperature.\n\t[2]:Set alarm value.\n\t[3]:Exist");
            int input;
            do
            {
                Console.WriteLine("\tplease, Enter value is included menu..");
                input = int.Parse(Console.ReadLine());
                //Console.ReadKey();

            }
            while (input > 3);

            return (Choices)input;


        }
        public static void GoBackToMainMenu()
        {
            Console.WriteLine("\tPress any key to go back to ATM Main Menu......");
            Console.ReadKey();
            ProcessingChoice(ReadChoice());
        }
        public static void ProcessingChoice(Choices choice)
        {
            Broker broker = new Broker();
            Sensor sensor = new Sensor(broker);//subject
            //subscribers
            Display display = new Display();
            Alarm alarm;
            if (alarmValueIsChanged)
            {
                alarm = new Alarm(alarmValue);
            }
            else
            {
                alarm = new Alarm(20);
            }

            //subscription on event but not directory , by broker class 
            display.Subscribe(broker);
            alarm.Subscribe(broker);

            //subscription to event  This way when using OBSERVER PATTERN NOT PUB/SUB PATTERN
            //  sensor.SensorChanged += display.ShowTemperature;// add to Invocation list 
            //  sensor.SensorChanged += alarm.FireAlarm;

            switch (choice)
            {
                case Choices.setTemp:
                    Console.WriteLine("\tEnter a new temperature: ");
                    sensor.ChangeTemp(int.Parse(Console.ReadLine()));
                    GoBackToMainMenu();
                    break;
                case Choices.alarmValue:
                    Console.WriteLine($"\tEnter a new alarm value, by attention default value is {alarmValue}:");
                    alarmValue = int.Parse(Console.ReadLine());
                    alarm.ChangeAlarmValue(alarmValue);
                    alarmValueIsChanged = true;
                    GoBackToMainMenu();
                    break;
                case Choices.exist:
                    GoBackToMainMenu();
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            ProcessingChoice(ReadChoice());
            //  Console.ReadKey();
        }
    }
}
