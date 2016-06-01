using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sample2.CompilerGenerated
{
    public class Class1
    {
        public Task Run(Request request)
        {
            var stateMachine = new RunMethodStateMachine();

            stateMachine.@this = this;
            stateMachine.request = request;

            stateMachine.state = -1;

            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }

        private Task<string> ReadDataAsync(int itemId)
        {
            var stateMachine = new ReadDataAsyncStateMachine();

            stateMachine.@this = this;
            stateMachine.itemId = itemId;

            stateMachine.state = -1;

            stateMachine.builder = AsyncTaskMethodBuilder<string>.Create();
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }

        private Task WriteDataAsync(int itemId, string data)
        {
            var stateMachine = new WriteDataAsyncStateMachine();

            stateMachine.@this = this;
            stateMachine.itemId = itemId;
            stateMachine.data = data;

            stateMachine.state = -1;

            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
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
        {
        }

        [CompilerGenerated]
        private sealed class RunMethodStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder builder;

            public Class1 @this;
            public Request request;

            private int itemId;
            private string data;
            private string changedData;

            private TaskAwaiter<string> awaiter1;
            private TaskAwaiter awaiter2;

            void IAsyncStateMachine.MoveNext()
            {
                try
                {
                    var internalAwaiter1 = new TaskAwaiter<string>();
                    var internalAwaiter2 = new TaskAwaiter();

                    if (state == -1)
                    {
                        //note: синхронный пролог метода
                        itemId = @this.GetItemId(request);
                        internalAwaiter1 = @this.ReadDataAsync(itemId).GetAwaiter();

                        //note: точка возможного выхода из метода после вызова первой асинхронной операции
                        if (!internalAwaiter1.IsCompleted)
                        {
                            state = 0;

                            awaiter1 = internalAwaiter1;
                            var stateMachine = this;
                            builder.AwaitUnsafeOnCompleted(ref internalAwaiter1, ref stateMachine);
                            return;
                        }
                        else
                        {
                            state = 1;
                        }
                    }

                    if (state == 0)
                    {
                        internalAwaiter1 = awaiter1;
                        awaiter1 = new TaskAwaiter<string>();
                        state = 1;
                    }

                    if (state == 1)
                    {
                        //note: продолжение исполнения метода после первого await'а
                        data = internalAwaiter1.GetResult();
                        changedData = @this.ChangeData(data);
                        internalAwaiter2 = @this.WriteDataAsync(itemId, data).GetAwaiter();

                        //note: точка возможного выхода из метода после вызова второй асинхронной операции
                        if (!internalAwaiter2.IsCompleted)
                        {
                            state = 2;

                            awaiter2 = internalAwaiter2;
                            var stateMachine = this;
                            builder.AwaitUnsafeOnCompleted(ref internalAwaiter2, ref stateMachine);
                            return;
                        }
                    }

                    if (state == 2)
                    {
                        internalAwaiter2 = awaiter2;
                        awaiter2 = new TaskAwaiter();
                    }

                    //note: последняя часть метода
                    internalAwaiter2.GetResult();
                    @this.PostprocessRequest(request, changedData);
                }
                catch (Exception ex)
                {
                    state = -2;
                    builder.SetException(ex);
                    return;
                }
                state = -2;
                builder.SetResult();
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class ReadDataAsyncStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder<string> builder;
            public int itemId;
            public Class1 @this;
            private TaskAwaiter awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.state;
                string @string;
                try
                {
                    TaskAwaiter awaiter;
                    int num2;
                    if (num1 != 0)
                    {
                        awaiter = Task.Delay(100).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.state = num2 = 0;
                            this.awaiter = awaiter;
                            ReadDataAsyncStateMachine stateMachine = this;
                            this.builder.AwaitUnsafeOnCompleted<TaskAwaiter, ReadDataAsyncStateMachine>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.awaiter;
                        this.awaiter = new TaskAwaiter();
                        this.state = num2 = -1;
                    }
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter();
                    @string = Guid.NewGuid().ToString();
                }
                catch (Exception ex)
                {
                    this.state = -2;
                    this.builder.SetException(ex);
                    return;
                }
                this.state = -2;
                this.builder.SetResult(@string);
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class WriteDataAsyncStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder builder;
            public int itemId;
            public string data;
            public Class1 @this;
            private TaskAwaiter awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.state;
                try
                {
                    TaskAwaiter awaiter;
                    int num2;
                    if (num1 != 0)
                    {
                        awaiter = Task.Delay(100).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.state = num2 = 0;
                            this.awaiter = awaiter;
                            WriteDataAsyncStateMachine stateMachine = this;
                            this.builder.AwaitUnsafeOnCompleted<TaskAwaiter, WriteDataAsyncStateMachine>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.awaiter;
                        this.awaiter = new TaskAwaiter();
                        this.state = num2 = -1;
                    }
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter();
                }
                catch (Exception ex)
                {
                    this.state = -2;
                    this.builder.SetException(ex);
                    return;
                }
                this.state = -2;
                this.builder.SetResult();
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    }
}
