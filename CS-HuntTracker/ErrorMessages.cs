using System;
using System.IO;

namespace CS_HuntTracker
{
    static class ErrorMessages
    {
        public static void LogError(Exception e, string method)
        {
            File.AppendAllText($"ErrorLog-{DateTime.Today.ToString("yyyyMMdd")}.txt", $"{DateTime.Now} - Problem in {method}: {e.Message}.\r\n");
        }
    }
}
