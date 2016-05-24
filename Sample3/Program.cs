using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Sample3
{
    class Program
    {
        private static long requestCounter;

        static void Main(string[] args)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://*:5000/");

            listener.Start();

            while (true)
            {
                requestCounter++;

                Console.WriteLine($"Waiting for request {requestCounter}");

                var state = new StateWithNumber {RequestNumber = requestCounter, State = listener};
                var asyncResult = listener.BeginGetContext(ProcessRequest, state);
                asyncResult.AsyncWaitHandle.WaitOne();
            }
        }

        private static void ProcessRequest(IAsyncResult asyncResult)
        {
            var state = (StateWithNumber) asyncResult.AsyncState;

            Console.WriteLine($"Internal waiting for request {state.RequestNumber}");

            var listener = (HttpListener) state.State;
            var httpListenerContext = listener.EndGetContext(asyncResult);

            Console.WriteLine($"Start processing request {state.RequestNumber}");

            Thread.Sleep(5000);

            var result = Encoding.UTF8.GetBytes("OK");
            var writeState = new StateWithNumber {RequestNumber = state.RequestNumber, State = httpListenerContext};
            httpListenerContext.Response.OutputStream.BeginWrite(result, 0, result.Length, ProcessResponseWriteEnd, writeState);
        }

        private static void ProcessResponseWriteEnd(IAsyncResult asyncResult)
        {
            var state = (StateWithNumber)asyncResult.AsyncState;
            var httpListenerContext = (HttpListenerContext) state.State;

            httpListenerContext.Response.Close();
            Console.WriteLine($"End processing request {state.RequestNumber}");
        }

        private class StateWithNumber
        {
            public long RequestNumber { get; set; }
            public object State { get; set; }
        }
    }
}
