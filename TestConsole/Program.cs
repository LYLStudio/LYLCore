using System;
using System.IO;
using LYLStudio.Core.Logging;
using LYLStudio.Core.Threading;

using TestConsole.Models;
using TestConsole.Services;

namespace TestConsole
{
    class Program
    {
        private static string logTarget;
        static void Main(string[] args)
        {

            //Console.WriteLine(BinaryStringHelper.ByteArrayToHexString(new byte[] {1,3,5,6,7, 3, 5, 6, 7, 3, 5, 6, 7, 8, (byte)'a', (byte)'b',77,(byte)'f'  }, 8, " "));


            logTarget = Properties.Settings.Default.PATH_LOG_FILE;

            LogginService logSvc = new LogginService(new SequenceOperator<ILogItem[]>(nameof(LogginService)));

            logSvc.Log(logTarget, new LogItem("Start!!"));

            //TestModelDataServiceTest dataServiceTest = new TestModelDataServiceTest();
            //dataServiceTest.AccountChanged += (o, e) =>
            //{
            //    if (e is Account account)
            //    {
            //        Console.WriteLine($"{account.Id}:{account.Data}");
            //    }
            //};

         

            //dataServiceTest.Create();

            //dataServiceTest.SomethingProcess();

            //dataServiceTest.Fetch();

            //dataServiceTest.Update();

            //dataServiceTest.Delete();

            //dataServiceTest.IsExist();

            logSvc.Log(logTarget, new LogItem("End!!"));

            Console.ReadLine();
        }
    }


}
