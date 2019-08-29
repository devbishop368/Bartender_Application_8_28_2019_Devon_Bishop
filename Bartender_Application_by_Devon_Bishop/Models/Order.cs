using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_Application_by_Devon_Bishop.Models
{
    public class Order
    {
        private OrderContext context;

        public int ID { get; set; }
        public string Customer { get; set; }
        public string Drink { get; set; }


        public string Status { get; set; }


    }
}
