using System;
using LYLStudio.Core;
using LYLStudio.Service.Data.EntityFramework;

using TestConsole.Models;

namespace TestConsole.Services
{
    public interface ITestModelDataService<TResult, TContext> : IDataService<TResult, TContext>
        where TResult : IResult, new()
    {
        TResult SomethingProcess();
    }

    public class TestModelDataService : DataServiceBase<DataAccessResult, TestEntities>, ITestModelDataService<DataAccessResult, TestEntities>
    {
        private TestEntities _context;
        public override TestEntities Context => _context ?? (_context = new TestEntities());

        public override Action<string> Log
        {
            get => Context.Database.Log;
            set => Context.Database.Log = value;
        }

        public DataAccessResult SomethingProcess()
        {
            var result = new DataAccessResult(false);

            try
            {
                var obj = Fetch<Account>(1);
                obj.Data = "ttttt";
                var changes = Save();
                result.IsSuccess = changes == 1;

            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }


            return result;
        }
    }
}
