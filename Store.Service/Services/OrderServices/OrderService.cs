using AutoMapper;
using Store.Data.Entites;
using Store.Data.Entites.OrederEntites;
using Store.Repository.Baskets.Models;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Service.Services.BasketServices;
using Store.Service.Services.OrderServices.OrderDtos;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IBasketService basketService , IUnitOfWork unitOfWork , IMapper mapper ) 
        {
            _basketService = basketService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDetailsDto> CreateOrderAsync(OrderDto input)
        {
            var customerBasket = await _basketService.GetBasketAsync(input.BasketId);

            var orderItems = new List<OrderItemDto>();

            #region Fill OrderItem
            foreach (var basketItem in customerBasket.BasketItems)
            {
                var productItem = await _unitOfWork.Repository<Product, int>().GetById(basketItem.ProductId);

                if (productItem == null)
                    throw new Exception($"Product Id = {basketItem.ProductId} Not Exist");

                var itemOrdered = new ProductItem
                {
                    ProductId = basketItem.ProductId,
                    ProductName = productItem.Name,
                    PictureURL = productItem.PictureUrl
                };

                var orderItem = new OrderItem
                {
                    Quantity = basketItem.Quantity,
                    Price = productItem.Price,
                    ProductItem = itemOrdered

                };

                var mappedOrderItem = _mapper.Map<OrderItemDto>(orderItem);
                orderItems.Add(mappedOrderItem);



            }
            #endregion

            var deliveryMethod =await _unitOfWork.Repository<DeliveryMethod, int>().GetById(input.DeliverMethodsId);
            if (deliveryMethod == null)
                throw new Exception($"delivery Id = {input.DeliverMethodsId} Not Exist");

            var subTotal = orderItems.Sum(x=>x.Quantity * x.Price);

            var mappedShippingAddress = _mapper.Map<ShippingAddress>(input.ShippingAddress);
            var mappedorderItems = _mapper.Map<List<OrderItem>>(orderItems);

            var order = new Order
            {
                ShippingAddress =mappedShippingAddress,
                DeliveryMethodId =deliveryMethod.Id,
                BuyerEmail = input.BuyerEmail,
                OrderItems = mappedorderItems,
                BasketId = input.BasketId,
                SubTotal = subTotal

            };

            await _unitOfWork.Repository<Order, Guid>().Add(order);
            await _unitOfWork.Complite();

            var mappedOrder = _mapper.Map<OrderDetailsDto>(order);

            return(mappedOrder);





        }
        public async Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodAsync()
        => await _unitOfWork.Repository<DeliveryMethod, int>().GetAllAsync();

        public async Task<IReadOnlyList<OrderDetailsDto>> GetAllOrderFromUserAsync(string buyerEmail)
        {
            var spec = new OrderWithItemSpecification(buyerEmail);


            var order = await _unitOfWork.Repository<Order, Guid>().GetAllWithSpcificationAsync(spec);
            
            if (!order.Any())
                throw new Exception("You Do Not Have Any Order Yet");

            var mapped = _mapper.Map<List<OrderDetailsDto>>(order);

            return mapped;



        }

        public async Task<OrderDetailsDto> GetOrderByIdAsync(Guid id)
        {
            var spec = new OrderWithItemSpecification(id);


            var order = await _unitOfWork.Repository<Order, Guid>().GetWithSpcificationById(spec);

            if (order == null)
                throw new Exception("You Do Not Have Any Order Yet");

            var mapped = _mapper.Map<OrderDetailsDto>(order);

            return mapped;
        }
    }
}
