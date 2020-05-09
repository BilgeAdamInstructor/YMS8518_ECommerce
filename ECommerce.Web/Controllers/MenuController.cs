using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [FilterContext.Log]
        [Route("/menu/getir")]
        public IActionResult Get()
        {
            var menus = _unitOfWork.MenuRepository.List();
            return new JsonResult(menus);
        }
    }
}