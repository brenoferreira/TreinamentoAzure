using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using MvcWebRole1.Models;

namespace MvcWebRole1.Azure
{
    public class ProductRepository
    {
        ProductsTableServiceContext context;

        public ProductRepository()
        {
            var account = CloudStorageAccount.FromConfigurationSetting("ProductsSettings");
            this.context = new ProductsTableServiceContext(account);
        }

        public IQueryable<Product> GetAll()
        {
            return this.context.Products;
        }

        public Product GetByID(String partitionKey, String rowKey)
        {
            return this.context.Products.Where(product => product.PartitionKey == partitionKey && 
                                                            product.RowKey == rowKey).FirstOrDefault();
        }

        public void Create(Product product)
        {
            this.context.AddObject(this.context.TableName, product);
        }

        public void Update(Product product)
        {
            var p = this.GetByID(product.PartitionKey, product.RowKey);

            p.Name = product.Name;
            p.Price = product.Price;
            p.Category = product.Category;
            this.context.UpdateObject(p);
        }

        public void Delete(Product product)
        {
            this.context.DeleteObject(product);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}