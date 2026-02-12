using Q10_CommandPattern.Models;

namespace Q10_CommandPattern.Commands
{
    public class RemoveItemCommand : ICommand
    {
        private readonly Cart _cart;
        private readonly string _item;

        public RemoveItemCommand(Cart cart, string item)
        {
            _cart = cart;
            _item = item;
        }

        public void Execute()
        {
            _cart.RemoveItem(_item);
        }

        public void Undo()
        {
            _cart.AddItem(_item);
        }
    }
}
