using System;
using System.Threading.Tasks;

namespace Sample2
{
    public class Class2
    {
        public Task Run(Request request)
        {
            var itemId = GetItemId(request);
            var readDataTask = ReadDataAsync(itemId);

            var continuation = readDataTask
                .ContinueWith(t =>
                {
                    var data = t.Result;
                    var changedData = ChangeData(data);
                    var writeDataTask = WriteDataAsync(itemId, changedData);
                    return writeDataTask;
                })
                .ContinueWith(t =>
                {
                    PostprocessRequest(request);
                });

            return continuation;
        }

        private async Task<string> ReadDataAsync(int itemId)
        {
            await Task.Delay(100);
            return Guid.NewGuid().ToString();
        }

        private async Task WriteDataAsync(int itemId, string data)
        {
            await Task.Delay(100);
        }

        private int GetItemId(Request request)
        {
            return int.Parse(request.ItemId);
        }

        private string ChangeData(string data)
        {
            return Guid.NewGuid().ToString();
        }

        private void PostprocessRequest(Request request)
        { }
    }
}
