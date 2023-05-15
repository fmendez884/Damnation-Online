using System.IO;
using UnityEngine;

public static class Logger
{
    private static StreamWriter logFile;

    public static void OpenLog(string filePath)
    {
        logFile = new StreamWriter(filePath, true) { AutoFlush = true };
        Debug.Log("Log file opened: " + filePath);
    }

    public static void Log(string message)
    {
        if (logFile != null)
        {
            logFile.WriteLine(message);
        }
    }

    public static void CloseLog()
    {
        if (logFile != null)
        {
            logFile.Close();
            logFile = null;
            Debug.Log("Log file closed");
        }
    }
}
