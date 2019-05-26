using System;
using System.IO;
using LYLStudio.Core.Helper;
using LYLStudio.Core.Logging;
using LYLStudio.Core.Threading;

using TestConsole.Models;
using TestConsole.Services;

namespace TestConsole
{
    class Program
    {
        private static string _pathLogFile;
        static void Main(string[] args)
        {

            Console.WriteLine(BinaryStringHelper.ByteArrayToHexString(new byte[] {1,3,5,6,7, 3, 5, 6, 7, 3, 5, 6, 7, 8, (byte)'a', (byte)'b',77,(byte)'f'  }, 8, " "));


            _pathLogFile = Properties.Settings.Default.PATH_LOG_FILE;

            LogginService<ILogItem> logger = new LogginService<ILogItem>(new SequenceOperator<ILogItem>(nameof(LogginService<ILogItem>)))
            {
                LogCallback = (logItem) =>
                {
                    string logString = $"{logItem.Time}|{logItem.Category}|{logItem.Priority}|{logItem.Message}";
                    using (var sw = new StreamWriter(new FileStream(_pathLogFile, FileMode.Append)))
                    {
                        sw.WriteLine(logString);
                        sw.Close();
                    }

                    //Console.WriteLine(logString);
                }
            };

            logger.Log(new LogItem("Start!!"));

            TestModelDataServiceTest dataServiceTest = new TestModelDataServiceTest();
            dataServiceTest.AccountChanged += (o, e) =>
            {
                if (e is Account account)
                {
                    Console.WriteLine($"{account.Id}:{account.Data}");
                }
            };

         

            //dataServiceTest.Create();

            dataServiceTest.SomethingProcess();

            //dataServiceTest.Fetch();

            //dataServiceTest.Update();

            //dataServiceTest.Delete();

            //dataServiceTest.IsExist();

            logger.Log(new LogItem("End!!"));

            Console.ReadLine();
        }
    }


}
