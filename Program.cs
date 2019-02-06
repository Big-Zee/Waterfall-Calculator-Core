using System;
using System.Diagnostics;

namespace WaterFallCalculator
{
    class Program
    {
        private static TaskProcessor sw = new TaskProcessor();
        private static CalculationOrder ca = new CalculationOrder();

        static void Main(string[] args)
        {
            sw.CalculationCompleteEvent += Sw_CalculationCompleteEvent;

            bool work = true;
            do
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Q:
                            {
                                work = false;
                            }
                            break;
                        case ConsoleKey.T:
                            {
                                sw.AddTaskToQueue(WorkItem.GenerateInitTask());
                            }
                            break;
                    }
                }
            } while (work);
        }

        private static void Sw_CalculationCompleteEvent(string message)
        {
            Trace.WriteLine($"Calculation Task complete! {message}");
            ca.JumpToNextTask();
            var current = ca.GetCurrentItem();
            switch (current)
            {
                case 0:
                    { Trace.WriteLine("Added 3s task to queue"); sw.AddTaskToQueue(WorkItem.Generate3secondsTask()); }
                    break;
                case 1:
                    { Trace.WriteLine("Added 1s task to queue"); sw.AddTaskToQueue(WorkItem.Generate1secondsTask()); }
                    break;
                case 2:
                    { Trace.WriteLine("Added 10ms task to queue"); sw.AddTaskToQueue(WorkItem.Generate10mssecondsTask()); }
                    break;
            }
        }
    }

}
