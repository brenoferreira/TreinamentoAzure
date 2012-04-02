using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IProductsService
    {
        [OperationContract]
        void AddProduct(Product product);
    }

    public interface IProductServiceChannel : IProductsService, IClientChannel
    {

    }

    public class ProductsService : IProductsService
    {
        private ProductsDataContext context = new ProductsDataContext();

        public void AddProduct(Product product)
        {
            context.Products.Add(product);

            context.SaveChanges();
        }
    }
}
