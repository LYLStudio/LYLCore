namespace LYLStudio.App.Models
{
    /// <summary>
    /// 聯絡資訊
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public interface IContactInfo<T1, T2, T3> : IListOfAddressInfo<T1>, IListOfPhoneInfo<T2>, IListOfEmailInfo<T3>
        where T1 : IAddressInfo
        where T2 : IPhoneInfo
        where T3 : IEmailInfo
    {
    }
}
