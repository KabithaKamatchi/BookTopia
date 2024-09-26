using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookTopia.BookTopia
{
    public partial class ViewBooks : System.Web.UI.Page
    {
        string connectionString = "data source=MS-NB0007\\MSSQLSERVER13; database=NovelStore; integrated security=SSPI";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBooks();
            }
        }

        protected void LoadBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LibraryCatalog";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

        protected void gvBooks_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int bookId = Convert.ToInt32(gvBooks.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"~/BookTopia/AddBooks.aspx?BookId={bookId}");
        }

        protected void gvBooks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookId = Convert.ToInt32(gvBooks.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM LibraryCatalog WHERE BookId = @BookId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookId", bookId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadBooks();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/BookTopia/AddBook.aspx");
        }

    }
}