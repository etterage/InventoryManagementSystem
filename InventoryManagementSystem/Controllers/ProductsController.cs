using InventoryApp.Data;
using InventoryApp.Models;
using InventoryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace InventoryApp.Controllers
{

    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        //Index
        [HttpGet("/products")]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
            //return View();
        }

        //Add GET
        [HttpGet("/products/add")]
        public IActionResult Add()
        {
            return View();
        }

        //Add POST
        [HttpPost("/products/add")]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View("Add", model);
            }

            string fileName = null;

            if (model.Image != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");

            }

            var product = new Product
            {
                Name = model.Name,
                ProductCode = model.ProductCode,
                Description = model.Description,
                CostPrice = model.CostPrice,
                SellingPrice = model.SellingPrice,
                StockQuantity = model.StockQuantity,
                LowStackTreshold = model.LowStackTreshold,
                CategoryId = model.CategoryId,
                IsActive = model.IsActive
            }
            ;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            TempData["success"] = "Product Added Successfully...";

            return RedirectToAction("Index");
        }


        //Edit GET
        [HttpGet("products/edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return View(product);
        }

        //Edit POST
        [HttpPost("products/edit/{id}")]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["UpdateSuccess"] = "Product updated successfully...";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(product);
            }

        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                TempData["DeleteFailed"] = "Product not found...";
                return RedirectToAction("Index");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            TempData["DeleteSuccess"] = "Product deleted successfully...";
            return RedirectToAction("Index");
        }

        

    }
}
