using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_Application_by_Devon_Bishop.Models
{
    public interface OrderIDRepository
    {
        IEnumerable<Order> Order { get; }

        void SaveOrder(Order order);

        Order DeleteOrder(int ID);
    }
}
