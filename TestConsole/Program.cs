using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LYLStudio.Core;
using LYLStudio.Core.Data;
using LYLStudio.Core.Logging;
using LYLStudio.Core.Threading;
using LYLStudio.Service.Data.EntityFramework;

using TestConsole.Models;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager { Log = (log) => { Console.WriteLine(log.Replace("\r\n", "")); } };
            dataManager.DataServiceEventOccurred += (o, e) => { Console.WriteLine($"{e.EventTime}|{e.HasError}|{e.EventResult.Error?.StackTrace}"); };

            List<Account> accounts4Create = new List<Account>
            {
                new Account() { Id = 1, Name = "aaaa" },
                new Account() { Id = 2, Name = "bbbb" },
                new Account() { Id = 3, Name = "cccc" }
            };

            dataManager.Create(accounts4Create.ToArray());

            //List<Account> accounts4Delete = new List<Account>
            //{
            //    new Account() { Id = 1, Name = "aaaa", Data = null },
            //};

            //IEnumerable<Account> accounts4Delete = dataManager.Context.Accounts;
            
            dataManager.DeleteByKey<Account>(1, "aaaa");

            //var account = dataManager.Context.Accounts.First();
            //dataManager.Delete(account);

            //Console.ReadLine();
        }
    }

    public class DataManager : DataServiceBase<DataAccessResult, TestEntities>
    {
        private TestEntities _context;
        public override TestEntities Context => _context ?? (_context = new TestEntities());

        public override Action<string> Log
        {
            get => Context.Database.Log;
            set => Context.Database.Log = value;
        }
    }

}
