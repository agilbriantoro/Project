using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<int, Roles, RoleRepository>
    {
        public RoleController(RoleRepository repository) : base(repository)
        {
        }
    }
}
