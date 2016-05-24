using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Sample3.Cleared
{
    class Program
    {
        static void Main1(string[] args)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://*:5000/");

            listener.Start();

            while (true)
            {
                var asyncResult = listener.BeginGetContext(ProcessRequest, listener);
                asyncResult.AsyncWaitHandle.WaitOne();
            }
        }

        private static void ProcessRequest(IAsyncResult asyncResult)
        {
            var listener = (HttpListener)asyncResult.AsyncState;
            var httpListenerContext = listener.EndGetContext(asyncResult);

            Thread.Sleep(5000);

            var result = Encoding.UTF8.GetBytes("OK");
            httpListenerContext.Response.OutputStream.BeginWrite(result, 0, result.Length, ProcessResponseWriteEnd, httpListenerContext);
        }

        private static void ProcessResponseWriteEnd(IAsyncResult asyncResult)
        {
            var httpListenerContext = (HttpListenerContext)asyncResult.AsyncState;

            httpListenerContext.Response.Close();
        }
    }
}
