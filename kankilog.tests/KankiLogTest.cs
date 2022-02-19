using System;
using Xunit;
using kankilog;

namespace kankilog.tests
{
    public class KankiLogTest
    {
        [Theory]
        [InlineData("INFO", KankiLogType.INFO)]
        [InlineData("WARN", KankiLogType.WARN)]
        [InlineData("ERROR", KankiLogType.ERROR)]
        [InlineData("FATAL", KankiLogType.FATAL)]
        [InlineData("EXCEPTION", KankiLogType.EXCEPTION)]
        public void LogToText_CheckTextLogType_LogTypeEqualText(string logText, KankiLogType kankiLogType)
        {
            Assert.Equal(logText, kankiLogType.ToString());
        }

        [Fact]
        public void LogToText_CheckTextMainPathText_MainPathTextLengthNotZero()
        {
            Assert.NotEqual(0, KankiLog.GetMainLogFolderPath().Length);
        }

        [Fact]
        public void LogToText_CheckLogFilePathText_LogFilePathLengthNotZero()
        {
            Assert.NotEqual(0, KankiLog.GetLogFilePath().Length);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("as")]
        [InlineData("asd")]
        [InlineData("asd/asd/asd")]
        public void LogToText_CheckSetMainPath_EqualMainPathLength(string testText)
        {
            KankiLog.SetMainPath(testText);

            Assert.Equal(testText.Length, KankiLog.GetMainLogFolderPath().Length);
        }

        [Fact]
        public void LogToText_CheckThrowException_NotEqualException()
        {
            KankiLog.SetMainPath(null);
            KankiLog.LogToText(KankiLogType.INFO, "test");
            KankiLog.LogToText(KankiLogType.INFO, "test");

            KankiLog.SetMainPath($"logs-{new Random().Next(10000000)}-{new Random().Next(10000000)}");
            KankiLog.LogToText(KankiLogType.INFO, "test");
            KankiLog.LogToText(KankiLogType.INFO, "test");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LogToText_SetIsThrowException(bool isThrowException)
        {
            KankiLog.SetIsThrowException(isThrowException);
        }

        [Fact]
        public void LogToText_SetIsThrowException_CheckThrowException()
        {
            KankiLog.SetMainPath($"logs-{new Random().Next(10000000)}-{new Random().Next(10000000)}");
            KankiLog.SetIsThrowException(true);

            KankiLog.LogToText(KankiLogType.INFO, "test1");
            var fs = new System.IO.FileStream(KankiLog.GetLogFilePath(), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);

            var exception = Record.Exception(() => KankiLog.LogToText(KankiLogType.INFO, "test2"));
            Assert.NotNull(exception);

            fs.Close();
        }

        [Fact]
        public void LogToText_SetIsThrowException_CheckNotThrowException()
        {
            KankiLog.SetMainPath($"logs-{new Random().Next(10000000)}-{new Random().Next(10000000)}");
            KankiLog.SetIsThrowException(false);

            KankiLog.LogToText(KankiLogType.INFO, "test1");
            var fs = new System.IO.FileStream(KankiLog.GetLogFilePath(), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
            
            var exception = Record.Exception(() => KankiLog.LogToText(KankiLogType.INFO, "test2"));
            Assert.Null(exception);
        }

        [Fact]
        public void LogToText_SetIsThrowException_CheckNotThrowException_ForDefaultIsThrowException()
        {
            KankiLog.SetMainPath($"logs-{new Random().Next(10000000)}-{new Random().Next(10000000)}");
            
            KankiLog.LogToText(KankiLogType.INFO, "test1");
            var fs = new System.IO.FileStream(KankiLog.GetLogFilePath(), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
            
            var exception = Record.Exception(() => KankiLog.LogToText(KankiLogType.INFO, "test2"));
            Assert.Null(exception);
        }
    }
}