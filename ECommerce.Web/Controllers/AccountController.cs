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
            var user = _unitOfWork.UserRepository.Get((int)userId);
            return View(user);
        }
    }
}