namespace Asp.Learning.Commanding.Commands;
public interface ICommandHandler<TCommand, TResult>
{
    Task<TResult> HandleAsync(TCommand command);
}