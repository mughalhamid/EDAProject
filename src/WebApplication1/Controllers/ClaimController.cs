using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedisApplication.Cache;
using RedisApplication.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public ClaimController(ICacheService cacheService, RedisDbContext dbContext)
        {
            _cacheService = cacheService;
        }

        [HttpPost("DeclareClaim")]
        public async Task<bool> DeclareClaim([FromBody] Claim declareClaim)
        {

            var claimData = _cacheService.GetListData<Claim>();

            if (claimData != null)
            {
                claimData.Add(declareClaim);
            }
            else
            {
                claimData = [declareClaim];
            }            

            bool isSave = _cacheService.SetListData<Claim>(
                claimData
            );

            return isSave;
        }

        [HttpGet("GetClaimDetails")]
        public List<Claim> GetClaimDetails()
        {
            var claimData = _cacheService.GetListData<Claim>();

            return claimData;
        }
    }
}
