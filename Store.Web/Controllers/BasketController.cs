using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.BasketServices;
using Store.Service.BasketServices.Dtos;

namespace Store.Web.Controllers
{
   
    public class BasketController : BaseController
    {
        private readonly IBasketService _basket;

        public BasketController(IBasketService basket) 
        {
            _basket = basket;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasketDto>> GetAllBasket (string id)
            =>  Ok(await _basket.GetBasketAsync (id));  

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateAllBasket(CustomerBasketDto input)
            =>  Ok(await _basket.UpdateBasketAsync (input));  

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> DeleteAllBasket (string id)
            =>  Ok(await _basket.DeleteBasketAsync (id));

    }
}
