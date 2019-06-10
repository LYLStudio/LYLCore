using System;
using System.Collections.Generic;
using LYLStudio.App.Services.AccountOpening;

namespace LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson
{
    /// <summary>
    /// 開戶服務結果介面
    /// </summary>
    internal interface IAccountOpeningServiceResult : IAccountOpeningServiceResult<ApplicationOfNaturalPerson>
    {

    }

    /// <summary>
    /// 開戶服務結果
    /// </summary>
    public class AccountOpeningServiceResult : IAccountOpeningServiceResult
    {
        /// <summary>
        /// <see cref="OpeningStatusEnum"/>
        /// </summary>
        public OpeningStatusEnum Status { get; set; }
        /// <summary>
        /// 前一次步驟/>
        /// </summary>
        public StepTypeEnum PreviousStep { get; set; }
        /// <summary>
        /// 下一步驟
        /// </summary>
        public StepTypeEnum NextStep { get; set; }
        /// <summary>
        /// 步驟完成狀態清單
        /// </summary>
        public IDictionary<StepTypeEnum, bool> CompletedSteps { get; }
        /// <summary>
        /// 執行結果編號
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 附加資料
        /// </summary>
        public ApplicationOfNaturalPerson Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AccountOpeningServiceResult()
        {
            Id = Guid.NewGuid();
            CompletedSteps = new Dictionary<StepTypeEnum, bool>()
            {
                { StepTypeEnum.SubmitBasicInfo, false },
                { StepTypeEnum.SubmitContactInfo, false },
                { StepTypeEnum.SubmitQuestionnaire, false },
                { StepTypeEnum.UploadDocument, false }
            };
        }
    }
}