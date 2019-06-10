using System;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// 基本資料核心資訊
    /// </summary>
    public interface IBasicInfoBase
    {
        /// <summary>
        /// 識別編號(身分證/統編/其他)
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 法定日期(出生/公司註冊日期)
        /// </summary>
        DateTime LegalDate { get; set; }
        /// <summary>
        /// <see cref="IdentityTypeEnum"/>
        /// </summary>
        IdentityTypeEnum IdentityType { get; set; }
    }

    /// <summary>
    /// 基本資訊
    /// </summary>
    public interface IBasicInfo<T> : IBasicInfoBase, IListOfIdentityDocument<T>
        where T : IIdentityDocument
    {

    }

    /// <summary>
    /// 身分別
    /// </summary>
    public enum IdentityTypeEnum
    {
        /// <summary>
        /// 不明
        /// </summary>
        Unknown,
        /// <summary>
        /// 自然人
        /// </summary>
        NaturalPerson,
        /// <summary>
        /// 法人
        /// </summary>
        JuridicalPerson,
        //todo 其他類型
    }
}
