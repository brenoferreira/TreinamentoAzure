using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace ConsoleApplication1.Azure
{
    public class QueueClient
    {
        private CloudQueue queue;
        public QueueClient()
        {
            var account = CloudStorageAccount.DevelopmentStorageAccount;

            var queueClient = account.CreateCloudQueueClient();

            this.queue = queueClient.GetQueueReference("messages");
            this.queue.CreateIfNotExist();
        }

        public void AddMessage(string message)
        {
            this.queue.AddMessage(new CloudQueueMessage(message));
        }

        public String GetMessage()
        {
            var message = this.queue.GetMessage();
            if (message != null)
            {
                this.queue.DeleteMessage(message);
                return message.AsString;
            }
            return null;
        }
    }
}