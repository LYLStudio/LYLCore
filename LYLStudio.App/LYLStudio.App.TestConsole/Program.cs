using System;
using System.IO;
using LYLStudio.App.TestConsole.Models;
using LYLStudio.App.TestConsole.Services;
using LYLStudio.Core;
using LYLStudio.Core.Logging;
using LYLStudio.Core.Threading;
using LYLStudio.App.TestConsole.AccountOpening.NaturalPerson;
using System.Collections.Generic;

namespace LYLStudio.App.TestConsole
{
    class Program
    {
        static readonly string logTarget = Path.Combine(Properties.Settings.Default.LOG_PATH, $"{DateTime.Today.ToDateFormated()}.log");
        static readonly LogginService logSvc = new LogginService(new SequenceOperator<ILogItem[]>(nameof(LogginService)));
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            logSvc.Callback = (target, log) =>
            {
                foreach (var item in log)
                {
                    Console.WriteLine($"{item.Time.ToLogFormat()},{item.Message},{item.Error?.GetAllMessages()}");
                }
            };
            logSvc.Log(logTarget, new LogItem("START!!"));
            //var seqOperator = new SequenceOperator<string>(nameof(TestModelService));
            //seqOperator.OperationOccurred += SeqOperator_OperationOccurred;
            //seqOperator.Enqueue(new Anything<string>()
            //{
            //    Callback = o =>
            //    {
            //        using (var svc = new TestModelService())
            //        {
            //            var result = svc.Create(new Account() { Id = 1, Name = "aaaa" });
            //            logSvc.Log(logTarget, new LogItem($"{result.Id}|{result.IsSuccess}|{result.Message}") { Error = result.Error });
            //        }

            //    }
            //});

            //IdentityType identityType = IdentityType.NaturalPerson;

            //var members = typeof(IdentityType).GetMember(identityType.ToString());
            //var attributes = members[0].GetCustomAttributes(typeof(DBValueAttribute), false);
            //var dbValue = (attributes[0] as DBValueAttribute).DbValue;

            var application = new ApplicationOfNaturalPerson()
            {
                ApplyTime = DateTime.Now,
                DigitalDemandSavingsDepositType = DigitalDemandSavingsDepositTypeEnum.Class3,
                BasicInfo = new BasicInfoOfNaturalPerson()
                {
                    Id = "X123456789",
                    Name = "王曉明",
                    LegalDate = DateTime.Parse("1905/1/1"),
                    IdentityType = IdentityTypeEnum.NaturalPerson,
                    Gender = GenderTypeEnum.Male,
                    ElementarySchoolName = "不愛念書小學校",
                    IdentityDocuments = new IdentityDocument[] 
                    {
                        new IdentityDocument()
                    }
                },
                ContactInfo = new ContactInfo()
                {

                },
                InvestigationReports = new InvestigationReport[] 
                {
                },
            };

            var svc = new ServiceClient();
            var result =await svc.QueryAsync(application.BasicInfo);
            Console.WriteLine(result.Message);
            result = await svc.ApplyAsync(application);
            Console.WriteLine(result.Message);
            result = await svc.KeepAsync(application);
            Console.WriteLine(result.Message);
            result = await svc.CancelAsync(application);
            Console.WriteLine(result.Message);            

            logSvc.Log(logTarget, new LogItem("END!!"));

            Console.ReadLine();
        }

        private static void SeqOperator_OperationOccurred(object sender, OperatorEventArgs e)
        {
            if (e.HasError)
            {
                logSvc.Log(logTarget, new LogItem($"{nameof(SeqOperator_OperationOccurred)}") { Error = e.EventResult.Error });
            }
        }
    }
}
