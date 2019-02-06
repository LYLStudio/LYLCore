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
        static void Main(string[] args)
        {
            LogginService<ILogItem> logger = new LogginService<ILogItem>(new SequenceOperator<ILogItem>(nameof(LogginService<ILogItem>)))
            {
                LogCallback = (logItem) =>
                {
                    string logString = $"{logItem.Time}|{logItem.Category}|{logItem.Priority}|{logItem.Message}";
                    using (var sw = new StreamWriter(new FileStream("log.txt", FileMode.Append)))
                    {
                        sw.WriteLine(logString);                        
                        sw.Close();
                    }

                    //Console.WriteLine(logString);
                }
            };

            logger.Log(new LogItem("Start!!"));
            
            TestModelDataServiceTest dataServiceTest = new TestModelDataServiceTest();

            dataServiceTest.Create();

            dataServiceTest.Fetch();

            dataServiceTest.Update();

            dataServiceTest.Delete();

            dataServiceTest.IsExist();

            logger.Log(new LogItem("End!!"));

            Console.ReadLine();
        }
    }
    

}
