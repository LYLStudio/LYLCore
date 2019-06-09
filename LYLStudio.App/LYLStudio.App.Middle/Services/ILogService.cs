using System;
using System.Collections.Generic;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services
{
    public interface ILogService
    {
        Action<IEnumerable<ILogItem>> Callback { get; set; }

        void Log(string location, params ILogItem[] logItems);
    }
}
