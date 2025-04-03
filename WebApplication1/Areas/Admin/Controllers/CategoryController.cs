using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Utillity;


namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {

          return View();
           
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the DiplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Category created successsfully";
                return RedirectToAction("Index");
            }
            return View(obj);
           

        }
        public IActionResult Edit(int id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            Category categoryfromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);

        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                 _unitOfWork.Save();
                TempData["Success"] = "Category Updated successsfully";
                return RedirectToAction("Index");
            }
            return View();


        }
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);

        }
        [HttpPost,ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj== null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category Deleted successsfully";
            return RedirectToAction("Index");
            return View();


        }
    }

}
