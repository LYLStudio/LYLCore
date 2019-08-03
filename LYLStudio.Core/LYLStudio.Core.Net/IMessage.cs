using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.Core.Net
{
    public interface ISend
    {
        void Send(string message);
        void Send(params byte[] message);
    }    

    public interface IMessage<THeader,TPayload>        
    {
        THeader Header { get; set; }
        TPayload Payload { get; set; }        
    }

    public interface IMessageCenter<TResult, TRegisterSetting, TSubscribeSetting, TToken>        
    {
        Task<TResult> Register(TRegisterSetting registerSetting);

        Task<TResult> Subscribe(params TSubscribeSetting[] subscribeSettings);

        Task<TResult> GetPublisher(TToken token);
    }

    public interface IRegisterSetting
    {
        string RegisterId { get; set; }
        string Name { get; set; }

        
    }

    public interface ISubscribeSetting
    {

    }

    public interface IToken : IRegisterSetting
    {
        string ChannelId { get; set; }
        string Token { get; set; }
        
    }

    public interface IRegisterResult : IResult
    {

    }
}
