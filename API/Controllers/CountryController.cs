﻿using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController<int, Country, CountryRepository>
    {
        public CountryController(CountryRepository repository) : base(repository)
        {
        }
    }
}
