using System;
using System.Threading.Tasks;

namespace Sample4
{
    class AsyncVoidExample
    {
        public static void Run()
        {
            try
            {
                while (true)
                {
                    var command = Console.ReadLine();
                    ProcessAsync(command);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Error catched:\r\n" + err);
            }
        }

        private static async void ProcessAsync(string command)
        {
            await Task.Delay(100);

//            throw new Exception("random error");
            Console.WriteLine($"Command '{command}' processed");
        }
    }
}
