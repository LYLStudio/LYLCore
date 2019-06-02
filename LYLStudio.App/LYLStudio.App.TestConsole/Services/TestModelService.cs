using System;
using System.Linq;
using LYLStudio.App.TestConsole.Models;
using LYLStudio.Core.Data;
using LYLStudio.Core.Data.EF;

namespace LYLStudio.App.TestConsole.Services
{
    public class TestModelService : DataServiceBase<DataAccessResult, TestEntities>
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

        public TestModelService(bool autoSaveChanges) : base(autoSaveChanges)
        {

        }

        public override DataAccessResult Create<T>(params T[] entities)
        {
            var result = base.Create(entities);

            try
            {
                if (!IsCUDBaseMethodsSaveChangesByDefault)
                {
                    if (result.Error == null)
                        result.IsSuccess = entities.Count() == Save();
                }                
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

        protected override void OnDataServiceEventOccurred(object sender, DataEventArgs args)
        {
            base.OnDataServiceEventOccurred(sender, args);
        }

    }
}
