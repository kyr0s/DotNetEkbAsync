using System.Threading.Tasks;

namespace Sample2
{
    public class Class1
    {
        public async Task Run(int count, string name)
        {
            var count1 = SyncMethod1(count, name);
            var name1 = await AsyncMethod1(count, name);

            var count2 = SyncMethod2(count1, name1);
            var name2 = await AsyncMethod2(count1, name1);

            SyncMethod3(count2, name2);
        }

        private async Task<string> AsyncMethod1(int count, string name)
        {
            await Task.Delay(100);
            return name;
        }

        private async Task<string> AsyncMethod2(int count, string name)
        {
            await Task.Delay(100);
            return name;
        }

        private int SyncMethod1(int count, string name)
        {
            return count;
        }

        private int SyncMethod2(int count, string name)
        {
            return count;
        }

        private void SyncMethod3(int count, string name)
        {}
    }
}
