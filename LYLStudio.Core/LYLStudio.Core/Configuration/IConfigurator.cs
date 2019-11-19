namespace LYLStudio.Core.Configuration
{
    using System.Collections.Generic;

    public interface IConfigurator<T>
        where T : IConfigItem
    {
        IEnumerable<T> LoadConfigs(params string[] paths);
        void SaveConfigs(IEnumerable<T> configItems);
    }
}
