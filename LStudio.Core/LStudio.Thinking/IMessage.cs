public interface IMessage<THead, TPayload>: IContext
{
    THead Head { get; set; }
    TPayload Payload { get; set; }
}









public interface IContext : IContext<string>
{

}

public interface IContext<T>
{
    T Id { get; set; }
    T ParentId { get; set; }
}