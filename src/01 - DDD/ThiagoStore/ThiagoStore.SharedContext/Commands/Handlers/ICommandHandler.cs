using System.Threading.Tasks;

namespace ThiagoStore.SharedContext.Commands.Handlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        //Entry Point
        Task HandleAsync(T command);
    }
}
