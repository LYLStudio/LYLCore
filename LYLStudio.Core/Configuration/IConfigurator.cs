using System.Collections.Generic;

namespace LYLStudio.Core.Configuration
{
    public interface IConfigurator<T>
        where T : IConfigItem
    {        
        IEnumerable<T> LoadConfigs(params string[] paths);
        void SaveConfigs(IEnumerable<T> configItems);
    }
}
