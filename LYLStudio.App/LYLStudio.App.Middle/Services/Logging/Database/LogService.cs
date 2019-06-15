using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services.Logging.Database
{
    public class LogService : LogServiceBase
    {
        public override void Log(string location, params LogItem[] logItems)
        {
            if (Callback == null)
            {
                //本地記錄一份
                Callback += (loc, logs) =>
                {
                    var anything = new Anything
                    {
                        Parameter = logs.ToArray(),
                        Callback = (i) =>
                        {
                           //TODO: 
                        }
                    };
                    _threadService.Enqueue(anything);
                };
            }

            Callback.Invoke(location, logItems);
        }
    }
}