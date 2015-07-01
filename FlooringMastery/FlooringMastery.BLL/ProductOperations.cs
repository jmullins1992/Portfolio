using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using Models;
using Models.Interfaces;

namespace FlooringMastery.BLL
{
    public class ProductOperations
    {
        private readonly IProductRepository _myProductRepository;

        public ProductOperations(IProductRepository aProductRepository)
        {
            _myProductRepository = aProductRepository;
        }

        public Response<decimal> GetMaterialPerSquareFoot(string productType)
        {
            List<Product> allProducts;
            var response = new Response<decimal>();

            try
            {
                allProducts = _myProductRepository.ListAll();
                response.Data = allProducts.First(s => s.ProductType == productType).CostPerSquareFoot;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "\nCould not write to log file.";
                }
            }
           
            return response;
        }

        public Response<decimal> GetLaborPerSquareFoot(string productType)
        {
            List<Product> allProducts;
            var response = new Response<decimal>();

            try
            {
                allProducts = _myProductRepository.ListAll();
                response.Data = allProducts.First(s => s.ProductType == productType).LaborCostPerSquareFoot;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<bool> IsValidProduct(string productType)
        {
            List<Product> allProducts;
            var response = new Response<bool>();

            try
            {
                allProducts = _myProductRepository.ListAll();
                response.Data = allProducts.Any(s => s.ProductType == productType);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "Could not write to log file.";
                }
            }

            return response;
        }
    }
}
