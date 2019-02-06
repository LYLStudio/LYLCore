using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYLStudio.Service.Data.EntityFramework;
using TestConsole.Models;

namespace TestConsole.Services
{
    public class TestDataService : DataServiceBase<DataAccessResult, TestEntities>
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
