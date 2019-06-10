namespace LYLStudio.App.Models
{
    /// <summary>
    /// 聯絡資訊
    /// </summary>
    /// <typeparam name="T1"><see cref="IListOfAddressInfo{T}"/></typeparam>
    /// <typeparam name="T2"><see cref="IListOfPhoneInfo{T}"/></typeparam>
    /// <typeparam name="T3"><see cref="IListOfEmailInfo{T}"/></typeparam>
    public interface IContactInfo<T1, T2, T3>
        : IListOfAddressInfo<T1>, IListOfPhoneInfo<T2>, IListOfEmailInfo<T3>
        where T1 : IAddressInfo
        where T2 : IPhoneInfo
        where T3 : IEmailInfo
    {
    }
}
