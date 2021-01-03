<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="GTS.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yüksek Lisans Tez Sistemi</title>
    <link href="CSS/MainContent.css" rel="stylesheet" />
    <link href="CSS/List.css" rel="stylesheet" />
    <meta charset="UTF-8"/>

  

    </head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <a class="active" href="Main.aspx">Arama</a>
            <a href="Submit.aspx">Tez Kayıt</a>  
            <a href="AddPage.aspx">Veri ekle/sil</a>  
            <a href="UpdatePage.aspx">Veri güncelleme</a>   
        </div> 
        <div class="body">
            <table class="tableList"
            
                <tr>
                    <td>
                    <asp:TextBox ID="TextBoxWord" runat="server" CssClass="hidden" placeholder="Aranacak Kelime" style="height:30px;"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                    <asp:DropDownList ID="ddlDomain" runat="server" style="height:30px; width:150px;">
                        <asp:ListItem value="0">--Alan Seçiniz--</asp:ListItem>
                        <asp:ListItem value="1">Tez Başlığı</asp:ListItem>
                        <asp:ListItem value="2">Yazar</asp:ListItem>
                        <asp:ListItem value="3">Danışman</asp:ListItem>
                        <asp:ListItem value="4">Konu</asp:ListItem>
                        <asp:ListItem value="5">Özet</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                    <asp:DropDownList ID="ddlLang" runat="server" style="height:30px;">
                    </asp:DropDownList>
                    

                    <asp:DropDownList ID="ddlType" runat="server" style="height:30px; width:170px;">
                        <asp:ListItem value="0">--Tür Seçiniz--</asp:ListItem>
                        <asp:ListItem value="1">Yüksek Lisans</asp:ListItem>
                        <asp:ListItem value="2">Doktora</asp:ListItem>
                        <asp:ListItem value="3">Tıpta Uzmanlık</asp:ListItem>
                        <asp:ListItem value="4">Sanatta Yeterlilik</asp:ListItem>
                        <asp:ListItem value="5">Diş Hekimi Uzmanlık</asp:ListItem>
                        <asp:ListItem value="6">Tıpta Yan Dal Uzmanlık</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                    <asp:DropDownList ID="ddlUni" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUni_SelectedIndexChanged" style="height:30px;">
                    </asp:DropDownList>
                    </td>

                    <td>
                    <asp:DropDownList ID="ddlInst" runat="server" style="height:30px;">
                        <asp:ListItem value="-1">--Üniversite Seçiniz--</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                    <asp:TextBox ID="TextBoxYear" runat="server" CssClass="hidden" placeholder="Yıl" style="width:50px; height:20px;"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Ara" OnClick="btnSearch_Click"  style="width:55px; height:25px;"></asp:Button>
                        <asp:Button ID="btnClean" runat="server" Text="Temizle" OnClick="btnCleanClick" style="width:65px; height:25px;"></asp:Button>
                    </td>
                </tr>



                <tr>
                    <td>
                        <asp:Label ID="lblClean" runat="server" Forecolor="green"></asp:Label> 
                    </td>
                </tr>

          </table> 
            
            <asp:GridView ID="gvThesis" runat="server" AutoGenerateColumns="true" >   
                <Columns>
                    <asp:TemplateField>
                         <ItemTemplate>
                            <asp:LinkButton ID="Button1" runat="server" Text="Detay" CommandArgument='<%# Eval("Numara") %>' OnClick="btnThesisDetails"/>
                         </ItemTemplate>
                     </asp:TemplateField>
                </Columns>
            </asp:GridView>
          </div>
    </form>
        
</body>
</html>
