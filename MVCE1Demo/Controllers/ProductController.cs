using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCE1Demo.Helper;
using MVCE1Demo.Models.Product;
namespace MVCE1Demo.Controllers
{
    public class ProductController : Controller
    {
        static readonly IProductDataRestClient RestClient = new ProductDataRestClient();

        // GET: /Product/
        public ActionResult Index()
        {
            return View(RestClient.GetAll());
        }

        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            return View(RestClient.GetByid(id));
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel productData)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    RestClient.Add(productData);
                    return RedirectToAction("Index");
                }
                return View(productData);
                
            }
            catch 
            {

                return View();
            }
        }
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RestClient.GetByid(id));
        }

        //Post:/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel productData)
        {
            try
            {
                RestClient.Update(productData);
                return RedirectToAction("Index");
            }
            catch
            {
                
               return View();
            }
        }

        //GET:/Product/Delete/5

        public ActionResult Delete(int id)
        {

            return View(RestClient.GetByid(id));
        }
        //POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductModel productData)
        {
            try
            {
                RestClient.Delete(productData.ProductId);
                return RedirectToAction("Index");

            }
            catch 
            {

                return View();

            }

        }


    }
}