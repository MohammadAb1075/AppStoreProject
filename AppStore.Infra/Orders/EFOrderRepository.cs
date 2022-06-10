using AppStore.Domain.Orders;
using AppStore.Infra.Data.Sql.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Infra.Data.Sql.Orders
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public EFOrderRepository(StoreDbContext storeDbContext) => _storeDbContext = storeDbContext;

        public void Save(Order order)
        {
            _storeDbContext.AttachRange(order.OrderDetails.Select(d => d.Product));
            _storeDbContext.Orders.Add(order);
            _storeDbContext.SaveChanges();
        }

    }
}
