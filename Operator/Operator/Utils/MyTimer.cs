using System;
using System.Threading;
using Xamarin.Forms;

namespace Operator.Utils
{
    public class MyTimer
    {
        private readonly TimeSpan timespan;
        private readonly Action callback;

        private CancellationTokenSource cancellation;

        public MyTimer(TimeSpan Timespan, Action Callback)
        {
            timespan = Timespan;
            callback = Callback;
            cancellation = new CancellationTokenSource();
        }

        public void Start()
        {
            CancellationTokenSource cts = cancellation;
            Device.StartTimer(timespan, () => Invoke(cts));
        }

        public void Stop()
        {
            Interlocked.Exchange(ref cancellation, new CancellationTokenSource()).Cancel();
        }

        private bool Invoke(CancellationTokenSource cts)
        {
            if (cts.IsCancellationRequested)
            { return false; }
            callback.Invoke();
            return true;
        }
    }
}
