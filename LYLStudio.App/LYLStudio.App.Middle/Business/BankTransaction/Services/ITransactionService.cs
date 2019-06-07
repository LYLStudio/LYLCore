using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LYLStudio.App.Middle.Models;

namespace LYLStudio.App.Middle.Business.BankTransaction
{
    public interface ITransactionService
    {
        ITransactionServiceResult<string> Test(string message); 
    }

    public interface ITransactionServiceResult : IResult
    {

    }

    public interface ITransactionServiceResult<T> : ITransactionServiceResult
    {
        T Data { get; }
    }

    public interface IRequest
    {

    }

    public interface IResponse
    {

    }

    public interface ITransactionRequest : IRequest
    {

    }

    public interface ITransactionResponse : IResponse
    {

    }

    public enum TransactionType
    {        
        NTD,
        FUND,
        FE,
        GOLD
    }
}