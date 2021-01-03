using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SE_307_Project
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillUniversity();
        }

        protected void btnAddPersonClick(object sender, EventArgs e)
        {
                bool flag = true;
                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader reader;
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);


                try
                {
                    conn.Open();
                    comm = new SqlCommand("addPerson", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Value", Convert.ToInt32(ddlPerson.SelectedValue));
                    comm.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    comm.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                    comm.ExecuteNonQuery();
                }
                catch
                {
                //Response.Write("Bir hata oluştu" + ddlPerson.SelectedValue);
                    lblfailPerson.Text = "Ekleme başarısız";
                    flag = false;
                }
                finally
                {
                    
                    conn.Close();
                }
            if (flag)
                lblsuccesPerson.Text = "Kişi başarıyla eklendi.";
            }

        
        protected void btnDeletePersonClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@name", txtName.Text.Trim());
                SqlParameter param1 = new SqlParameter("@surname", txtSurname.Text.Trim());
                comm = new SqlCommand("Delete from Person where Person.Name like @name and Person.Surname like @surname ", conn);
                comm.Parameters.Add(param);
                comm.Parameters.Add(param1);
                comm.ExecuteNonQuery();
            }
            catch
            {
                lblfailPerson.Text = "Bu kişi kullanıldığı için silinemez ! ! !";
            }
            finally
            {
                conn.Close();
            }
        }
        protected void btnAddUniClick(object sender, EventArgs e)
        {
            bool flag = true;
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);


            try
            {
                conn.Open();
                comm = new SqlCommand("addUni", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@UniName", txtUniName.Text.Trim());
                comm.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                comm.ExecuteNonQuery();
            }
            catch
            {
                lblfailPerson.Text = "Ekleme başarısız";
                flag = false;
                Response.Write("Bir hata oluştu");
            }
            finally
            {
                conn.Close();
            }
            if (flag)
                lblsuccesUni.Text = "Üniversite başarıyla eklendi.";

            
        }
        protected void btnDeleteUniClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            { 
                conn.Open();
                SqlParameter param = new SqlParameter("@uniname", txtUniName.Text.Trim());
                comm = new SqlCommand("Delete from University where University.Name like @uniname ", conn);
                comm.Parameters.Add(param);

                comm.ExecuteNonQuery();
            }
            catch
            {
                lblfailUni.Text = "Bu üniversite kullanıldığı için silinemez ! ! !";
            }
            finally
            {
                conn.Close();
            }

        }


        protected void btnAddEnstClick(object sender, EventArgs e)
        {
                bool flag = true;
                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader reader;
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);


                try
                {
                    conn.Open();
                    comm = new SqlCommand("addEnst", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@UniversityID", Convert.ToInt32(ddlUni.SelectedValue));
                    comm.Parameters.AddWithValue("@Name", txtEns.Text.Trim());
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    lblfailEnst.Text = "Ekleme başarısız";
                    Response.Write("Bir hata oluştu");
                }
                finally
                {
                    conn.Close();
                }
            if(flag)
                lblsuccesEnst.Text = "Enstitü başarıyla eklendi";

        }

        protected void btnDeleteEnstClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@inst", txtSubject.Text.Trim());
                SqlParameter param1 = new SqlParameter("@uni", Convert.ToInt32(ddlUni.SelectedValue));

                comm = new SqlCommand("Delete from Institute where Name like '%'+@inst+'%' and UniversityID = @uni ", conn);
                comm.Parameters.Add(param);
                comm.Parameters.Add(param1);
                comm.ExecuteNonQuery();
            }
            catch
            {
                lblfailEnst.Text = "Bu enstitü kullanıldığı için silinemez ! ! !";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnAddLangClick(object sender, EventArgs e)
        {
            bool flag = true;
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);


            try
            {
                conn.Open();
                comm = new SqlCommand("addLang", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Language", txtLang.Text.Trim());
                comm.ExecuteNonQuery();
            }
            catch
            {
                lblfailLang.Text = "Ekleme başarısız.";
                flag = false;
                Response.Write("Bir hata oluştu");
            }
            finally
            {
                conn.Close();
            }
            if (flag)
                lblsuccesLang.Text = "Dil başarıyla eklendi.";
        }

        protected void btnDeleteLangClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@language", txtLang.Text.Trim());
                comm = new SqlCommand("Delete from Languages where Language like @language", conn);
                comm.Parameters.Add(param);
                comm.ExecuteNonQuery();
            }
            catch
            {
                lblfailLang.Text = "Bu dil kullanıldığı için silinemez ! ! !";
            }
            finally
            {
                conn.Close();
            }
        }

        private void fillUniversity()
        {
            if (!IsPostBack)
            {
                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader reader;
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);
                comm = new SqlCommand("SELECT UniversityID,Name FROM University", conn);

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
                    Response.Write("Bir hata oluştu");
                }
                finally
                {
                    conn.Close();
                }
                ddlUni.Items.Insert(0, new ListItem("Üniversite seçiniz", "0"));
            }
        }

        /*
        protected bool existPerson()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();
            comm = new SqlCommand("Select * from Person where Name like '@Name' and Surname like '@Surname' ", conn);
            comm.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            comm.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
            reader = comm.ExecuteReader();
            if(reader.Read())
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        */
        protected void btnAddSubjectClick(object sender, EventArgs e)
        {
            bool flag = true;
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);


            try
            {
                conn.Open();
                comm = new SqlCommand("addSubjectProc", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@subject", txtSubject.Text.Trim());
                comm.ExecuteNonQuery();
            }
            catch
            {
                //Response.Write("Bir hata oluştu");
                flag = false;
                lblErrorSubject.Text = "Ekleme başarısız.";
            }
            finally
            {
                if (flag)
                    lblSuccesSubject.Text = "Konu başarıyla eklendi.";
                conn.Close();
            }
        }

        protected void btnDeleteSubjectClick(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@subject", txtSubject.Text.Trim());
                comm = new SqlCommand("Delete from Subject where SubjectName like @subject", conn);
                comm.Parameters.Add(param);
                comm.ExecuteNonQuery();
            }
            catch
            {
                lblErrorSubject.Text = "Bu konu kullanıldığı için silinemez ! ! !";
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