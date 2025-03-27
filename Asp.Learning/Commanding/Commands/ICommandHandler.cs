namespace Asp.Learning.Commanding.Commands;
public interface ICommandHandler<TCommand, TResult>
{
    TResult HandleAsync(TCommand command);
}