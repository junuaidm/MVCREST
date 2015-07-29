using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Configuration;
using MVCE1Demo.Models.Product;
using System.Net;
namespace MVCE1Demo.Helper
{
    public class ProductDataRestClient : IProductDataRestClient
    {
        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["WebApiBaseUrl"];


        public ProductDataRestClient()
        {
            _client = new RestClient(_url)
            {
                Authenticator = new HttpBasicAuthenticator("api", "api")
            };
        }

        public IEnumerable<ProductModel> GetAll()
        {

            var request = new RestRequest("api/Product", Method.GET) { RequestFormat = DataFormat.Json };
            var responce = _client.Execute<List<ProductModel>>(request);

            if (responce.Data == null)
                throw new Exception(responce.ErrorMessage);

            return responce.Data;

            
        }

        public ProductModel GetByid(int id)
        {
            var request = new RestRequest("api/Product/{id}", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var responce = _client.Execute<ProductModel>(request);

            if (responce.Data == null)
                throw new Exception(responce.ErrorMessage);
            return responce.Data;

        }


        //Add
        public void Add(ProductModel Productdata)
        {
            var request = new RestRequest("api/Product", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(Productdata);

            var responce = _client.Execute<ProductModel>(request);

            if (responce.StatusCode != HttpStatusCode.Created)
                throw new Exception(responce.ErrorMessage);
        }

        //update

        public void Update(ProductModel Productdata)
        {

            var request = new RestRequest("api/Product", Method.PUT) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", Productdata.ProductId, ParameterType.UrlSegment);

            var responce = _client.Execute<ProductModel>(request);

            if (responce.StatusCode != HttpStatusCode.NotFound)
                throw new Exception(responce.ErrorMessage);

        }
        //Delete
        public void Delete(int id)
        {

            var request = new RestRequest("api/Product", Method.DELETE);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            var responce = _client.Execute<ProductModel>(request);

            if (responce.StatusCode != HttpStatusCode.NotFound)
                throw new Exception(responce.ErrorMessage);


        }
        
    }
}
