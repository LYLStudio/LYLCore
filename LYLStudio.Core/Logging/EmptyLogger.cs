namespace LYLStudio.Core.Logging
{
    public abstract class EmptyLogger : ILogger
    {
        public virtual void Log(ILogItem logItem)
        {
            
        }
    }
}
