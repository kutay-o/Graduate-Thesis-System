using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTS
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillSubject();
                FillUni();
                FillUniInst();
                fillPerson();
            }
        }

        protected void btnUpdateUniClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@name", txtUni.Text.Trim());
                SqlParameter param1 = new SqlParameter("@location", txtLocation.Text.Trim());
                SqlParameter param2 = new SqlParameter("@id", Convert.ToInt32(ddlUni.SelectedValue));

                comm = new SqlCommand("Update University set Name = @name, Location = @location where UniversityID = @id", conn);
                comm.Parameters.Add(param);
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.ExecuteNonQuery();
            }
            catch
            {
                
            }
            finally
            {
                lblUpdateSuccesUni.Text = "Güncellendi.";
                conn.Close();
            }
        }

        protected void btnUpdateInstClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@name", txtInst.Text.Trim());
                SqlParameter param2 = new SqlParameter("@id", Convert.ToInt32(ddlUniInst.SelectedValue));
                SqlParameter param3 = new SqlParameter("@instid", Convert.ToInt32(ddlInst.SelectedValue));

                comm = new SqlCommand("Update Institute set Name = @name where UniversityID = @id and InstituteID = @instid", conn);
                comm.Parameters.Add(param);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
                comm.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                lblUpdateSuccesInst.Text = "Güncellendi.";
                conn.Close();
            }
        }

        protected void btnUpdatePersonClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@name", txtPersonName.Text.Trim());
                SqlParameter param1 = new SqlParameter("@surname", txtPersonSurname.Text.Trim());
                SqlParameter param2 = new SqlParameter("@id", Convert.ToInt32(ddlPerson.SelectedValue));

                comm = new SqlCommand("Update Person set Name = @name, Surname = @surname where PersonID = @id", conn);
                comm.Parameters.Add(param);
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                lblUpdateSuccesPerson.Text = "Güncellendi.";
                conn.Close();
            }
        }

        protected void btnUpdateSubjectClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@name", txtSubject.Text.Trim());
                SqlParameter param2 = new SqlParameter("@id", Convert.ToInt32(ddlSubject.SelectedValue));

                comm = new SqlCommand("Update Subject set SubjectName = @name where SubjectID = @id", conn);
                comm.Parameters.Add(param);
                comm.Parameters.Add(param2);
                comm.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                lblUpdateSuccesSubject.Text = "Güncellendi.";
                conn.Close();
            }
        }

        protected void FillUni()
        {

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT UniversityID,Name FROM University order by(Name)", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                ddlUni.DataSource = reader;
                ddlUni.DataValueField = "UniversityID";
                ddlUni.DataTextField = "Name";
                ddlUni.DataBind();
                reader.Close();
            }
            catch
            {
                Response.Write("Bir hata oluştu EYVAH !");
            }
            finally
            {
                conn.Close();
            }
            ddlUni.Items.Insert(0, new ListItem("Üniversite seçiniz", "0"));

        }

        protected void FillUniInst()
        {

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT UniversityID,Name FROM University order by(Name)", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                ddlUniInst.DataSource = reader;
                ddlUniInst.DataValueField = "UniversityID";
                ddlUniInst.DataTextField = "Name";
                ddlUniInst.DataBind();
                reader.Close();
            }
            catch
            {
                Response.Write("Bir hata oluştu EYVAH !");
            }
            finally
            {
                conn.Close();
            }
            ddlUniInst.Items.Insert(0, new ListItem("Üniversite seçiniz", "0"));

        }

        protected void selectedUni(object sender, EventArgs e)
        {

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT InstituteID,Name FROM Institute where UniversityID='" + ddlUniInst.SelectedValue + "'", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                ddlInst.DataSource = reader;
                ddlInst.DataValueField = "InstituteID";
                ddlInst.DataTextField = "Name";
                ddlInst.DataBind();
                reader.Close();
            }
            catch
            {
                Response.Write("Bir hata oluştu");
            }
            finally
            {
                conn.Close();
            }

        }

        protected void fillSubject()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT SubjectID,SubjectName FROM Subject order by(SubjectName)", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                ddlSubject.DataSource = reader;
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataTextField = "SubjectName";
                ddlSubject.DataBind();
                reader.Close();
            }
            catch
            {
                Response.Write("Bir hata oluştu");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void fillPerson()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT PersonID,Person.Name +' '+Person.Surname as P FROM Person order by (Name)", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                ddlPerson.DataSource = reader;
                ddlPerson.DataValueField = "PersonID";
                ddlPerson.DataTextField = "P";
                ddlPerson.DataBind();
                reader.Close();
            }
            catch
            {
                Response.Write("Bir hata oluştu");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnRefreshClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}