using System;
using System.Threading.Tasks;

namespace Sample2
{
    public class Class1
    {
        public async Task Run(Request request)
        {
            var itemId = GetItemId(request);
            var data = await ReadDataAsync(itemId);

            var changedData = ChangeData(data);
            await WriteDataAsync(itemId, data);

            PostprocessRequest(request, changedData);
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

        private void PostprocessRequest(Request request, string data)
        {}
    }
}
