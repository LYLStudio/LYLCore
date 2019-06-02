using System;
using System.Data.Entity;

namespace LYLStudio.Core.Data.EF
{
    public class DbContextFactory : IDbContextFactory, IDisposable
    {
        private readonly DbContext _context;

        public DbContextFactory(string connectionString)
        {
            _context = new DbContext(connectionString);
        }

        public DbContext GetContext()
        {
            return _context;
        }

        #region IDisposable Support
        private bool _disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
