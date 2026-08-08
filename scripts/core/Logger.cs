using Godot;
using System;

namespace Game.Core
{
    public static class Logger
    {
        public static void Log(string level, params object[] message)
        {
            var dataTime = DateTime.Now;
            string timeStamp= $"[{dataTime:yyyy-MM-dd HH:mm:ss}] ";
            var callingMethod = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
            string logMessage = $"{timeStamp} [{level}] [{callingMethod.DeclaringType.Name}] [{callingMethod.Name}] ";
            GD.Print([logMessage, ..message]);
        }

        public static void Debug(params object[] message)
        {
            Log("Debug", message);
        }

        public static void Info(params object[] message)
        {
            Log("Info", message);
        }

        public static void Warning(params object[] message)
        {
            Log("Warning", message);
        }

        public static void Error(params object[] message)
        {
            Log("Error", message);
        }
    }
}