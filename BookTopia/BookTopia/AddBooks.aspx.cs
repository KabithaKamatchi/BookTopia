using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookTopia.BookTopia
{
    public partial class AddBooks : System.Web.UI.Page
    {
        string connectionString = "data source=MS-NB0007\\MSSQLSERVER13; database=NovelStore; integrated security=SSPI";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateBookTable();
                if (IsEditing())
                {
                    LoadBookDetails();
                }
            }
        }

        public bool IsEditing()
        {
            return !string.IsNullOrEmpty(Request.QueryString["BookId"]);
        }

        protected void LoadBookDetails()
        {
            int bookId;
            if (int.TryParse(Request.QueryString["BookId"], out bookId))
            {
                txtBookId.ReadOnly = true;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM LibraryCatalog WHERE BookId = @BookId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@BookId", bookId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtBookId.Text = reader["BookId"].ToString();
                        txtName.Text = reader["Name"].ToString();
                        txtAuthor.Text = reader["Author"].ToString();
                        txtISBN.Text = reader["ISBN"].ToString();
                        txtDateOfPublication.Text = Convert.ToDateTime(reader["DateOfPublication"]).ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query;
                if (IsEditing())
                {
                    query = "UPDATE LibraryCatalog SET Name = @Name, Author = @Author, ISBN = @ISBN, DateOfPublication = @DateOfPublication WHERE BookId = @BookId";
                }
                else
                {
                    query = "INSERT INTO LibraryCatalog (Name, Author, ISBN, DateOfPublication) VALUES (@Name, @Author, @ISBN, @DateOfPublication)";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                cmd.Parameters.AddWithValue("@DateOfPublication", DateTime.Parse(txtDateOfPublication.Text));

                if (IsEditing())
                {
                    cmd.Parameters.AddWithValue("@BookId", int.Parse(txtBookId.Text));
                }             

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("~/BookTopia/ViewBooks.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "Cancelled Successfully.";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44370/");          
 
        }

        public void CreateBookTable()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='LibraryCatalog' AND xtype='U')
                CREATE TABLE LibraryCatalog (
                    BookId INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(255) NOT NULL,
                    Author NVARCHAR(255) NOT NULL,
                    ISBN NVARCHAR(50) NOT NULL UNIQUE,
                    DateOfPublication DATE NOT NULL
                )";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtDateOfPublication.Text))

            {
                lblErrorMessage.Text = "All fields must be filled out.";
                lblSuccessMessage.Text = string.Empty;
                return false;
            }

            DateTime publicationDate;
            if (!DateTime.TryParse(txtDateOfPublication.Text, out publicationDate))
            {
                lblErrorMessage.Text = "Please enter a valid date for Date of Publication.";
                lblSuccessMessage.Text = string.Empty;
                return false;
            }

            int bookISBN;
            if (!int.TryParse(txtISBN.Text, out bookISBN))
            {
                lblErrorMessage.Text = "Please enter a valid Book ISBN.";
                lblSuccessMessage.Text = string.Empty;
                return false;
            }

            lblErrorMessage.Text = string.Empty;
            return true;
        }
    }
}