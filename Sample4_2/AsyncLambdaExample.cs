using System;
using System.Threading.Tasks;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
namespace Sample4_2
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
                        throw new Exception("random error");
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