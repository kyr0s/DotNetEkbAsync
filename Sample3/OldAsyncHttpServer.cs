using System;
using System.IO;
using System.Net;
using System.Text;

namespace Sample3
{
    class OldAsyncHttpServer
    {
        public static void Start()
        {
            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add("http://*:5000/");
                listener.Start();

                while (true)
                {
                    var asyncResult = listener.BeginGetContext(ProcessRequest, listener);
                    asyncResult.AsyncWaitHandle.WaitOne();
                }
            }
        }

        private static void ProcessRequest(IAsyncResult asyncResult)
        {
            var listener = (HttpListener)asyncResult.AsyncState;
            var httpListenerContext = listener.EndGetContext(asyncResult);

            var relativePath = httpListenerContext.Request.Url.AbsolutePath.Trim('/', '\\');
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            try
            {
                var filestream = File.Open(path, FileMode.Open);
                var state = ReadState.CreateNew(filestream, httpListenerContext);
                state.ReadStream.BeginRead(state.Buffer, 0, state.Buffer.Length, ProcessFileReadEnd, state);
            }
            catch (Exception err)
            {
                httpListenerContext.Response.ContentEncoding = Encoding.UTF8;
                var result = httpListenerContext.Response.ContentEncoding.GetBytes(err.ToString());
                httpListenerContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var state = ReadState.CreateEnded(httpListenerContext);
                httpListenerContext.Response.OutputStream.BeginWrite(result, 0, result.Length, ProcessResponseWriteEnd, state);
            }
        }

        private static void ProcessFileReadEnd(IAsyncResult asyncResult)
        {
            var state = (ReadState) asyncResult.AsyncState;

            var readCount = state.ReadStream.EndRead(asyncResult);
            state.ReadEnded = readCount < state.Buffer.Length;

            state.Context.Response.OutputStream.BeginWrite(state.Buffer, 0, readCount, ProcessResponseWriteEnd, state);
        }

        private static void ProcessResponseWriteEnd(IAsyncResult asyncResult)
        {
            var state = (ReadState)asyncResult.AsyncState;

            if (state.ReadEnded)
            {
                state.Context.Response.Close();
                state.ReadStream?.Close();
            }
            else
            {
                state.ReadStream.BeginRead(state.Buffer, 0, state.Buffer.Length, ProcessFileReadEnd, state);
            }
        }

        private class ReadState
        {
            private const int bufferSize = 4*1024;

            public static ReadState CreateNew(Stream readStream, HttpListenerContext context)
            {
                return new ReadState(readStream, context);
            }

            public static ReadState CreateEnded(HttpListenerContext context)
            {
                return new ReadState(true, context);
            }

            private ReadState(bool readEnded, HttpListenerContext context)
            {
                ReadEnded = readEnded;
                Buffer = new byte[bufferSize];
                Context = context;
            }

            private ReadState(Stream readStream, HttpListenerContext context) : this(false, context)
            {
                ReadStream = readStream;
            }

            public HttpListenerContext Context { get; }

            public bool ReadEnded { get; set; }
            public Stream ReadStream { get; }
            public byte[] Buffer { get; }
        }
    }
}
