namespace LYLStudio.App.Models
{
    /// <summary>
    /// 自然人基本資訊
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBasicInfoOfNaturalPerson<T> : IBasicInfo<T>, INaturalPersonAdditional where T : IIdentityDocument
    {

    }

    /// <summary>
    /// 自然人其他資訊
    /// </summary>
    public interface INaturalPersonAdditional
    {
        /// <summary>
        /// 性別
        /// </summary>
        GenderTypeEnum Gender { get; set; }

        /// <summary>
        /// 畢業小學
        /// </summary>
        string ElementarySchoolName { get; set; }
    }

    /// <summary>
    /// 性別類型
    /// </summary>
    public enum GenderTypeEnum
    {
        /// <summary>
        /// 不明
        /// </summary>
        Unknown,

        /// <summary>
        /// 男性
        /// </summary>
        Male,

        /// <summary>
        /// 女性
        /// </summary>
        Female,
    }
}
