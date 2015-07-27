using BusinessServices;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WEBAPI.Controllers
{
    public class ProductController : ApiController
    {

        private readonly IProductServices _productServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        //public ProductController()
        //{
        //    _productServices = new ProductServices();
        //}

        public ProductController(IProductServices productServices)
        {

            _productServices = productServices;
        }
        #endregion

        // GET api/product
        [Route("productid/{id?}")]
        [Route("particularproduct/{id?}")]
        [Route("myproduct/{id:range(1, 3)}")]
        public HttpResponseMessage Get()
        {
            var products = _productServices.GetAllProducts();
            if (products != null)
            {
                var productEntities = products as List<ProductEntity> ?? products.ToList();
                if (productEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }
        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            var product = _productServices.GetProductById(id);
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }
         //POST api/product
        public int Post([FromBody] ProductEntity productEntity)
        {
            //Context.Response.StatusCode = 201;
            return _productServices.CreateProduct(productEntity);
        }

        //public StatusCodeResult Post([FromBody] ProductEntity productEntity)
        //{
        //    //Context.Response.StatusCode = 201;
        //    //return _productServices.CreateProduct(productEntity);

        //    _productServices.CreateProduct(productEntity);
        //    if (productEntity.ProductId>0)

        //    return new StatusCodeResult(HttpStatusCode.Created,this);

        //    return new StatusCodeResult(HttpStatusCode.NotModified, this);
        //}
        // PUT api/product/5
        public bool Put(int id, [FromBody]ProductEntity productEntity)
        {
            if (id > 0)
            {
                return _productServices.UpdateProduct(id, productEntity);
            }
            return false;
        }

        // DELETE api/product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _productServices.DeleteProduct(id);
            return false;
        }
        //// GET api/product
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/product/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/product
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/product/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/product/5
        //public void Delete(int id)
        //{
        //}
    }
}
