using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LYLStudio.Core;
using TestConsole.Models;

namespace TestConsole.Services
{
    public class TestModelDataServiceTest
    {
        TestModelDataService _dataService = null;

        public TestModelDataServiceTest()
        {
            _dataService = new TestModelDataService { Log = (log) => { Console.WriteLine(log.Replace("\r\n", "")); } };
            _dataService.DataServiceEventOccurred += (o, e) =>
            {
                Console.WriteLine($"{nameof(e.EventTime)}:{e.EventTime}|{nameof(e.EventResult.Payload)}:{e.EventResult.Payload}|{nameof(e.HasError)}:{e.HasError}|{e.EventResult.Error?.StackTrace}");
            };
        }

        public void Create()
        {
            List<Account> accounts4Create = new List<Account>
            {
                new Account() { Id = 1, Name = "aaaa" },
                new Account() { Id = 2, Name = "bbbb" },
                new Account() { Id = 3, Name = "cccc" }
            };
            _dataService.Create(accounts4Create.ToArray());
        }

        public void Fetch()
        {
            var f1 = (IQueryable<Account>)_dataService.FetchAll<Account>();
            var f2 = (IQueryable<Account>)_dataService.FetchList<Account>(o => o.Id <= 2);
            var f3 = _dataService.Fetch<Account>(3, "cccc");
            var f4 = _dataService.Fetch<Account>(o => o.Id == 3);

            var f1List = f1.ToList();
            var f2List = f2.ToList();
        }

        public void Update()
        {
            var f3 = _dataService.Fetch<Account>(3, "cccc");
            f3.Data = nameof(f3);
            var u1 = _dataService.Update(f3);
        }

        public void Delete()
        {
            _dataService.DeleteByKey<Account>(1, "aaaa");
            var obj2 = _dataService.Fetch<Account>(2, "bbbb");
            _dataService.Delete(obj2);
        }

        public void IsExist()
        {
            var e1 = _dataService.IsExist<Account>(3, "cccc");
            if (e1)
                _dataService.Delete<Account>(o => o.Id > 0);
        }

        public void SomethingProcess()
        {

            var result = _dataService.SomethingProcess();

            if (result.IsSuccess)
            {
                if (result.Payload is Account account)
                {
                    OnAccountChanged(account);
                }
            }
        }

        public EventHandler<Account> AccountChanged;
        private void OnAccountChanged(Account account)
        {
            AccountChanged?.Invoke(this, account);
        }
    }

}
