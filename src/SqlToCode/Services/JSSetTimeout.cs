using System;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace SqlToCode.Services
{
    /// <summary>
    /// Simulates JavaScript setTimeout function
    /// </summary>
    public class JSsetTimeout : IDisposable
    {
        private ThreadStart threadStart;
        private object[] threadArgs;
        private object result = null;
        private Timer timer = null;

        public Timer Ticker
        {
            get { return timer; }
            set
            {
                if (timer != null)
                {
                    timer.Tick -= Timer_Tick;
                }
                timer = value;
                if (timer != null)
                {
                    timer.Tick += Timer_Tick;
                }
            }
        }

        public static void SetTimeout(ThreadStart obj, int TimeSpan)
        {
            JSsetTimeout jssto = new JSsetTimeout(obj, TimeSpan);
        }

        public JSsetTimeout(ThreadStart callback, int TimeSpan, params object[] args)
        {
            if (callback != null)
            {
                threadStart = callback;
                threadArgs = args;
                Ticker = new Timer
                {
                    Interval = TimeSpan,
                    Enabled = false
                };
                Ticker.Tick += Timer_Tick;
                Ticker.Start();
            }
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (Ticker != null)
            {
                Ticker.Tick -= Timer_Tick;
                Ticker.Stop();
                Ticker.Dispose();
                Ticker = null;
            }

            if (threadStart != null)
            {
                result = threadStart.DynamicInvoke(threadArgs);
            }
            else
            {
                result = null;
            }

            this.Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}