namespace LYLStudio.App.Models
{

    public interface IBasicInfoOfNaturalPerson<T> : IBasicInfo<T>, INaturalPersonAdditional
        where T : IIdentityDocument
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
        GenderType Gender { get; set; }
        /// <summary>
        /// 畢業小學
        /// </summary>
        string ElementarySchoolName { get; set; }
    }

    /// <summary>
    /// 性別
    /// </summary>
    public enum GenderType
    {
        Unknown,
        Male,
        Female,
    }
}
