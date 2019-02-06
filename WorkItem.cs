using System.Threading;
using System.Threading.Tasks;

namespace WaterFallCalculator
{
    public static class WorkItem
    {
        public static Task GenerateInitTask()
        {
            return new Task(GetInitCalcTask);
        }

        private static void GetInitCalcTask()
        {
            Thread.Sleep(10000);
        }

        public static Task Generate3secondsTask()
        {
            return new Task(Get3sTask);
        }


        private static void Get3sTask()
        {
            Thread.Sleep(3000);
        }

        public static Task Generate1secondsTask()
        {
            return new Task(Get1sTask);
        }

        private static void Get1sTask()
        {
            Thread.Sleep(1000);
        }

        public static Task Generate10mssecondsTask()
        {
            return new Task(Get10mssTask);
        }

        private static void Get10mssTask()
        {
            Thread.Sleep(10);
        }
    }

}
