using Store.Data.Entites.OrederEntites;
using Store.Repository.Spcesifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderServices.OrderDtos
{
    public class OrderWithItemSpecification : BaseSpecification<Order>
    {
        public OrderWithItemSpecification(string BuyerEmail) 
            : base(order => order.BuyerEmail == BuyerEmail)
        {
            AddIncludes(order => order.DeliveryMethod);
            AddIncludes(order => order.OrderItems);
            orderAsc(order => order.BuyerEmail == BuyerEmail);




        }

        public OrderWithItemSpecification(Guid id)
            : base(order => order.Id == id)
        {
            AddIncludes(order => order.DeliveryMethod);
            AddIncludes(order => order.OrderItems);
            




        }
    }
}
