<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="DavidsStudentManager._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div>
     <div>
         First Name: <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
     </div>
     <div>
         Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
     </div>
     <div>
         <asp:Button ID="btnAdd" runat="server" Text="Add" />
     </div>
 </div>

<div>
    <asp:GridView ID="grdStudents" runat="server"></asp:GridView>
</div>

</asp:Content>
