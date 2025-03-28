using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using DataAccess.Repository.IRepository;


namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Product> objCategoryList = _unitOfWork.Product.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {

          return View();
           
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
         
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
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
            Product categoryfromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);

        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                 _unitOfWork.Save();
                TempData["Success"] = "Product Updated successsfully";
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
            Product categoryfromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);

        }
        [HttpPost,ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj== null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category Deleted successsfully";
            return RedirectToAction("Index");
            return View();


        }
    }

}
