using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GTS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillUni();
                fillLanguage();
                fillSubject();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool flag = true;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("AddThesis", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    // sqlCmd.Parameters.AddWithValue("@ThesisID", Convert.ToInt32(hfPersonID.Value == "" ? "0" : hfPersonID.Value));
                    sqlCmd.Parameters.AddWithValue("@name", txtfirstname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@lastname", txtlastname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Title", txttitle.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@NumberofPage", Convert.ToInt32(txtnumberofpages.Text));
                    sqlCmd.Parameters.AddWithValue("@Year", Convert.ToInt32(txtyear.Text));
                    sqlCmd.Parameters.AddWithValue("@No", Convert.ToInt32(txtTezNo.Text));
                    sqlCmd.Parameters.AddWithValue("@Abstract", txtabstract.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Type", txttype.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@supervisorname", txtsupervisor.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@supervisorlastname", txtsupervisorlastname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@cosupervisorname", txtco_supervisor.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@cosupervisorlastname", txtco_suplastname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@uni", Convert.ToInt32(ddluniversity.SelectedValue));
                    sqlCmd.Parameters.AddWithValue("@ins", Convert.ToInt32(ddlinst.SelectedValue));
                    sqlCmd.Parameters.AddWithValue("@language", Convert.ToInt32(ddllanguage.SelectedValue));
                    sqlCmd.ExecuteNonQuery();
                }
                catch
                {
                    lblErrorMessage.Text = "Tez Eklenemedi";
                    flag = false;
                }
                if(flag)
                    lblSuccessMessage.Text = "Tez Eklendi";
                


               // lblSuccessMessage.Text = "Tez Eklendi";
            }
            foreach (ListItem li in lblSubject.Items)
            {
                if (li.Selected)
                {

                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("addSubject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subjectID", Convert.ToInt32(li.Value));
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            splitKeyBox();


        }
        protected void splitKeyBox()
        {
            String[] str = txtKey.Text.Split('#');
            
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            for (int i = 1; i < str.Length; ++i)
            {
                SqlCommand cmd = new SqlCommand("addKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", str[i]);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        protected void ddluniSelected(object sender, EventArgs e)
        {
         
                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader reader;
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);
                comm = new SqlCommand("SELECT InstituteID,Name FROM Institute where UniversityID='" + ddluniversity.SelectedValue + "'", conn);

                try
                {
                    conn.Open();
                    reader = comm.ExecuteReader();
                    ddlinst.DataSource = reader;
                    ddlinst.DataValueField = "InstituteID";
                    ddlinst.DataTextField = "Name";
                    ddlinst.DataBind();
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

        protected void FillUni()
        {

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT UniversityID,Name FROM University ", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                ddluniversity.DataSource = reader;
                ddluniversity.DataValueField = "UniversityID";
                ddluniversity.DataTextField = "Name";
                ddluniversity.DataBind();
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
            ddluniversity.Items.Insert(0, new ListItem("Üniversite seçiniz", "0"));

        }
        private void fillLanguage()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT LanguageID,Language FROM Languages", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                ddllanguage.DataSource = reader;
                ddllanguage.DataValueField = "LanguageID";
                ddllanguage.DataTextField = "Language";
                ddllanguage.DataBind();
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
            ddllanguage.Items.Insert(0, new ListItem("Dil seçiniz", "0"));
        }

        protected void fillSubject()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT SubjectID,SubjectName FROM Subject", conn);

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                lblSubject.DataSource = reader;
                lblSubject.DataValueField = "SubjectID";
                lblSubject.DataTextField = "SubjectName";
                lblSubject.DataBind();
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
    

        protected void btnClean_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
   
    }
}