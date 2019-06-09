using System.Collections.Generic;
using LYLStudio.App.Models;

namespace LYLStudio.App.Services.AccountOpening
{
    public interface IAccountOpeningServiceResultBase : IResult
    {
        /// <summary>
        /// 開戶處理狀態
        /// </summary>
        OpeningStatus Status { get; }
        /// <summary>
        /// 前一次步驟
        /// </summary>
        StepType PreviousStep { get; }
        /// <summary>
        /// 下一步驟
        /// </summary>
        StepType NextStep { get; }
        /// <summary>
        /// 步驟完成狀態步驟清單
        /// </summary>
        IDictionary<StepType, bool> CompletedSteps { get; }
    }


    /// <summary>
    /// 開戶服務處理結果
    /// </summary>
    public interface IAccountOpeningServiceResult<T> : IAccountOpeningServiceResultBase, IExtendData<T>
    {
        
    }

    /// <summary>
    /// 開戶申請狀態
    /// </summary>
    public enum OpeningStatus
    {
        /// <summary>
        /// 申請中
        /// </summary>
        Applying,
        /// <summary>
        /// 拒絕
        /// </summary>
        Reject,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
    }

    /// <summary>
    /// 開戶步驟類型
    /// </summary>
    public enum StepType
    {
        /// <summary>
        /// 尚未操作
        /// </summary>
        None,
        /// <summary>
        /// 提交基本資訊
        /// </summary>
        SubmitBasicInfo,
        /// <summary>
        /// 提交聯絡資訊
        /// </summary>
        SubmitContactInfo,
        /// <summary>
        /// 提交問卷調查
        /// </summary>
        SubmitQuestionnaire,
        /// <summary>
        /// 上傳證明文件
        /// </summary>
        UploadDocument,
        /// <summary>
        /// 結束
        /// </summary>
        Done,

        //todo: 其他步驟?
    }

}
