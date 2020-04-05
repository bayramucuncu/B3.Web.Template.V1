namespace B3.Infrastructure.Command
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
        void Handle(TCommand command);
    }
}