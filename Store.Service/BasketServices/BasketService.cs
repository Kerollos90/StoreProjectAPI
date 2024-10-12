using AutoMapper;
using Store.Repository.Baskets;
using Store.Repository.Baskets.Models;
using Store.Service.BasketServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository repository , IMapper mapper) 
        {
            _repository   =  repository ;
            _mapper =   mapper ;
        }

        public async Task<bool> DeleteBasketAsync(string id)
         =>await _repository.DeleteBasketAsync(id);

        public async Task<CustomerBasketDto> GetBasketAsync(string id)
        {
            var data = await _repository.GetBasketAsync(id);

            if (data == null)
                return null;

            var dataMapped =  _mapper.Map<CustomerBasketDto>(data);

            return dataMapped;

            
        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket)
        {
            if (basket.Id is null)
               basket.Id = GeneratIdBasket();
                

            var data = _mapper.Map<CustomerBasket>(basket);

            var dataUpdated =await _repository.UpdateBasketAsync(data);

            var dataDto = _mapper.Map<CustomerBasketDto>(dataUpdated);

            return dataDto;
            


            
        }



        private  string GeneratIdBasket()
        { 
            Random random = new Random();

            var num = random.Next(1000,10000);

            return $"BS-{num}";


        
        
        }
    }
}
