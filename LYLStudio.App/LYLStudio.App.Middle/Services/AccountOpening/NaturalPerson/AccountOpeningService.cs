using System;
using LYLStudio.App.Services.AccountOpening;

namespace LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson
{
    public abstract class AccountOpeningServiceBase : IServiceBase<ServiceResult, BasicInfoOfNaturalPerson, ApplicationOfNaturalPerson>, IMiddleService
    {
        public abstract ServiceResult Apply(ApplicationOfNaturalPerson application);
        public abstract ServiceResult Cancel(ApplicationOfNaturalPerson application);
        public abstract ServiceResult Keep(ApplicationOfNaturalPerson application);
        public abstract ServiceResult Query(BasicInfoOfNaturalPerson basicInfo);
        public abstract ServiceChecking CheckService(CheckTypeEnum checkType = CheckTypeEnum.None);
    }

    public interface IAccountOpeningService : IServiceBase<ServiceResult, BasicInfoOfNaturalPerson, ApplicationOfNaturalPerson>, IMiddleService
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
        public ServiceResult Apply(ApplicationOfNaturalPerson application)
        {
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Reject;
            application.ApprovedTime = DateTime.Now;

            var result = new ServiceResult();
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
        public ServiceResult Cancel(ApplicationOfNaturalPerson application)
        {
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Success;
            application.ApprovedTime = DateTime.Now;

            var result = new ServiceResult();
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

        public ServiceChecking CheckService(CheckTypeEnum checkType = CheckTypeEnum.None)
        {
            var result = new ServiceChecking
            {
                Status = App.Services.ServiceStatusEnum.Unknown,
                Message = checkType.ToString(),
                ReplyTime = DateTime.Now
            };

            return result;
        }

        /// <summary>
        /// 保留申請書
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public ServiceResult Keep(ApplicationOfNaturalPerson application)
        {
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Reject;
            application.ApprovedTime = DateTime.Now;

            var result = new ServiceResult();
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
        public ServiceResult Query(BasicInfoOfNaturalPerson basicInfo)
        {
            var application = new ApplicationOfNaturalPerson();
            application.ApprovedResult = Models.ApprovedResultTypeEnum.Success;
            application.ApprovedTime = DateTime.Now;
            application.BasicInfo = basicInfo;

            var result = new ServiceResult();
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