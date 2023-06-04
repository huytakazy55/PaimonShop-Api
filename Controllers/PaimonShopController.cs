using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaimonShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PaimonShopController : ControllerBase
    {
            private static List<PaimonShop> paimonshop = new List<PaimonShop>
            {
                new PaimonShop {
                    Id = 1,
                    ShopName = "PaiMon Shop",
                    Address = "Ha Noi",
                    PhoneNumber = 0969608810,
                    ShopItem = "Figure",
                    Email = "khongthaydoi124@gmail.com"
                },
                new PaimonShop {
                    Id = 2,
                    ShopName = "PaiMon Shop 2",
                    Address = "Hai Duong",
                    PhoneNumber = 0977615810,
                    ShopItem = "Figure",
                    Email = "huytakazy55@gmail.com"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<PaimonShop>>> Get()
        {
            return Ok(paimonshop);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<PaimonShop>>> Get(int id)
        {
            var branch = paimonshop.Find(h => h.Id == id);
            if (branch == null) {
                return BadRequest("Don't have Branch right now");
            }
            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult<List<PaimonShop>>> AddBranch(PaimonShop branch)
        {
            paimonshop.Add(branch);
            return Ok(paimonshop);
        }

        [HttpPut]
        public async Task<ActionResult<List<PaimonShop>>> UpdateBranch(PaimonShop request)
        {
            var branch = paimonshop.Find(h => h.Id == request.Id);
            if (branch == null) {
                return BadRequest("Don't have Branch right now");
            }
            branch.ShopName = request.ShopName;
            branch.Address = request.Address;
            branch.PhoneNumber = request.PhoneNumber;
            branch.ShopItem = request.ShopItem;
            branch.Email = request.Email;
            return Ok(branch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PaimonShop>>> Delete(int id)
        {
            var branch = paimonshop.Find(h => h.Id == id);
            if (branch == null) {
                return BadRequest("Does not esist branch");
            }
            paimonshop.Remove(branch);
            return Ok(branch);
        }
    }
}