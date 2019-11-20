namespace LStudio.Core.Data.EF
{
    using System;
    using System.Data.Entity;

    public class DbContextFactory : IDbContextFactory, IDisposable
    {
        private readonly DbContext _context;

        public string Id { get; private set; }

        public DbContextFactory(string connectionString)
        {
            _context = new DbContext(connectionString);
        }

        public DbContextFactory(string connectionString, string id) : this(connectionString)
        {
            Id = id;
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
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
