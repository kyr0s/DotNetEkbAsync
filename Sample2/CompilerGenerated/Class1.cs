using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sample2.CompilerGenerated
{
    public class Class1
    {
        public Task Run(int count, string name)
        {
            var stateMachine = new RunMethodStateMachine();

            stateMachine.@this = this;
            stateMachine.count = count;
            stateMachine.name = name;

            stateMachine.state = -1;

            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }

        private Task<string> AsyncMethod1(int count, string name)
        {
            var stateMachine = new AsyncMethod1StateMachine();

            stateMachine.@this = this;
            stateMachine.count = count;
            stateMachine.name = name;

            stateMachine.state = -1;

            stateMachine.builder = AsyncTaskMethodBuilder<string>.Create();
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }

        private Task<string> AsyncMethod2(int count, string name)
        {
            var stateMachine = new AsyncMethod2StateMachine();

            stateMachine.@this = this;
            stateMachine.count = count;
            stateMachine.name = name;

            stateMachine.state = -1;

            stateMachine.builder = AsyncTaskMethodBuilder<string>.Create();
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
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
        {
        }

        [CompilerGenerated]
        private sealed class RunMethodStateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder builder;
            private TaskAwaiter<string> awaiter;

            public int state;

            public Class1 @this;
            public int count;
            public string name;

            private int count1;
            private string name1;

            private int count2;
            private string name2;

            void IAsyncStateMachine.MoveNext()
            {
                try
                {
                    var awaiter1 = new TaskAwaiter<string>();
                    var awaiter2 = new TaskAwaiter<string>();

                    if (state == -1)
                    {
                        count1 = @this.SyncMethod1(count, name);
                        awaiter1 = @this.AsyncMethod1(count, name).GetAwaiter();

                        if (!awaiter1.IsCompleted)
                        {
                            state = 0;

                            awaiter = awaiter1;
                            var stateMachine = this;
                            builder.AwaitUnsafeOnCompleted(ref awaiter1, ref stateMachine);
                            return;
                        }
                        else
                        {
                            state = 1;
                        }
                    }

                    if (state == 0)
                    {
                        awaiter1 = awaiter;
                        awaiter = new TaskAwaiter<string>();
                        state = 1;
                    }

                    if (state == 1)
                    {
                        name1 = awaiter1.GetResult(); ;
                        count2 = @this.SyncMethod2(count1, name1);
                        awaiter2 = @this.AsyncMethod2(count1, name1).GetAwaiter();

                        if (!awaiter2.IsCompleted)
                        {
                            state = 2;
                            awaiter = awaiter2;
                            var stateMachine = this;
                            builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                            return;
                        }
                    }

                    if (state == 2)
                    {
                        awaiter2 = awaiter;
                        awaiter = new TaskAwaiter<string>();
                    }

                    name2 = awaiter2.GetResult(); ;
                    @this.SyncMethod3(count2, name2);
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
        private sealed class AsyncMethod1StateMachine : IAsyncStateMachine
        {
            public int state;
      public AsyncTaskMethodBuilder<string> builder;
            public int count;
            public string name;
            public Class1 @this;
      private TaskAwaiter u__1;

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.state;
                string result;
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
                            this.u__1 = awaiter;
                            Class1.AsyncMethod1StateMachine stateMachine = this;
                            this.builder.AwaitUnsafeOnCompleted<TaskAwaiter, Class1.AsyncMethod1StateMachine>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.u__1;
                        this.u__1 = new TaskAwaiter();
                        this.state = num2 = -1;
                    }
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter();
                    result = this.name;
                }
                catch (Exception ex)
                {
                    this.state = -2;
                    this.builder.SetException(ex);
                    return;
                }
                this.state = -2;
                this.builder.SetResult(result);
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class AsyncMethod2StateMachine : IAsyncStateMachine
        {
            public int state;
      public AsyncTaskMethodBuilder<string> builder;
            public int count;
            public string name;
            public Class1 @this;
      private TaskAwaiter u__1;

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.state;
                string result;
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
                            this.u__1 = awaiter;
                            Class1.AsyncMethod2StateMachine stateMachine = this;
                            this.builder.AwaitUnsafeOnCompleted<TaskAwaiter, Class1.AsyncMethod2StateMachine>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.u__1;
                        this.u__1 = new TaskAwaiter();
                        this.state = num2 = -1;
                    }
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter();
                    result = this.name;
                }
                catch (Exception ex)
                {
                    this.state = -2;
                    this.builder.SetException(ex);
                    return;
                }
                this.state = -2;
                this.builder.SetResult(result);
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    }
}
