using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample3
{
    class NewAsyncHttpServer
    {
        public static void Start()
        {
            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add("http://*:5000/");
                listener.Start();

                while (true)
                {
                    var context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(async _ => await ProcessRequest(context));
                }
            }
        }

        private static async Task ProcessRequest(HttpListenerContext context)
        {
            var relativePath = context.Request.Url.AbsolutePath.Trim('/', '\\');
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            try
            {
                using (var filestream = File.Open(path, FileMode.Open))
                {
                    var buffer = new byte[4*1024];
                    while (true)
                    {
                        var readCount = await filestream.ReadAsync(buffer, 0, buffer.Length);
                        await context.Response.OutputStream.WriteAsync(buffer, 0, readCount);

                        if (readCount < buffer.Length)
                        {
                            context.Response.OutputStream.Close();
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                context.Response.ContentEncoding = Encoding.UTF8;
                var result = context.Response.ContentEncoding.GetBytes(err.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.OutputStream.WriteAsync(result, 0, result.Length);
            }
        }
    }
}
