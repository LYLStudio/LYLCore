using System;

using LYLStudio.Service.Data.EntityFramework;

using TestConsole.Models;

namespace TestConsole.Services
{
    public class TestModelDataService : DataServiceBase<DataAccessResult, TestEntities>
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
