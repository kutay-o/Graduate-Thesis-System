using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_307_Project
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillLanguage();
                fillUniversity();
            }
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
                ddlLang.DataSource = reader;
                ddlLang.DataValueField = "LanguageID";
                ddlLang.DataTextField = "Language";
                ddlLang.DataBind();
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
            ddlLang.Items.Insert(0, new ListItem("Dil seçiniz", "0"));




        }

        private void fillUniversity()
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

        private void fillInstitute()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT InstituteID,Name FROM Institute where UniversityID='" + ddlUni.SelectedValue +"'",conn);

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


        protected void ddlUni_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillInstitute();
            
        }

     

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            StringBuilder sbCommand = new StringBuilder("select Thesis.No as Numara,Person.Name +' '+Person.Surname as Yazar,Thesis.Year as Yıl,Thesis.Title as Başlık,Thesis.Type as Tür,Thesis.Abstract as Özet from Thesis left outer join Author on Author.AuthorID = Thesis.AuthorID left outer join Person on Author.PersonID = Person.PersonID where 1 = 1");
            if(TextBoxWord.Text.Trim() != "" && ddlDomain.SelectedValue != "0")
            {
                if(ddlDomain.SelectedValue == "1")
                {
                    sbCommand.Append("and Title like '%'+@Title+'%'");
                    SqlParameter param = new SqlParameter("@Title", TextBoxWord.Text);
                    cmd.Parameters.Add(param);

                }
                else if(ddlDomain.SelectedValue == "2")
                {
                    sbCommand.Append("and Thesis.AuthorID in (Select AuthorID from Author where Author.PersonID in " +
                        "                                     (Select PersonID from Person where Person.Name like '%' + @Name + '%' or Person.Surname like '%' + @Surname + '%'))");
                    //select * from diye çağırmayı en başta yapıyorum burasının düzenlenmesi gerek
                    string[] str = TextBoxWord.Text.Split(' ');
                    SqlParameter param = new SqlParameter("@Name", str[0]);
                    SqlParameter param1 = new SqlParameter("@Surname", str[str.Length - 1]);
                    cmd.Parameters.Add(param);
                    cmd.Parameters.Add(param1);
                }
                else if(ddlDomain.SelectedValue == "3")
                {
                    sbCommand.Append("and Thesis.SupervizorID in (Select SupervisorID from Supervisor where Supervisor.PersonID in" +
                        "                                             (Select PersonID from Person where Person.Name like '%' + @Vizor + '%')) or Thesis.Co_SupervizorID in " +
                        "                                             (Select Co_SupervisorID from Co_Supervisor where Co_Supervisor.PersonID in" +
                        "                                             (Select PersonID from Person where Person.Name like '%' + @Vizor + '%'))");
                    SqlParameter param = new SqlParameter("@Vizor", TextBoxWord.Text);
                    cmd.Parameters.Add(param);
                }
                else if(ddlDomain.SelectedValue == "4")
                {
                    sbCommand.Append("and ThesisID in (Select ThesisID from EnrollSubject where SubjectID = (Select SubjectID from Subject where SubjectName like '%'+@subject+'%'))");
                    SqlParameter param = new SqlParameter("@subject", TextBoxWord.Text.Trim());
                    cmd.Parameters.Add(param);
                }
                else if(ddlDomain.SelectedValue == "5")
                {
                    sbCommand.Append("and Abstract like '%'+@abstract+'%'");
                    SqlParameter param = new SqlParameter("@abstract", TextBoxWord.Text);
                    cmd.Parameters.Add(param);
                }
            }
            if(ddlLang.SelectedValue != "0")
            {
                sbCommand.Append("and Thesis.LanguageID = (Select LanguageID from Languages where Languages.LanguageID = @lang)");
                SqlParameter param = new SqlParameter("@lang", Convert.ToInt32(ddlLang.SelectedValue));
                cmd.Parameters.Add(param);
            }
            if(ddlType.SelectedValue != "0")
            {
                sbCommand.Append("and Thesis.Type like @type ");
                SqlParameter param;
                switch (ddlType.SelectedValue)
                {
                    case "1":
                        param = new SqlParameter("@type", "Yüksek Lisans");
                        break;
                    case "2":
                        param = new SqlParameter("@type", "Doktora");
                        break;
                    case "3":
                        param = new SqlParameter("@type", "Tıpta Uzmanlık");
                        break;
                    case "4":
                        param = new SqlParameter("@type", "Sanatta Yeterlilik");
                        break;
                    case "5":
                        param = new SqlParameter("@type", "Diş Hekimi Uzmanlık");
                        break;
                    default:
                        param = new SqlParameter("@type", "Tıpta Yan Dal Uzmanlık");
                        break;

                }
                
                cmd.Parameters.Add(param);
            }

            if(ddlUni.SelectedValue != "0")
            {
                sbCommand.Append("and Thesis.UniversityID = (Select UniversityID from University where University.UniversityID = @uni)");
                SqlParameter param = new SqlParameter("@uni", Convert.ToInt32(ddlUni.SelectedValue));
                cmd.Parameters.Add(param);

                if(ddlInst.SelectedValue != "-1")
                {
                    sbCommand.Append("and Thesis.InstitueID = (Select InstituteID from Institute where Institute.InstituteID = @inst)");
                    SqlParameter paramM = new SqlParameter("@inst", Convert.ToInt32(ddlInst.SelectedValue));
                    cmd.Parameters.Add(paramM);
                }


            }



            if(TextBoxYear.Text.Trim() != "")
            {
                sbCommand.Append("and Thesis.Year = @year");
                SqlParameter param = new SqlParameter("@year", Convert.ToInt32(TextBoxYear.Text));
                cmd.Parameters.Add(param);
            }




            cmd.CommandText = sbCommand.ToString();
            cmd.CommandType = CommandType.Text;

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            gvThesis.DataSource = rdr;
            gvThesis.DataBind();


        }

        protected void btnThesisDetails(object sender, EventArgs e)
        {
            int thesisNo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("thesisDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@No", thesisNo);
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                gvThesis.DataSource = rdr;
                gvThesis.DataBind(); ;
            }
            catch
            {
                Response.Write("Bir hata oluştu");
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnCleanClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

    }
}