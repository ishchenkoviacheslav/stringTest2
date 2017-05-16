using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
        static class TaskMethods
    {
        public static Task ContinueWithMy(this Task CurrentTask, Action action)
        {
            return new Task(action);
        }
        public static Task ContinueWithMy(this Task CurrentTask, Action<Task> action)
        {
           Task obj = new Task(() => { action.Invoke(CurrentTask); });
            return obj;
        }
        public static Task<T> ContinueWithMy<T>(this Task CurrentTask, Func<T> func)
        {
            return new Task<T>(func);
        }
        public static Task<T> ContinueWithMy<T>(this Task CurrentTask, Func<Task<T>> func)
        {
            Task<T> task = new Task<T>(() =>
            {
                return func().Result;
            });
            return task;
        }
        public static Task<T> ContinueWithMy<T>(this Task CurrentTask, Func<Task,T> func)
        {
            Task<T> task = new Task<T>(() =>
            {
                return func(CurrentTask);
            });
            return task;
        }
        public static Task<T> ContinueWithMy<T>(this Task CurrentTask, Func<Task, Task<T>> func)
        {
            Task<T> obj = null;
            obj = new Task<T>(() => { return func(); }, new System.Threading.CancellationToken());
            return obj;
        }
    }
}
