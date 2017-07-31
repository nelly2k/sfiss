using System.IO;
using Microsoft.WindowsAzure.Storage;
using Sfiss.Common.Contract;

namespace Sfiss.ExerciseAPIService.Exercise
{
    public interface IImageService: IService
    {
        byte[] GetLocalImage();
        byte[] GetImage();
    }

    public class ImageService : IImageService
    {

        public byte[] GetLocalImage()
        {
            return File.ReadAllBytes(@"c:\Users\Nelli\Downloads\exercise.png");
        }

        public byte[] GetImage()
        {
            var storageConnectionString =
                "DefaultEndpointsProtocol=https;" +
                "AccountName=sfissblob;" +
                "AccountKey=C+xtm88VE253hYnbqIK8jv5nHV44hFhxWRhpkCQQggZb8E5yyq1yRM7KcVsLjtm453S9LBWEKrkAp897+M2w8Q==;" +
                "EndpointSuffix=core.windows.net";

            var account = CloudStorageAccount.Parse(storageConnectionString);
            var serviceClient = account.CreateCloudBlobClient();
            var container = serviceClient.GetContainerReference("sfiss-exercise");
            var blob = container.GetBlockBlobReference("exercise.png");
            blob.FetchAttributes();
            long fileByteLength = blob.Properties.Length;
            byte[] fileContent = new byte[fileByteLength];
            for (int i = 0; i < fileByteLength; i++)
            {
                fileContent[i] = 0x20;
            }
            blob.DownloadToByteArray(fileContent, 0);
            return fileContent;
        }
    }
}
