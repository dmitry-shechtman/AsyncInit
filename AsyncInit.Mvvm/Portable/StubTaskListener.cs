namespace Ditto.AsyncInit.Mvvm
{
    internal sealed class StubTaskListener : ITaskListener
    {
        public static readonly StubTaskListener Instance = new StubTaskListener();

        private StubTaskListener()
        {
        }

        void ITaskListener.NotifyTaskStarting()
        {
        }

        void ITaskListener.NotifyTaskCompleted(bool? isSuccess)
        {
        }
    }
}
