using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _unitOfWork.UserRepository.GetById((int)userId);
            return View(user);
        }

        public IActionResult ProfileSaveAction([FromBody]Data.DTOs.Account_ProfileSaveAction_Request account_ProfileSaveAction_Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("bad boy");
            }

            int? userId = HttpContext.Session.GetInt32("UserId");

            var user = _unitOfWork.UserRepository.Get((int)userId);

            user.Name = account_ProfileSaveAction_Request.Name;
            user.Surname = account_ProfileSaveAction_Request.Surname;
            user.Email = account_ProfileSaveAction_Request.Email;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();

            return new JsonResult(user);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}