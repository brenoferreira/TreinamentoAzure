using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.IO;

namespace MvcWebRole1.Azure
{
    public class BlobStorage
    {
        private CloudBlobClient client;
        private CloudBlobContainer container;

        public BlobStorage()
        {
            var storageAccount = CloudStorageAccount.FromConfigurationSetting("PhotoSettings");

            this.client = storageAccount.CreateCloudBlobClient();
            this.container = this.client.GetContainerReference("photos");
            if(this.container.CreateIfNotExist())
                this.container.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Container });
        }

        public void AddPhoto(dynamic photoInfo, Stream photo)
        {
            var blob = this.container.GetBlobReference((string)photoInfo.Name);

            blob.Metadata["Description"] = photoInfo.Description;

            blob.UploadFromStream(photo);
            blob.SetMetadata();
        }

        public IEnumerable<CloudBlob> GetPhotos()
        {
            var blobs = this.container.ListBlobs().Select(blob =>
                {
                    var blobRef = this.container.GetBlobReference(blob.Uri.AbsoluteUri);
                    blobRef.FetchAttributes();
                    return blobRef;
                });

            return blobs;
        }
    }
}