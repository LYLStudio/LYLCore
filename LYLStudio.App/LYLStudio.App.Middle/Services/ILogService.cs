using System;
using System.Collections.Generic;
using LYLStudio.App.Middle.Models;

namespace LYLStudio.App.Middle.Services
{
    public interface ILogService
    {
        Action<IEnumerable<ILogItem>> Callback { get; set; }

        void Log(string location, params ILogItem[] logItems);
    }

    public abstract class LogServiceBase : ILogService
    {
        public abstract Action<IEnumerable<ILogItem>> Callback { get; set; }

        public virtual void Log(string location, params ILogItem[] logItems)
        {

        }
    }
}
