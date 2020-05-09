using System;
using System.Linq;
using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [FilterContext.Log]
        [Route("/yonetim/kategori/ekle/{id:int}")]
        public IActionResult Manage(int id)
        {
            return View(id);
        }
        
        [FilterContext.Log]
        [Route("/kategori/getir/{id:int}")]
        public IActionResult Get(int id)
        {
            var category = _unitOfWork.CategoryRepository.Get(id);

            return new JsonResult(category);
        }
        
        [FilterContext.Log]
        [Route("/kategori/kaydet")]
        public IActionResult Save([FromBody] Data.DTO.Category_Save_Request dto)
        {
            if (!ModelState.IsValid) return BadRequest("Kötü çocuk");
            Data.Entities.Category category = null;
            Data.Entities.Menu menu = null;
            Data.Entities.Category parentCategory = null;

            if (dto.MenuId != null)
            {
                menu = _unitOfWork.MenuRepository.Get((int)dto.MenuId);
            }

            if (dto.ParentCategoryId != null)
            {
                parentCategory = _unitOfWork.CategoryRepository.Get((int)dto.ParentCategoryId);
            }

            if (dto.CategoryId == 0)
            {
                //yeni kayıt
                category = new Data.Entities.Category()
                {
                    Active = true,
                    CreateDate = DateTime.UtcNow,
                    Menu = menu,
                    Name = dto.Name,
                    Parent = parentCategory
                };

                _unitOfWork.CategoryRepository.Insert(category);
                _unitOfWork.Complete();
            }
            else
            {
                //güncelleme
                category = _unitOfWork.CategoryRepository
                    .Query()
                    .Include(a => a.Parent)
                    .Include(a => a.Menu)
                    .SingleOrDefault(a => a.Id == dto.CategoryId);

                if (category == null) return BadRequest("Kaydetmeye çalıştığınız kategori bulunamadı.");

                category.Name = dto.Name;
                category.Menu = menu;
                category.Parent = parentCategory;

                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Complete();
            }

            return new JsonResult(category);
        }
        
        [FilterContext.Log]
        [Route("/kategori/getir")]
        public IActionResult GetAll()
        {
            var categories = _unitOfWork.CategoryRepository.List();

            return new JsonResult(categories);
        }
    }
}