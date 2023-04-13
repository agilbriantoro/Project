using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController<int, Address, AddressRepository>
    {
        public AddressController(AddressRepository repository) : base(repository)
        {
        }
    }
}
