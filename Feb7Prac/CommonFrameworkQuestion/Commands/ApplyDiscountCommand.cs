using Q10_CommandPattern.Models;

namespace Q10_CommandPattern.Commands
{
    public class ApplyDiscountCommand : ICommand
    {
        private readonly Cart _cart;
        private readonly decimal _newDiscount;
        private decimal _oldDiscount;

        public ApplyDiscountCommand(Cart cart, decimal discount)
        {
            _cart = cart;
            _newDiscount = discount;
        }

        public void Execute()
        {
            _oldDiscount = _cart.Discount;
            _cart.ApplyDiscount(_newDiscount);
        }

        public void Undo()
        {
            _cart.ApplyDiscount(_oldDiscount);
        }
    }
}
