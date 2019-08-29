using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_Application_by_Devon_Bishop.Models
{
    public class OrderRepository : OrderIDRepository
    {
        private AppDbContext context;
        public OrderRepository(AppDbContext cntx)
        {
            context = cntx;
        }
        public IEnumerable<Order> Order => context.Order;

        //add or edit order
        public void SaveOrder(Order order)
        {
            if (order.ID != 0)
            {
                Order orderEntry = context.Order
                    .FirstOrDefault(o => o.ID == order.ID);

                if (orderEntry == null)
                {
                    context.Order.Add(order);
                }
                else if (orderEntry != null)
                {

                    orderEntry.Customer = order.Customer;
                    orderEntry.Status = order.Status;

                }

            }

            context.SaveChanges();

        }
        //Cancel an order
        public Order DeleteOrder(int ID)
        {
            Order orderEntry = context.Order
                .FirstOrDefault(o => o.ID == ID);

            if (orderEntry != null)
            {
                context.Order.Remove(orderEntry);
                context.SaveChanges();
            }
            return orderEntry;

        }

    }
}

