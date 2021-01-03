<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="SE_307_Project.AddPage" %>

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
            <a class="active" href="AddPage.aspx">Veri ekle/sil</a>
            <a href="UpdatePage.aspx">Veri güncelleme</a>   
        </div>

        <table class="tableAdd">
            <tr>
                <td>
                    <h3>Kişi ekleme veya silme </h3>
                    <asp:TextBox ID="txtName" runat="server" CssClass="hidden" placeholder="İsim" style="width:50px; height:20px;"></asp:TextBox>
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="hidden" placeholder="Soy İsim" style="width:70px; height:20px;"></asp:TextBox>
                    <asp:DropDownList ID="ddlPerson" runat="server" style="height:20px;">
                        <asp:ListItem value="1">--Görev seçiniz--</asp:ListItem>
                        <asp:ListItem value="2">Yazar</asp:ListItem>
                        <asp:ListItem value="3">Baş Danışman</asp:ListItem>
                        <asp:ListItem value="4">Yardımcı Danışman</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnAddPerson" runat="server" OnClick="btnAddPersonClick" Text="Ekle" style="width:50px; height:20px;"></asp:Button>
                    <asp:Button ID="btnDeletePerson" runat="server" OnClick="btnDeletePersonClick" Text="Sil" style="width:50px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblsuccesPerson" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="lblfailPerson" runat="server" ForeColor="Red" ></asp:Label>
                </td>
            </tr>

            <tr>
                  <td>
                    <h3>Üniversite ekleme veya silme </h3>
                    <asp:TextBox ID="txtUniName" runat="server" CssClass="hidden" placeholder="Üniversite Adı" style="width:100px; height:20px;"></asp:TextBox>
                    <asp:TextBox ID="txtLocation" runat="server" CssClass="hidden" placeholder="Konumu" style="width:70px; height:20px;"></asp:TextBox>
                    <asp:Button ID="btnAddUni" runat="server" Text="Ekle" AutoPostBack="True" OnClick="btnAddUniClick" style="width:50px; height:20px;"></asp:Button>
                    <asp:Button ID="btnDeleteUni" runat="server" Text="Sil" AutoPostBack="True" OnClick="btnDeleteUniClick" style="width:50px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblsuccesUni" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="lblfailUni" runat="server" ForeColor="Red" ></asp:Label>
                </td>
            </tr>

            <tr>
                  <td>
                    <h3>Enstitü ekleme veya silme </h3>
                    <asp:DropDownList ID="ddlUni" runat="server"  style="height:30px;"></asp:DropDownList>
                    <asp:TextBox ID="txtEns" runat="server" CssClass="hidden" placeholder="Enstitü Adı" style="width:150px; height:20px;"></asp:TextBox>
                    <asp:Button ID="btnAddEnst" runat="server" Text="Ekle"  OnClick="btnAddEnstClick" style="width:50px; height:20px;"></asp:Button>
                    <asp:Button ID="btnDeleteEnst" runat="server" Text="Sil" AutoPostBack="True" OnClick="btnDeleteEnstClick" style="width:50px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblsuccesEnst" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="lblfailEnst" runat="server"  ForeColor="Red" ></asp:Label>
                </td>
            </tr>

             <tr>
                  <td>
                    <h3>Dil ekleme veya silme </h3>
                    <asp:TextBox ID="txtLang" runat="server" CssClass="hidden" placeholder="Dil" style="width:50px; height:20px;"></asp:TextBox>
                    <asp:Button ID="btnAddLang" runat="server" Text="Ekle" OnClick="btnAddLangClick" style="width:50px; height:20px;"></asp:Button>
                    <asp:Button ID="btnDeleteLang" runat="server" Text="Sil" OnClick="btnDeleteLangClick" style="width:50px; height:20px;"></asp:Button>
                    <asp:Label ID ="lblsuccesLang" runat="server" ForeColor="Green" ></asp:Label>
                    <asp:Label ID ="lblfailLang" runat="server"  ForeColor="Red" ></asp:Label>
                </td>
            </tr>

            <tr>
                    <td>
                        <h3>Konu Ekleme veya silme</h3>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="hidden" placeholder="Konu" style="width:150px; height:20px;"></asp:TextBox>
                        <asp:Button ID="btnSubject" runat="server" Text="Ekle"  OnClick="btnAddSubjectClick" style="width:50px; height:20px;"></asp:Button>
                        <asp:Button ID="btnDeleteSubject" runat="server" Text="Sil" OnClick="btnDeleteSubjectClick" style="width:50px; height:20px;"></asp:Button>
                        <asp:Label ID ="lblSuccesSubject" runat="server" ForeColor="Green" ></asp:Label>
                        <asp:Label ID ="lblErrorSubject" runat="server"  ForeColor="Red" ></asp:Label>
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
