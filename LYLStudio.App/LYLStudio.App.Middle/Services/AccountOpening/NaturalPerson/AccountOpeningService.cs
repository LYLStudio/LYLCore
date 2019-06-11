using System;
using LYLStudio.App.Services.AccountOpening;

namespace LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson
{
    public interface IAccountOpeningService : IAccountOpeningService<AccountOpeningServiceResult, BasicInfoOfNaturalPerson, ApplicationOfNaturalPerson>
    {

    }

    /// <summary>
    /// 開戶服務
    /// </summary>
    public class AccountOpeningService : IAccountOpeningService
    {
        /// <summary>
        /// 提交申請書
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public AccountOpeningServiceResult Apply(ApplicationOfNaturalPerson application)
        {
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Reject;
            application.ApprovedTime = DateTime.Now;

            var result = new AccountOpeningServiceResult();
            result.Data = application;
            if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Reject)
                result.Status = OpeningStatusEnum.Reject;
            else if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Success)
                result.Status = OpeningStatusEnum.Success;
            else
                result.Status = OpeningStatusEnum.Applying;
            result.Message = result.Status.ToString();
            return result;
        }

        /// <summary>
        /// 取消申請書
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public AccountOpeningServiceResult Cancel(ApplicationOfNaturalPerson application)
        {
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Success;
            application.ApprovedTime = DateTime.Now;

            var result = new AccountOpeningServiceResult();
            result.Data = application;
            if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Reject)
                result.Status = OpeningStatusEnum.Reject;
            else if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Success)
                result.Status = OpeningStatusEnum.Success;
            else
                result.Status = OpeningStatusEnum.Applying;
            result.Message = result.Status.ToString();
            return result;
        }

        /// <summary>
        /// 保留申請書
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public AccountOpeningServiceResult Keep(ApplicationOfNaturalPerson application)
        {
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Reject;
            application.ApprovedTime = DateTime.Now;

            var result = new AccountOpeningServiceResult();
            result.Data = application;
            if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Reject)
                result.Status = OpeningStatusEnum.Reject;
            else if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Success)
                result.Status = OpeningStatusEnum.Success;
            else
                result.Status = OpeningStatusEnum.Applying;
            result.Message = result.Status.ToString();
            return result;
        }

        /// <summary>
        /// 查詢申請書
        /// </summary>
        /// <param name="basicInfo"></param>
        /// <returns></returns>
        public AccountOpeningServiceResult Query(BasicInfoOfNaturalPerson basicInfo)
        {
            var application = new ApplicationOfNaturalPerson();
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Success;
            application.ApprovedTime = DateTime.Now;
            application.BasicInfo = basicInfo;

            var result = new AccountOpeningServiceResult();
            result.Data = application;
            if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Reject)
                result.Status = OpeningStatusEnum.Reject;
            else if (application.ApprovedResult == Models.ApprovedResultTypeEnum.Success)
                result.Status = OpeningStatusEnum.Success;
            else
                result.Status = OpeningStatusEnum.Applying;
            result.Message = result.Status.ToString();
            return result;
        }
    }
}