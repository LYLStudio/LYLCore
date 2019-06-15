using System;
using System.IO;
using System.Linq;

namespace LYLStudio.App.Middle.Services.Logging.TextFile
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
                            using (var sw = new StreamWriter(loc, true))
                            {
                                var str = string.Join(Environment.NewLine, logItems.Select(x => $"{x.Time}|{x.Id}|{x.Category}|{x.Priority}|{x.Message}"));
                                sw.WriteLine(str);
                                sw.Close();
                            }
                        }
                    };
                    _threadService.Enqueue(anything);
                };
            }

            Callback.Invoke(location, logItems);
        }
    }
}