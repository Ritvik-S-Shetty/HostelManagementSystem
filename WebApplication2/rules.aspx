<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rules.aspx.cs" Inherits="WebApplication2.rules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bg{
    background: url(elcarito-MHNjEBeLTgw-unsplash.jpg);
    height: 100vh;
    width: 100%;
    position: absolute;
    background-size: cover;
    filter: blur(5px);
    z-index: -1;
    opacity: 0.7;
    filter: brightness(75%);
}
.terms-box{
    max-width: 460px;
    background-color: rgb(83, 83, 83,0.1);
    color: #fff;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
    padding: 0 20px;
    height: 400px;
    overflow-y: auto;
    font-size: 14px;
}
.terms-text{
    padding: 0 20px;
    height: 400px;
    overflow-y: auto;
    font-size: 14;
    font-weight: 500;
    color: #111;
}
.terms-text::-webkit-scrollbar{
    width: 2px;
    background-color: #282828;
}
.terms-text::-webkit-scrollbar-thumb{
    background-color: #f1f1f1;
}
.terms-text h2{
    text-transform: uppercase;
}
.terms-text h4{
    font-size: 13px;
    text-align: center;
    padding: 0 40px;
}
.terms-box h4 span{
    color: rgb(245, 68, 68);
    text-transform: uppercase;
}
.buttons{
    display: flex;
    padding: 0 20px;
    justify-content: space-between;
    padding-bottom: 50px;
}
.btn{
    height: 50px;
    width: calc(50% - 6px);
    border: 0;
    border-radius: 6px;
    font-size: 19px;
    font-weight: 500;
    color: #fff;
    transition: .3s linear;
    cursor: pointer;
}
.red-btn{
    background-color: rgb(245, 68, 68);
}
.gray-btn{
    background-color: #282828;
}
.btn:hover{
    opacity: .6;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg"></div>
    <div class="terms-box container-fluid">
        <div class="terms-text">
            <h2>Terms And Conditions</h2>
            <p>Last Edit:9/09/2023</p>
            <p>Greetings User</p>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione magnam illo totam facilis in! Laboriosam
                a
                debitis tempore enim voluptas assumenda unde sint dignissimos sit repudiandae temporibus minima illo
                dolore
                cupiditate pariatur nisi odio delectus minus, corrupti quas! Ipsam beatae totam minus culpa
                exercitationem,
                inventore optio quia distinctio eaque perferendis.</p>

            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione magnam illo totam facilis in! Laboriosam
                a
                debitis tempore enim voluptas assumenda unde sint dignissimos sit repudiandae temporibus minima illo
                dolore
                cupiditate pariatur nisi odio delectus minus, corrupti quas! Ipsam beatae totam minus culpa
                exercitationem,
                inventore optio quia distinctio eaque perferendis.</p>

            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione magnam illo totam facilis in! Laboriosam
                a
                debitis tempore enim voluptas assumenda unde sint dignissimos sit repudiandae temporibus minima illo
                dolore
                cupiditate pariatur nisi odio delectus minus, corrupti quas! Ipsam beatae totam minus culpa
                exercitationem,
                inventore optio quia distinctio eaque perferendis.</p>

            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione magnam illo totam facilis in! Laboriosam
                a
                debitis tempore enim voluptas assumenda unde sint dignissimos sit repudiandae temporibus minima illo
                dolore
                cupiditate pariatur nisi odio delectus minus, corrupti quas! Ipsam beatae totam minus culpa
                exercitationem,
                inventore optio quia distinctio eaque perferendis.</p>

            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione magnam illo totam facilis in! Laboriosam
                a
                debitis tempore enim voluptas assumenda unde sint dignissimos sit repudiandae temporibus minima illo
                dolore
                cupiditate pariatur nisi odio delectus minus, corrupti quas! Ipsam beatae totam minus culpa
                exercitationem,
                inventore optio quia distinctio eaque perferendis.</p>
       
       <h4>I Agree To The <span> Terms And Conditions</span> And I Read The Privacy Notice</h4>
       <div class="buttons">
           <asp:Button ID="Button1" class="btn red-btn container-fluid" runat="server" Text="Accept" OnClick="Button1_Click" />
       </div>

            </div>
    </div>
    <div>
        <p></p>
    </div>
    <div>
        <p></p>
    </div>
<div>
    <p></p>
    </div>
<div>
    <p></p>   
    </div>
<div>
       
    </div>


</asp:Content>
