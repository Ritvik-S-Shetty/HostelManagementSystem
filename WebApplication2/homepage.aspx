<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApplication2.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #im1{
            height:700px;
        }
        #im2{
            height:300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="imgs/hostel.jpg" class="img-fluid w-100" id="im1" />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                   <center>
                        <h2>Our features</h2>
                        <p><b>Our 3 primary features</b></p>
                   </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/roomsavailable.jpg" />
                    <h4>Digital Room Booking</h4>
                    <p class="text-justify">e 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                  </center>
                </div>

                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/searchrooms.jpg" />
                    <h4>Search Rooms</h4>
                    <p class="text-justify">e 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                  </center>
                </div>

                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/defaulters-list.png" />
                    <h4>Defaulters List</h4>
                    <p class="text-justify">e 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                  </center>
                </div>

            </div>
        </div>

    </section>


    <section>
          <img src="imgs/hostelbody.jpg" id="im2" class="img-fluid w-100" />
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                   <center>
                        <h2>Our Process</h2>
                        <p><b>We have a simple 3 Step Process</b></p>
                   </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/sign-up.png" />
                    <h4>Signup</h4>
                    <p class="text-justify">e 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                  </center>
                </div>

                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/roomsavailable.jpg" />
                    <h4>Search Rooms</h4>
                    <p class="text-justify">e 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                  </center>
                </div>

                <div class="col-md-4">
                    
                    <center>
                    <img width="150px" src="imgs/visitus.png" />
                    <h4>Visit Us</h4>
                    <p class="text-justify">e 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                  </center>
                </div>

            </div>
        </div>

    </section>
</asp:Content>
