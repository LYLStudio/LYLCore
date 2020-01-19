using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using LStudio.Core;
using LStudio.Core.Data.EF;
using LStudio.Core.Threading;
using LStudio.TestLibsApp.Models;

namespace LStudio.TestLibsApp
{    
    class Program
    {
        private static void Main()
        {
            var encryptionPerformance = new EncryptionTest.TestRun();
            encryptionPerformance.RunTestCase1();

            Console.ReadLine();

            encryptionPerformance.Dispose();
            
            //if (!(args is null) && args.Length > 0) { }

            //var data = DateTime.Now;
            //var dataString = data.ToLogTime();

            //DataServiceManager svc = new DataServiceManager
            //{
            //    DbLog = log => { Debug.WriteLine(log); }
            //};

            //try
            //{
            //    var test = "TestEntities";
            //    svc.AddDbContext(new DbContextFactory(test, test));
            //    var db = svc.GetContext(test);
            //    svc.Commit(() =>
            //    {
            //        var createResult = db.Create(new RecordA() { Id = data.ToLogTime(), Name = data.ToLogTime(), CreateTime = data });

            //    },db.Context);

            //    var q = db.Fetch<RecordA>(o => o.Id.Equals(dataString, StringComparison.InvariantCulture));
            //    q.ForEachProperty(nv =>
            //    {
            //        Debug.Write($"{nv.Name}: {nv.Value}");
            //    });

            //    var deleteResult = (DataAccessResult<RecordA>)db.Delete(q);
            //    if (!deleteResult.IsSaveChanged)
            //    {
            //        db.Save();
            //        //svc.Commit(null, db.Context);
            //    }

            //    var isExist = db.IsExist<RecordA>(dataString);
            //    Debug.WriteLine($"{nameof(isExist)}: {isExist}");
            //    //svc.Commit(() => {
            //    //    db.Save();
            //    //});
            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    svc.Dispose();
            //}

            //IOperator<string> op1 = new SequenceOperator<string>("ttt1", sleep: 1000);
            //IOperator<string> op2 = new SequenceOperator<string>("ttt2", sleep: 100);

            //try
            //{
            //    op1.OperationOccurred += Op_OperationOccurred;

            //    for (int i = 0; i < 100; i++)
            //    {
            //        op1.Enqueue(new Anything<string>(i.ToString(CultureInfo.InvariantCulture))
            //        {
            //            Callback = o =>
            //            {
            //                System.Diagnostics.Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:{o}");
            //            }
            //        });
            //    }

            //    op2.OperationOccurred += Op_OperationOccurred;

            //    for (int i = 0; i < 100; i++)
            //    {
            //        op2.Enqueue(new Anything<string>(i.ToString(CultureInfo.InvariantCulture))
            //        {
            //            Callback = o =>
            //            {
            //                System.Diagnostics.Debug.WriteLine($"{Thread.CurrentThread.Name}:{o}");
            //            }
            //        });
            //    }

            //    Console.ReadLine();
            //}
            //finally
            //{
            //    op1?.Dispose();
            //    op2?.Dispose();
            //}


            //var result = new SampleResult();
            //var result2 = new SampleResult(parentId: result.Id);
            //var tmpResult = result2.InnerResults as List<IResult>;
            //tmpResult.Add(new SampleResult(parentId: result2.Id));
            //tmpResult.Add(new SampleResult(parentId: result.Id));
            //tmpResult.Add(result2);
            //tmpResult.Add(new SampleResult(parentId: result.Id));
            //tmpResult.Add(new SampleResult(parentId: result.Id));
            //result.ForEachProperty(ProperitesDebugInfo);
        }

       

        private static void Svc_DataServiceEventOccurred(object sender, Core.Data.EF.DataEventArgs e)
        {
            List<NameValue> list = new List<NameValue>();
            e.ForEachProperty(nv =>
            {
                list.Add(nv);
            });

            var result = string.Join(", ", list.Select(x => $"{x.Name}:{x.Value}").ToArray());
            Debug.WriteLine(result);
        }


        private static void Op_OperationOccurred(object sender, OperatorEventArgs e)
        {

        }

        private static void ProperitesDebugInfo(NameValue nameValue)
        {

            if (nameValue.Value is List<IResult> list)
            {
                System.Diagnostics.Debug.WriteLine($"{nameValue.Name}({list.Count}):");
                list.ForEach((o) =>
                {
                    o.ForEachProperty(ProperitesDebugInfo);
                });
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"{nameValue.Name}: {nameValue.Value}");
            }
        }
    }
}
