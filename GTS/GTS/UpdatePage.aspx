<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="GTS.UpdatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yüksek Lisans Tez Sistemi</title>
    <link href="CSS/MainContent.css" rel="stylesheet" />
    <meta charset="UTF-8"/>
</head>
<body>
    <form id="form1" runat="server">
         <div class="header">
            <a href="Main.aspx">Arama</a>
            <a href="Submit.aspx">Tez Kayıt</a>   
            <a href="AddPage.aspx">Veri ekle/sil</a>  
            <a class="active" href="UpdatePage.aspx">Veri güncelleme</a>   
        </div>

         <table class="tableAdd">
            <tr>
                  <td>
                    <h3>Üniversite Güncelleme  </h3>
                    <asp:DropDownList ID="ddlUni" runat="server"  style="height:30px;"></asp:DropDownList>
                    <asp:TextBox ID="txtUni" runat="server" CssClass="hidden" placeholder="Üniversite Adı" style="width:150px; height:20px;"></asp:TextBox>
                    <asp:TextBox ID="txtLocation" runat="server" CssClass="hidden" placeholder="Konum" style="width:150px; height:20px;"></asp:TextBox>
                    <asp:Button ID="btnUpdateUni" runat="server" Text="Güncelle"  OnClick="btnUpdateUniClick" style="width:80px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblUpdateSuccesUni" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="lblfailEnst" runat="server"  ForeColor="Red" ></asp:Label>
                </td>
            </tr>

            <tr>
                  <td>
                    <h3>Enstitü Güncelleme  </h3>
                    <asp:DropDownList ID="ddlUniInst" runat="server" OnSelectedIndexChanged="selectedUni" AutoPostBack="True" style="height:30px;"></asp:DropDownList>
                    <asp:DropDownList ID="ddlInst" runat="server"  style="height:30px;" >
                        <asp:ListItem value="-1">--Üniversite Seçiniz--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtInst" runat="server" CssClass="hidden" placeholder="Enstitü Adı" style="width:150px; height:20px;"></asp:TextBox>
                    <asp:Button ID="btnUpdateInst" runat="server" Text="Güncelle"  OnClick="btnUpdateInstClick" style="width:80px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblUpdateSuccesInst" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="Label2" runat="server"  ForeColor="Red" ></asp:Label>
                </td>
            </tr>

           

            <tr>
                  <td>
                    <h3>Kişi Güncelleme  </h3>
                    <asp:DropDownList ID="ddlPerson" runat="server"  style="height:30px;"></asp:DropDownList>
                    <asp:TextBox ID="txtPersonName" runat="server" CssClass="hidden" placeholder="Kişi Adı" style="width:150px; height:20px;"></asp:TextBox>
                    <asp:TextBox ID="txtPersonSurname" runat="server" CssClass="hidden" placeholder="Kişi Soyadı" style="width:150px; height:20px;"></asp:TextBox>
                    <asp:Button ID="btnUpdatePerson" runat="server" Text="Güncelle"  OnClick="btnUpdatePersonClick" style="width:80px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblUpdateSuccesPerson" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="Label4" runat="server"  ForeColor="Red" ></asp:Label>
                </td>
            </tr>

            <tr>
                  <td>
                    <h3>Konu Güncelleme  </h3>
                    <asp:DropDownList ID="ddlSubject" runat="server"  style="height:30px;"></asp:DropDownList>
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="hidden" placeholder="Konu Adı" style="width:150px; height:20px;"></asp:TextBox>
                    <asp:Button ID="btnUpdateSubject" runat="server" Text="Güncelle"  OnClick="btnUpdateSubjectClick" style="width:80px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblUpdateSuccesSubject" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="Label6" runat="server"  ForeColor="Red" ></asp:Label>
                </td>
            </tr>

             <tr>
                  <td>
                    <h3>Sayfayı Yenile</h3>
                    <asp:Button ID="btnRefresh" runat="server" Text="&#8635;"  OnClick="btnRefreshClick" style="width:50px; height:20px;"></asp:Button>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>


