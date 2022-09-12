<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rooms.aspx.cs" Inherits="WebApplication2.rooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" >
        <div class="row" >
            <div class="col-md-8 mx-auto">
                <div class="card" >
                    <div class="card-body" >
                      <div class="row">
                     <div class="col">
                        <center>
                           <img width="80px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <center>
                            <h3>Room Booking</h3>
                        </center>
                     </div>
                  </div>
                       
                     
                        <div class="row">
                     <div class="col-md-6">
                           <label>Full Name</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Fullname"></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-6">
                         <label>Student Id</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Student Id"></asp:TextBox>
                        </div>
                     </div>
                  </div>


                   <div class="row">
                     <div class="col-md-6">
                           <label>Contact No</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="contact number" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>

                      <div class="col-md-6">
                         <label>Email ID</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="email" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                        
                   <div class="row">
                     <div class="col-md-12">
                           <label>Select Room</label>
                         <div class="form-group">
                           <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                              <asp:ListItem Text="Select" Value="" />
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                             
                             </asp:DropDownList>
                        </div>
                     </div>
                  </div>

                   <div class="row">

                       <div class="col-md-3">
                        </div>
                       <div class="col-md-6">
                           <asp:Button ID="Button2" class="btn btn-danger btn-block" runat="server" Text="Payment" OnClick="Button2_Click" />
                        </div>
                         <div class="col-md-3">
                        </div>

                   </div>
                       
                        <br />
                   <div class="row">
                     <div class="col">
                        <div class="form-group">
                            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Book" OnClick="Button1_Click" />
                        </div>

                     </div>
                  </div>



             </div>
          </div>
                 
                <a href="homepage.aspx">Back to Home</a>
                <br />
                <br />
               
            </div>

    </div>
    </div>
</asp:Content>
