using Asp.Learning.Commanding.Commands;
using Asp.Learning.Commanding.Queries;

namespace Asp.Learning.utilities;

//Mediator design pattern
public class Message
{
    private readonly IServiceProvider provider;

    public Message(IServiceProvider provider)
    {
        this.provider = provider;
    }
    public Guid DispatchCommand(ICommand command)
    {
        Type type = typeof(ICommandHandler<,>);
        Type[] args = { command.GetType(), typeof(Guid) };
        Type genericType = type.MakeGenericType(args);

        dynamic handler = provider.GetService(genericType);
        return handler.HandleAsync((dynamic)command);
    }

    public T DispatchQuery<T>(IQuery<T> query)
    {
        Type typeHandler = typeof(IQueryHandler<,>);
        Type[] args = { query.GetType(), typeof(T) };
        Type genericType = typeHandler.MakeGenericType(args);

        dynamic handler = provider.GetService(genericType);

        T result = handler.Handle((dynamic)query);

        return result;
    }
}