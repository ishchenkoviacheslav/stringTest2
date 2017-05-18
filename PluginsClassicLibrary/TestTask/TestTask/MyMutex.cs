using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestTask
{
    class MyMutex : IDisposable
    {
        Mutex mutex = new Mutex(false, "MyMutex");
        public void Dispose()
        {
            Release();
        }
        public async Task<MyMutex> LockSection()
        {
            await Task.Run(() =>
            {
                mutex.WaitOne();
            });
            return this;
        }
        public async Task Lock()
        {
            await Task.Run(() =>
            {
                mutex.WaitOne();
            });
        }
        public void Release()
        {
            mutex.ReleaseMutex();

        }
    }
}
