using System;

namespace Temp_System_Delegate
{
    internal class Program
    {
        public enum Choices { setTemp = 1, alarmValue = 2, exist = 3 };
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
            Sensor sensor = new Sensor();
            Display display = new Display();
            Alarm alarm = new Alarm(20);
            sensor.SensorChanged += display.ShowTemperature;// add to Invocation list 
            sensor.SensorChanged += alarm.FireAlarm;

            switch (choice)
            {
                case Choices.setTemp:
                    Console.WriteLine("\tEnter a new temperature: ");
                    sensor.ChangeTemp(int.Parse(Console.ReadLine()));
                    GoBackToMainMenu();
                    break;
                case Choices.alarmValue:
                    Console.WriteLine("\tEnter a new alarm value, by attention default value is (20):");
                    alarm.ChangeAlarmValue(int.Parse(Console.ReadLine()));
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
