using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupThreadPool(4);

            const int tasksCount = 9;

            RunParallelSync(tasksCount);
            Console.ReadKey();

            RunParallelAsync(tasksCount);
            Console.ReadKey();
        }

        private static void SetupThreadPool(int maxWorkerThreads)
        {
            int workerThreads, completionPortThreads;
            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);

            ThreadPool.SetMinThreads(maxWorkerThreads, completionPortThreads);
            ThreadPool.SetMaxThreads(maxWorkerThreads, completionPortThreads);
        }

        private static void RunParallelSync(int tasksCount)
        {
            var sw = Stopwatch.StartNew();

            var tasks = Enumerable.Range(0, tasksCount)
                .Select(i => Task.Factory.StartNew(WaitSync))
                .ToArray();

            Task.WaitAll(tasks);

            sw.Stop();
            Console.WriteLine($"Parallel sync run ends in {sw.Elapsed.TotalSeconds:F0} seconds.");
        }

        private static void WaitSync()
        {
            Thread.Sleep(1000);
        }

        private static void RunParallelAsync(int tasksCount)
        {
            var sw = Stopwatch.StartNew();

            var tasks = Enumerable.Range(0, tasksCount)
                .Select(i => WaitAsync())
                .ToArray();

            Task.WaitAll(tasks);

            sw.Stop();
            Console.WriteLine($"Parallel async run ends in {sw.Elapsed.TotalSeconds:F0} seconds.");
        }

        private static async Task WaitAsync()
        {
            await Task.Delay(1000);
        }
    }
}
