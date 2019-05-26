using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
                var message = $"{nameof(e.EventTime)}:{e.EventTime}|{nameof(e.EventResult.Payload)}:{e.EventResult.Payload}|{nameof(e.HasError)}:{e.HasError}";

                if (e.HasError)
                {
                    var errMessage = e.EventResult.Error.GetaAllMessages();
                    var errStack = e.EventResult.Error.StackTrace;
                    message += $"|{errMessage}|{errStack}";
                }
                Debug.WriteLine(message);
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

            ListFetchResult(nameof(f1), f1);

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

        private void ListFetchResult<T>(string fnName, IEnumerable<T> srcList)
        {
            Debug.WriteLine($"List Data: {fnName} start");
            var list = new List<string>();

            foreach (var item in srcList)
            {
                var properies = item.GetType().GetProperties();
                var pList = new List<string>();
                foreach (var p in properies)
                {
                    pList.Add(p.GetValue(item)?.ToString());
                }

                Debug.WriteLine(string.Join("|",pList));
            }

            Debug.WriteLine($"List Data: {fnName} end");
        }

        public EventHandler<Account> AccountChanged;
        private void OnAccountChanged(Account account)
        {
            AccountChanged?.Invoke(this, account);
        }
    }

}
