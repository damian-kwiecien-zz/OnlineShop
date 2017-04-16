using OnlineShop.DTOs;
using OnlineShop.Services;
using System.Web.Http;

namespace OnlineShop.Controllers
{
    public class PurchaseController : ApiController
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // POST: api/Purchase
        public IHttpActionResult Post([FromBody]PurchaseDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _purchaseService.AddPurchase(dto);
            return Ok();
        }
    }
}
