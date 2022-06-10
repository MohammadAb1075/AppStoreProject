namespace AppStore.Domain.Orders
{
    public interface IOrderRepository
    {
        public void Save(Order order);  
    }
}
