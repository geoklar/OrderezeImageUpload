using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Data.SqlClient;
using System.Data;
using OrderezeTask;

namespace AzureUploadStoreDelete
{
    public partial class Default : System.Web.UI.Page
    {
        ImageMethods az = new ImageMethods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                GridViewData();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[e.Row.Cells.Count - 1].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.Cells[0].Text);
                e.Row.Cells[e.Row.Cells.Count - 1].Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            List<OrderezeTask.Image> list = new List<OrderezeTask.Image>();
            try
            {
                list = az.GetImages();
            }
            catch { }
            
            int id = ((GridView)sender).SelectedIndex;
            az.DeleteImage(id);

            if (list.Count(x => x.Id == id) > 0)
                az.DeleteBlob(list.Where(x => x.Id == id).First().Name);

            GridViewData();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                string FileExtension = string.Empty;
                try
                {
                    FileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).Substring(1);
                }
                catch { }

                OrderezeTask.Image image = new OrderezeTask.Image();
                image.Name = NameTxt.Text + "." + FileExtension;
                image.Description = DescriptionTxt.Text;
                image.ImagePath = "https://geoklar.blob.core.windows.net/images/" + NameTxt.Text + "." + FileExtension;
                int id = az.AddNewImage(image);
                if(id > 0)
                {
                    az.UploadBlob(FileUpload1, NameTxt.Text + "." + FileExtension);
                }

                GridViewData();
            }
        }

        private void GridViewData()
        {
            List<OrderezeTask.Image> list = new List<OrderezeTask.Image>();
            list = az.GetImages();
            if (list.Count > 0)
            {
                DataTable dt = new DataTable();
                //dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Α/Α"), new DataColumn("Όνομα"), new DataColumn("Περιγραφή"), new DataColumn("Τοποθεσία"), new DataColumn("Διαγραφή") });
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Description"), new DataColumn("ImagePath") });
                foreach (var l in list)
                {
                    dt.Rows.Add(l.Id, l.Name, l.Description, l.ImagePath);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}