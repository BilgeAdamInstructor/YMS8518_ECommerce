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

        public IActionResult ProfileSaveAction([FromBody]Data.DTOs.Account_ProfileSaveAction_Request dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("bad boy");
            }

            int? userId = HttpContext.Session.GetInt32("UserId");

            var user = _unitOfWork.UserRepository.Get((int)userId);

            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Email = dto.Email;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();

            return new JsonResult(user);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult ChangePasswordAction([FromBody] Data.DTOs.Account_ChangePasswordAction_Request dto)
        {
            if (!ModelState.IsValid) return BadRequest("Kötü çocuk");

            int userId = HttpContext.Session.GetInt32("UserId").Value;
            var user = _unitOfWork.UserRepository.GetById(userId);

            if (user.Password == Helper.CryptoHelper.Sha1(dto.Password))
            {
                user.Password = Helper.CryptoHelper.Sha1(dto.NewPassword);
                _unitOfWork.Complete();
            }
            else
            {
                return BadRequest("Şifre, mevcut şifreniz ile aynı değil.");
            }

            return new JsonResult("ok");
        }
    }
}