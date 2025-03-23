using System.Diagnostics;

namespace TimeTrackingApi.Logger
{
    public class TimeTrackingLogger : ITimeTrackingLogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
