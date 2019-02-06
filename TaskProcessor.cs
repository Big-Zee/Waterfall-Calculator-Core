using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WaterFallCalculator
{
    public class TaskProcessor
    {
        public delegate void TaskCompleDelegate(string message);
        public event TaskCompleDelegate CalculationCompleteEvent;
        private static Queue<Task> taskList;
        private Timer dequeueTimer;
        private object _object = new object();

        public TaskProcessor()
        {
            StartTaskProcessor();
        }

        private void StartTaskProcessor()
        {
            dequeueTimer = new Timer(CallBack, null, 0, 100);
            taskList = new Queue<Task>();
        }

        private void CallBack(object state)
        {
            CheckQueue();
        }

        private void CheckQueue()
        {
            if (taskList.Count > 0)
            {
                var task = taskList.Dequeue();
                task.Start();
                task.ContinueWith(s => { RaiseEvent(); });
            }
        }
        private void RaiseEvent()
        {
            CalculationCompleteEvent?.Invoke("Completed");
        }

        public void AddTaskToQueue(Task newTask)
        {
            taskList.Enqueue(newTask);
        }
    }

}
