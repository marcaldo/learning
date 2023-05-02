using System.Reflection;

namespace MeasurePerformance.Helpers
{
    public class MethodTimerLogger
    {
        public static ILogger Logger;

        public static void Log(MethodBase methodBase, TimeSpan elapsed, string message)
        {
            Logger.LogTrace("{Class}.{Method} {Duration} - {Message}",
                methodBase.DeclaringType!.Name, methodBase.Name, elapsed, message);
        }
    }
}
