using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController<int, Cities, CityRepository>
    {
        public CityController(CityRepository repository) : base(repository)
        {
        }
    }
}
