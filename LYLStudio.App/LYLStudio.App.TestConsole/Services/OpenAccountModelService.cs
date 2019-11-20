using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYLStudio.App.TestConsole.Models;
using LYLStudio.Core.Data.EF;

namespace LYLStudio.App.TestConsole.Services
{
    public class OpenAccountModelService : DataServiceBase<OpenAccountEntities>
    {
        private OpenAccountEntities _context = null;
        public override OpenAccountEntities Context
        {
            get
            {
                if (_context == null)
                    _context = new OpenAccountEntities();
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
