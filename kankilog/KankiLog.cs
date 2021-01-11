using System;
using System.IO;

namespace kankilog
{
    public static class KankiLog
    {
        private static string LogDateTextFormat = "dd.MM.yyyy HH:mm:ss.fff";
        private static string LogFileNameFormat = "yyyyMMdd";
        private static string MainPath;

        public static string GetMainLogFolderPath()
        {
            string mainPath = string.IsNullOrEmpty(MainPath) ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs") : MainPath;
            return mainPath;
        }

        public static string GetLogFilePath()
        {
            string currentDatePath = $"{DateTime.Now.ToString(LogFileNameFormat)}.log";
            string fullPath = Path.Combine(GetMainLogFolderPath(), currentDatePath);

            return fullPath;
        }

        public static void SetMainPath(string pathText)
        {
            MainPath = pathText;
        }

        private static void WriteLog(string text)
        {
            if (!Directory.Exists(GetMainLogFolderPath()))
                Directory.CreateDirectory(GetMainLogFolderPath());

            if (!File.Exists(GetLogFilePath()))
            {
                using (StreamWriter sw = File.CreateText(GetLogFilePath()))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(GetLogFilePath()))
                {
                    sw.WriteLine(text);
                }
            }
        }

        public static void LogToText(KankiLogType logType, string text)
        {
            string logText = $"{DateTime.Now.ToString(LogDateTextFormat)} - {logType.ToString()} - {text}";
            WriteLog(logText);
        }
    }
}