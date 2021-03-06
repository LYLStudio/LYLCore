﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using LStudio.Core;
using LStudio.Core.Data.EF;
using LStudio.Core.Logging;
using LStudio.Core.Threading;
using LYLStudio.App.Services;
using LYLStudio.App.Services.Communication;
using LYLStudio.App.TestConsole.AccountOpening.NaturalPerson;
using LYLStudio.App.TestConsole.Models;
using LYLStudio.App.TestConsole.Services;

namespace LYLStudio.App.TestConsole
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Server server = new Server(10, 1024);
    //        //server.Init();
    //        //server.Start(new IPEndPoint(IPAddress.Any, 11111));

    //        //IExecutableExceptionHandle executable = new Test();

    //        //executable.ExecuteWithExceptionHandled(
    //        //    new TestAnything()
    //        //{
    //        //    Parameter = "xxx",
    //        //    Callback = 
    //        //    (o)=> 
    //        //    {
    //        //        var x = o.Substring(0, 99);
    //        //        Console.WriteLine(x);
    //        //    }
    //        //});

    //        //var length = executable.ExecuteWithExceptionHandled(
    //        //    new TestAnything1()
    //        //    {
    //        //        Parameter = "xxx",
    //        //        Callback = (o) => 
    //        //        {
    //        //            return o.Length;
    //        //        }
    //        //    });
    //    }
    //}

    internal class Program
    {
        private static readonly string logTarget = Path.Combine(Properties.Settings.Default.LOG_PATH, $"{DateTime.Today.FormatD()}.log");
        private static readonly LogginService logSvc = new LogginService(new SequenceOperator<ILogItem[]>(nameof(LogginService)));

        private static void Main(string[] args)
        {
            if (!(args is null))
            {
                //todo something
                Console.WriteLine("");
            }

            logSvc.Callback = (target, log) =>
            {
                foreach (var item in log)
                {
                    Console.WriteLine($"{item.Time.ToLogTime()},{item.Message}");
                }
            };
            logSvc.Log(logTarget, new LogItem("START!!"));
            var dataManager = new DataServiceManager();
            dataManager.DbLog = (log) => { Debug.WriteLine(log); };
            dataManager.AddDbContext(new DbContextFactory("TestEntities", "TestEntities"));
            var db = dataManager.GetContext("TestEntities");

            var seqOperator = new SequenceOperator<string>(nameof(dataManager));
            seqOperator.OperationOccurred += SeqOperator_OperationOccurred;
            seqOperator.Enqueue(new Anything<string>()
            {
                Callback = o =>
                {
                    var dd = DateTime.Now.ToLogTime();
                    var r1 = db.Create(new Account() { Id = 2, Data = dd, Name = dd });
                    var r2 = db.Save();

                    logSvc.Log(logTarget, new LogItem($"{r1.Id}|{r1.IsSuccess}|{r1.Message}") { Error = r1.ResultException });
                }
            });

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
                InvestigationReports = Array.Empty<InvestigationReport>(),
            };

            //var svc = new ServiceClient();

            //var result = await svc.QueryAsync(application.BasicInfo);
            //Console.WriteLine($"{result.Id}:{result.Status}|||{result.Data.Id}: {result.Data}");
            //result = await svc.ApplyAsync(application);
            //Console.WriteLine($"{result.Message}");
            //result = await svc.KeepAsync(application);
            //Console.WriteLine(result.Message);
            //result = await svc.CancelAsync(application);
            //Console.WriteLine(result.Message);



            try
            {
                Console.ReadLine();
            }
            finally
            {
                logSvc.Log(logTarget, new LogItem("END!!"));
            }

            Console.ReadLine();
        }

        private static void SeqOperator_OperationOccurred(object sender, OperatorEventArgs e)
        {
            if (e.HasError)
            {
                logSvc.Log(logTarget, new LogItem($"{nameof(SeqOperator_OperationOccurred)}") { Error = e.EventResult.ResultException });
            }
        }
    }
}
