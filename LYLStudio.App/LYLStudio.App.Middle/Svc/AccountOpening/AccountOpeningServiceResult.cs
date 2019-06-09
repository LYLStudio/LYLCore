using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LYLStudio.App.Models;
using LYLStudio.App.Services.AccountOpening;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    internal interface IAccountOpeningServiceResult : IAccountOpeningServiceResult<ApplicationOfNaturalPerson>
    {

    }

    public class AccountOpeningServiceResult : IAccountOpeningServiceResult
    {
        public OpeningStatus Status { get; }
        public StepType PreviousStep { get; }
        public StepType NextStep { get; }
        public IDictionary<StepType, bool> CompletedSteps { get; }
        public Guid Id { get; }
        public string Message { get; set; }
        public ApplicationOfNaturalPerson Data { get; }
    }
}