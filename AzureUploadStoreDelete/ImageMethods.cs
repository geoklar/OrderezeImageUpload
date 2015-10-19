using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AzureUploadStoreDelete
{
    public class ImageMethods : OrderezeTask.IImagesService
    {
        StorageCredentials sc;
        CloudStorageAccount storageAccount;

        private string connectionString = "Data Source=jowbfvmk9d.database.windows.net;Initial Catalog=imagedatabase;Persist Security Info=True;User ID=geoklar;Password=Ordereze1";

        public ImageMethods()
        {
            sc = new StorageCredentials("geoklar", "Pi+w82PXiTUQj05ejAf4HstsnyNVU6PlLQdKlyNoc48c5V7+tlJpBz61V+PfipbqJ3izCyOZRFt9T8m3nVMl5Q==");
            storageAccount = new CloudStorageAccount(sc, false);
        }

        public void UploadBlob(FileUpload fu, string name)
        {
            try
            {
                CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobclient.GetContainerReference("images");
                CloudBlockBlob blockblob = container.GetBlockBlobReference(name);
                using (var stream = new System.IO.MemoryStream(fu.FileBytes, writable: false))
                {
                    blockblob.UploadFromStream(stream);
                }
            }
            catch { }
        }

        public void DeleteBlob(string name)
        {
            try
            {
                CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobclient.GetContainerReference("images");
                CloudBlockBlob blockblob = container.GetBlockBlobReference(name);
                blockblob.Delete();
            }
            catch { }
        }

        public int AddNewImage(OrderezeTask.Image image)
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO dbo.images (Name, Description, ImagePath) VALUES (@Name, @Description, @ImagePath)");
                        //cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@Name", image.Name);
                        cmd.Parameters.AddWithValue("@Description", image.Description);
                        cmd.Parameters.AddWithValue("@ImagePath", "https://geoklar.blob.core.windows.net/images/" + image.Name);
                        connection.Open();
                        id = cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            catch { }

            return id;
        }

        public List<OrderezeTask.Image> GetImages()
        {
            List<OrderezeTask.Image> list = new List<OrderezeTask.Image>();
            OrderezeTask.Image image;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Select Id, Name, Description, ImagePath From images");
                        //cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                image = new OrderezeTask.Image();
                                image.Id = reader.GetInt32(0);
                                image.Name = reader.GetString(1);
                                image.Description = reader.GetString(2);
                                image.ImagePath = reader.GetString(3);
                                list.Add(image);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            catch { }

            return list;
        }

        public void DeleteImage(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM dbo.images WHERE Id=@Id");
                        //cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        id = cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            catch { }
        }
    }
}