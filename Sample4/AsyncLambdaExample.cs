
using System;
using System.Threading.Tasks;

namespace Sample4
{
    class AsyncLambdaExample
    {
        public static void Run()
        {
            try
            {
                while (true)
                {
                    Execute(async () =>
                    {
                        var command = Console.ReadLine();

                        await Task.Delay(100);
//                        throw new Exception("random error");

                        Console.WriteLine($"Command '{command}' processed");
                    });
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Error catched:\r\n" + err);
            }
        }

        private static void Execute(Action command)
        {
            command();
        }
    }
}