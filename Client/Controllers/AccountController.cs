﻿using API.ViewModels;
using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;


namespace Client.Controllers
{
    public class AccountController : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository _accountRepository;

        public AccountController(AccountRepository repository) : base(repository)
        {
            this._accountRepository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Account account)
        {
            var result = await _accountRepository.Post(account);
            if (result.StatusCode == "200")
            {
                RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var result = await _accountRepository.Login(loginVM);
            if (result is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (result.StatusCode == "409")
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            else if (result.StatusCode == "200")
            {
                HttpContext.Session.SetString("JWToken", result.Data);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
