namespace Q04_ProducerConsumer.Models
{
    public class Order
    {
        public int OrderId { get; }

        public Order(int orderId)
        {
            OrderId = orderId;
        }
    }
}
