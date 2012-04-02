using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using MvcWebRole1.Models;

namespace MvcWebRole1.Azure
{
    public class ProductsTableServiceContext : TableServiceContext
    {
        public ProductsTableServiceContext(CloudStorageAccount account)
            : base(account.TableEndpoint.AbsoluteUri, account.Credentials)
        {
            CloudTableClient.CreateTablesFromModel(typeof(ProductsTableServiceContext), account.TableEndpoint.AbsoluteUri, account.Credentials);

            this.TableName = "Products";
        }

        public IQueryable<Product> Products
        {
            get
            {
                return this.CreateQuery<Product>(this.TableName);
            }

        }

        public String TableName { get; private set; }
    }
}