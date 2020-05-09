using System.Linq;
using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Web.Controllers
{
    public class LogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [FilterContext.Log]
        [Route("/log/getir")]
        public IActionResult GetAll()
        {
            var logs = _unitOfWork.LogRepository
                .Query()
                .Include(a => a.User)
                .ToList();

            return new JsonResult(logs);
        }
    }
}