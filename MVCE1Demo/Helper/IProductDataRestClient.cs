using System;
namespace MVCE1Demo.Helper
{
    public interface IProductDataRestClient
    {
        void Add(MVCE1Demo.Models.Product.ProductModel Productdata);
        void Delete(int id);
        System.Collections.Generic.IEnumerable<MVCE1Demo.Models.Product.ProductModel> GetAll();
        MVCE1Demo.Models.Product.ProductModel GetByid(int id);
        void Update(MVCE1Demo.Models.Product.ProductModel Productdata);
    }
}
