using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Example.Models;

namespace MVC_Example.Controllers;

public class HomeController : Controller
{

    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 15000 },
        new Product { Id = 2, Name = "Telefon", Price = 10000 },
        new Product { Id = 3, Name = "Tablet", Price = 7000 }
    };

    public IActionResult Index()
    {
       
        return View();
    }

    public IActionResult Details(int id)
    {
        var product = _products.Find(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            product.Id=_products.Count+1;
            _products.Add(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }
    public IActionResult Delete(int id)
    {
        var product=_products.Find(p=>p.Id==id);
        if (product==null)
        {
            return NotFound();
        }
        return View(product);
    }
    public IActionResult DeleteConfirmed(int id)
    {
        var product=_products.Find(p=>p.Id==id);
        if (product !=null)
        {
            _products.Remove(product);
        }
        return RedirectToAction("Index");
    }




}
