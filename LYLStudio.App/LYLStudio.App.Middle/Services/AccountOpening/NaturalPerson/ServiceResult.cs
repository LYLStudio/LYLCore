using System;
using System.Collections.Generic;
using LYLStudio.App.Services.AccountOpening;

namespace LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson
{
    internal interface IServiceResult : IServiceResultBase<ApplicationOfNaturalPerson>
    {

    }

    /// <summary>
    /// 開戶服務結果
    /// </summary>
    public class ServiceResult : IServiceResult
    {
        /// <summary>
        /// 執行結果編號
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 開戶申請狀態
        /// </summary>
        public OpeningStatusEnum Status { get; set; }
        /// <summary>
        /// 前次步驟
        /// </summary>
        public StepTypeEnum PreviousStep { get; set; }
        /// <summary>
        /// 下次步驟
        /// </summary>
        public StepTypeEnum NextStep { get; set; }
        /// <summary>
        /// 步驟狀態清單
        /// </summary>
        public IDictionary<StepTypeEnum, bool> CompletedSteps { get; }
        /// <summary>
        /// 附加資料
        /// </summary>
        public ApplicationOfNaturalPerson Data { get; set; }

        public ServiceResult()
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