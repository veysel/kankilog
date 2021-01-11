using System;
using System.Timers;
using kankilog;

namespace kankilog.console
{
    class Program
    {
        static Timer _timer;

        static void Main(string[] args)
        {
            Console.WriteLine("Start App...");

            KankiLog.LogToText(KankiLogType.INFO, "Sistem logu atmaya çalışıyor.");

            _timer = new Timer(3000);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true;

            Console.ReadKey();
        }

        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Log Write...");

            _timer.Enabled = false;

            KankiLog.LogToText(KankiLogType.INFO, "Deneme amaçlı bu log atıldı...");
            System.Threading.Thread.Sleep(1000);
            KankiLog.LogToText(KankiLogType.WARN, "Deneme amaçlı bu log atıldı...");
            System.Threading.Thread.Sleep(1000);
            KankiLog.LogToText(KankiLogType.ERROR, "Deneme amaçlı bu log atıldı...");
            System.Threading.Thread.Sleep(1000);
            KankiLog.LogToText(KankiLogType.FATAL, "Deneme amaçlı bu log atıldı...");
            System.Threading.Thread.Sleep(1000);
            KankiLog.LogToText(KankiLogType.EXCEPTION, "Deneme amaçlı bu log atıldı...");
            System.Threading.Thread.Sleep(1000);

            _timer.Enabled = true;
        }
    }
}