using System;
using System.Linq;
using LYLStudio.App.TestConsole.Models;
using LYLStudio.Core;
using LYLStudio.Core.Data;
using LYLStudio.Core.Data.EF;

namespace LYLStudio.App.TestConsole.Services
{
    public class TestModelService : DataServiceBase<TestEntities>        
    {
        private TestEntities _context = null;
        public override TestEntities Context
        {
            get
            {
                if (_context == null)
                    _context = new TestEntities();
                return _context;
            }
        }
        public override Action<string> Log { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context?.Dispose();
        }
    }
}
