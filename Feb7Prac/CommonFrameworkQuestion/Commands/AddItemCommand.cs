using Q10_CommandPattern.Models;

namespace Q10_CommandPattern.Commands
{
    public class AddItemCommand : ICommand
    {
        private readonly Cart _cart;
        private readonly string _item;

        public AddItemCommand(Cart cart, string item)
        {
            _cart = cart;
            _item = item;
        }

        public void Execute()
        {
            _cart.AddItem(_item);
        }

        public void Undo()
        {
            _cart.RemoveItem(_item);
        }
    }
}
