using System;
using LYLStudio.Core;
using LYLStudio.Core.Data;
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
       
        public TestModelDataService() : base(false)
        {

        }

        public TestModelDataService(bool isSaveChanges) : base(isSaveChanges)
        {

        }

        public DataAccessResult SomethingProcess()
        {
            var result = new DataAccessResult(false);

            try
            {
                var obj = Fetch<Account>(1, "aaaa");
                obj.Data = "ttttt";
                Update(obj);
                //Create(new Account() { Id = 1, Name = "aaaa", Data = null });
                Create(new AccountAdditional { Id = obj.Id, Name = obj.Name });
                Save();
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }
            finally
            {
                OnDataServiceEventOccurred(this, new DataEventArgs(result));
            }


            return result;
        }
    }
}
