namespace Ditto.AsyncInit.Mvvm
{
    internal class StubTaskListener : ITaskListener
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
