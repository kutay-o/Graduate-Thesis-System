<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submit.aspx.cs" Inherits="WebApplication2.WebForm1" %>

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
            <a class="active" href="Submit.aspx">Tez Kayıt</a>   
            <a href="AddPage.aspx">Veri ekle/sil</a>  
            <a href="UpdatePage.aspx">Veri güncelleme</a>    
            </div>

        <div class="addClass">
            <asp:HiddenField ID="hfPersonID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Yazar Adı" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtfirstname" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Yazar Soyadı" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtlastname" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Baş Danışman Adı" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtsupervisor" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Baş Danışman Soyadı" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtsupervisorlastname" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Yardımcı Danışman Adı(varsa)" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtco_supervisor" runat="server" />
                    </td>
                </tr>
                   <tr>
                    <td>
                        <asp:Label Text="Yardımcı Danışman Soyadı(varsa)" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtco_suplastname" runat="server" />
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label Text="Özet" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtabstract" runat="server" TextMode="MultiLine" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Başlık" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txttitle" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Dil" runat="server" />
                    </td>
                    <td colspan="2"> 
                         <asp:DropDownList ID="ddllanguage" runat="server"></asp:DropDownList>
                        
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                                 <tr>
                    <td>
                        <asp:Label Text="Üniversite" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:DropDownList ID="ddluniversity" runat="server" OnSelectedIndexChanged="ddluniSelected" AutoPostBack="true" ></asp:DropDownList>
               
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Enstitü" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:DropDownList ID="ddlinst" runat="server">
                        <asp:ListItem value="-1">--Üniversite Seçiniz--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
           
                 <tr>
                    <td>
                        <asp:Label Text="Sayfa Sayısı" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtnumberofpages" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Tür" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txttype" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Yıl" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtyear" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Tez Numarası" runat="server" />
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtTezNo" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text=" Anahtar(lar) giriniz (!Başında '#' işareti ile giriniz)" runat="server" />
                       
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtKey" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>


                <tr>
                    <td>
                        <asp:Label Text=" Konu(lar) Seçiniz" runat="server" />
                       
                    </td>
                    <td colspan="2"> 
                        <asp:ListBox ID="lblSubject" runat="server" Width="250px" SelectionMode="multiple"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Button Text="Kaydet" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                        <asp:Button Text="Temizle" ID="btnClean" runat="server" OnClick="btnClean_Click" style="width:100px;" />
                    </td>
                </tr>
                 <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                
                
            </table>
        </div>
    </form>
</body>
</html>