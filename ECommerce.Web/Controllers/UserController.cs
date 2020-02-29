using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ECommerce.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginAction([FromBody]Data.DTOs.User_LoginAction_Request user_LoginAction_Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("olm bak git");
            }

            var user = _unitOfWork.UserRepository.GetByEmailAndPassword(user_LoginAction_Request.Email, user_LoginAction_Request.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", user.Id);

                if (user_LoginAction_Request.RememberMe)
                {
                    //beni hatırla
                    Guid guid = Guid.NewGuid();
                    user.AutoLoginKey = guid;
                    _unitOfWork.UserRepository.Update(user);
                    _unitOfWork.Complete();

                    HttpContext.Response.Cookies.Append("rememberme", guid.ToString(),
                        new CookieOptions() {
                            Expires = DateTime.UtcNow.AddYears(1)
                        });
                }
            }

            return new JsonResult(user);
        }

        public IActionResult LogoutAction()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Response.Cookies.Delete("rememberme");

            return RedirectToAction("Index", "Home");
        }
    }
}