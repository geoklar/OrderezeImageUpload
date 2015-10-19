using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AzureUploadStoreDelete
{
    public partial class Default : System.Web.UI.Page
    {
        ImageMethods az = new ImageMethods();
        private bool IsPageRefresh = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Browser refresh fires the last event (for ex button click) again. 
            //The following code prevents this action.
            if (!Page.IsPostBack)
            {
                ViewState["postids"] = System.Guid.NewGuid().ToString();
                Session["postid"] = ViewState["postids"].ToString();
                GridViewData();
            }
            else
            {
                if (ViewState["postids"].ToString() != Session["postid"].ToString())
                {
                    IsPageRefresh = true;
                }
                Session["postid"] = System.Guid.NewGuid().ToString();
                ViewState["postids"] = Session["postid"].ToString();
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //Adding dynamically style and attribute to the last cell of each gridview row for performing deleting.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[e.Row.Cells.Count - 1].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.Cells[0].Text);
                e.Row.Cells[e.Row.Cells.Count - 1].Attributes["style"] = "cursor:pointer";
            }
        }

        //Perform delete of data entry and uploaded blob in Azure Storage
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //Retrieve info about stored images before deleting the entry
            List<OrderezeTask.Image> list = new List<OrderezeTask.Image>();
            try
            {
                list = az.GetImages();
            }
            catch { }
            
            int id = ((GridView)sender).SelectedIndex;
            az.DeleteImage(id);

            //Finding the name of the deleted entry file for proceeding with blob deletion in Azure Strorage 
            if (list.Count(x => x.Id == id) > 0)
                az.DeleteBlob(list.Where(x => x.Id == id).First().Name);

            GridViewData();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //checking if there is a file and action did not triggered by refreshing the page
            if (FileUpload1.HasFile && IsPageRefresh == false)
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
            }
            GridViewData();
        }

        //Retrive image list and fill GridView Data with it.
        private void GridViewData()
        {
            List<OrderezeTask.Image> list = new List<OrderezeTask.Image>();
            list = az.GetImages();
            if (list.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Description"), new DataColumn("ImagePath") });
                foreach (var l in list)
                {
                    dt.Rows.Add(l.Id, l.Name, l.Description, l.ImagePath);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Adding one custome header row on the top of the GridView
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Πίνακας Αποθηκευμένων Εικόνων";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.BorderStyle = BorderStyle.Solid;
                HeaderCell.BorderColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
    }
}