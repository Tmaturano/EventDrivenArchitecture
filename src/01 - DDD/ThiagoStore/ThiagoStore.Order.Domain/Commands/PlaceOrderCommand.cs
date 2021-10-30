using ThiagoStore.SharedContext.Commands;

namespace ThiagoStore.Order.Domain.Commands
{
    //Fail Fast Validation will be here
    public class PlaceOrderCommand : ICommand
    {
        public string Email { get; set; }
    }
}
