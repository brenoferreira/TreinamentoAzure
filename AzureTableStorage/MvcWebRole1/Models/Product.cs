using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;

namespace MvcWebRole1.Models
{
    public class Product : TableServiceEntity
    {
        public Product()
        {
            this.PartitionKey = DateTime.Now.ToShortDateString().Replace('/', '-');
            this.RowKey = Guid.NewGuid().ToString();
        }

        public String Name { get; set; }

        public double Price { get; set; }

        public String Category { get; set; }

    }
}