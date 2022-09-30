<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LibraryPenaltyCase.WebForm1" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="jumbotron">
        <h1>Kütüphane Sistemine Hoşgeldiniz</h1>
        <h2>Lütfen kitabınızı aldığınız tarihi seçiniz.</h2>
            <asp:Calendar ID="clAlimTarihi" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Ulkeler]"></asp:SqlDataSource>
    </div>
    <div class="jumbotron">
        <h2>Lütfen kitabınızı teslim ettiğiniz tarihi seçiniz</h2>
                <asp:Calendar ID="clTeslimTarihi" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
        
    </div>
    <div class="jumbotron">
        <h2>Lütfen ülkenizi seçiniz   
            <asp:DropDownList ID="ddlUlkeler" runat="server" DataSourceID="SqlDataSource1" DataTextField="UlkeAdi" DataValueField="UlkeAdi">
            </asp:DropDownList>
        </h2>
    </div>
    <div class="jumbotron">
        <asp:Button ID="btCezaHesapla" runat="server" Text="Ceza Hesapla" Height="45px" Width="124px" OnClick="btCezaHesapla_Click1" />
    </div>
    <div class="jumbotron">
         <h1>Sonuç</h1>
        <h2>Hesaplanan Gün Sayısı : 

            <asp:Label ID="lbGunSayisi" runat="server"></asp:Label>

        </h2>
        <h2>Hesaplanan Ceza Miktarı :

            <asp:Label ID="lbCezaMiktari" runat="server"></asp:Label>

        </h2>
    </div>
</asp:Content>
