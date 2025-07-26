<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LegacyWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h3>Add To Session.</h3>
        <div>
            <p>Add Session Message:
                <asp:TextBox ID="SessionTextBox" runat="server" /></p>
            <asp:Button ID="SubmitSessionButton" runat="server" Text="Submit" OnClick="SubmitSessionButton_Click" />
        </div>
    </main>

</asp:Content>
