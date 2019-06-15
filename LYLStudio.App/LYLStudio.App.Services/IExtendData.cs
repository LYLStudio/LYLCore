namespace LYLStudio.App.Services
{
    /// <summary>
    /// 附加資料
    /// </summary>
    /// <typeparam name="T">附加資料的資料型別</typeparam>
    public interface IExtendData<T>
    {
        /// <summary>
        /// 資料
        /// </summary>
        T Data { get; }
    }
}
