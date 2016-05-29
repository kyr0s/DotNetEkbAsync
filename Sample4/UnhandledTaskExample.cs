using System;
using System.Threading.Tasks;

namespace Sample4
{
    class UnhandledTaskExample
    {
        public static void Run()
        {
            TaskScheduler.UnobservedTaskException += HandleUnobserved;

            try
            {
                while (true)
                {
                    GC.Collect();
                    var command = Console.ReadLine();
                    ProcessAsync(command);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Error catched:\r\n" + err);
            }
        }

        private static async Task ProcessAsync(string command)
        {
            await Task.Delay(100);

            throw new Exception("random error");
            Console.WriteLine($"Command '{command}' processed");
        }

        private static void HandleUnobserved(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            Console.WriteLine("Unobserved task error catched:\r\n" + unobservedTaskExceptionEventArgs.Exception);
            unobservedTaskExceptionEventArgs.SetObserved();
        }
    }
}