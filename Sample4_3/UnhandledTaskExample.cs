using System;
using System.Threading.Tasks;

namespace Sample4_3
{
    class UnhandledTaskExample
    {
        public static async void Run()
        {
//            SetupExceptionHandle();

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
        }

        #region exception handling
        private static void HandleUnobserved(object sender, UnobservedTaskExceptionEventArgs eventArgs)
        {
            Console.WriteLine("Unobserved task error catched:\r\n" + eventArgs.Exception);
            eventArgs.SetObserved();
        }

        private static void SetupExceptionHandle()
        {
            TaskScheduler.UnobservedTaskException += HandleUnobserved;
        }
        #endregion
    }
}