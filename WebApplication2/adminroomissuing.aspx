<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminroomissuing.aspx.cs" Inherits="WebApplication2.adminroomissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div class="container-fluid" >
        <div class="row" >
            <div class="col-md-5 ">
                <div class="card" >
                    <div class="card-body" >
              

                   <div class="row">
                     <div class="col">
                        <center>
                            <h3>Alloting Details</h3>
                        </center>
                     </div>
                  </div>
                   
                   <div class="row">
                        <div class="col">
                        <center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                        </div>
                     </div>
                   
                   <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                     </div>
                      

                       
                     
                   <div class="row">

                        <div class="col-md-3">
                           <label>Student Id</label>
                         <div class="form-group">
                             <div class="input-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="student id"></asp:TextBox>
                                   <asp:Button ID="LinkButton4" class="btn btn-primary"  runat="server" Text="Go" OnClick="LinkButton4_Click" />

                             </div>
                        </div>
                     </div> 
                     
                      <div class="col-md-4">
                         <label>Full Name</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Full name"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col-md-5">
                         <label>Room Status</label>
                         <div class="form-group">
                              <div class="input-group">
                                   <asp:TextBox CssClass="form-control mr-1" ID="TextBox8" runat="server" placeholder="account status" ReadOnly="True"></asp:TextBox>
                                  <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success mr-1" OnClick="LinkButton1_Click"><i class=" fas fa-check-circle"></i></asp:LinkButton>
                                  <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-warning mr-1" OnClick="LinkButton2_Click"><i class=" far fa-pause-circle"></i></asp:LinkButton>
                                  <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-danger mr-1" OnClick="LinkButton3_Click"><i class=" far fa-pause-circle"></i></asp:LinkButton>
                                 
                                 


                             </div>

                        </div>
                     </div>
                      
                

                  </div>

                     <div class="row">

                         <div class="col-md-3">
                             Room&nbsp;
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="DOB" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                                          
                      <div class="col-md-4">
                         <label>Contact Number</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="contact number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>

                      <div class="col-md-5">
                         <label>Email ID</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                    

                  </div>


                
                       





             </div>
          </div>
                 
                <a href="homepage.aspx">Back to Home</a>
                <br />
                <br />
               
            </div>

            <div class="col-md-7" >

              <div class="card" >
                <div class="card-body" >
                

                   <div class="row">
                     <div class="col">
                        <center>
                            <h3>Details</h3>
                        </center>
                     </div>
                  </div>

                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                     </div>
                    
                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hostelDBConnectionString5 %>" SelectCommand="SELECT * FROM [roombooking_tbl]" ></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" DataSourceID="SqlDataSource1" >
                                <Columns>
                                   
                                    <asp:BoundField DataField="student_id" HeaderText="ID" ReadOnly="True" SortExpression="student_id" />
                                    <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                    <asp:BoundField DataField="contact_no" HeaderText="Contact Number" SortExpression="contact_no" />
                                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                    <asp:BoundField DataField="room" HeaderText="Room" SortExpression="room" />
                                    <asp:BoundField DataField="room_status" HeaderText="Room Status" SortExpression="room_status" />
                                    <asp:BoundField DataField="payment" HeaderText="Payment" SortExpression="payment" />
                                   
                                </Columns>
                               
                            </asp:GridView>
                        </div>
                     </div>
             </div>
          </div>


            </div>

    </div>
    </div>


</asp:Content>
