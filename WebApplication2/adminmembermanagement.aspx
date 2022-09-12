<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="WebApplication2.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
    </script>
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
                            <h3>Member Details</h3>
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
                           <label>Member Id</label>
                         <div class="form-group">
                             <div class="input-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="member id"></asp:TextBox>
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
                         <label>Account Status</label>
                         <div class="form-group">
                              <div class="input-group">
                                   <asp:TextBox CssClass="form-control mr-1" ID="TextBox8" runat="server" placeholder="account status" ReadOnly="True"></asp:TextBox>
                                  <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success mr-1" OnClick="LinkButton1_Click"><i class=" fas fa-check-circle"></i></asp:LinkButton>
                                  <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-warning mr-1" OnClick="LinkButton2_Click"><i class=" far fa-pause-circle"></i></asp:LinkButton>
                                  <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-danger mr-1" OnClick="LinkButton3_Click"><i class=" fas fa-times-circle"></i></asp:LinkButton>


                             </div>

                        </div>
                     </div>
                      
                

                  </div>

                     <div class="row">

                         <div class="col-md-3">
                         <label>DOB</label>
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

                     <div class="row">

                         <div class="col-md-4">
                         <label>State</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="state" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                                          
                      <div class="col-md-4">
                         <label>City</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="city" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>

                      <div class="col-md-4">
                         <label>Pincode</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="pincode" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                    

                  </div>

                      <div class="row">
                   
                        <div class="col-md-12">
                         <label>Full Postal Address</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="end date" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                          </div>
                        </div>
                    

                  </div>



                
                    <div class="row">

                        <div class="col-8 mx-auto">
                            <asp:Button ID="Button3" CssClass="btn btn-lg btn-block btn-danger" runat="server" Text="Delete UserPermanently" OnClick="Button3_Click" />
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
                            <h3>Members List</h3>
                        </center>
                     </div>
                  </div>

                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                     </div>
                    
                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hostelDBConnectionString4 %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                        <a href="adminmembermanagement.aspx">adminmembermanagement.aspx</a><div class="col">
                            <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server"  DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="member_id">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="ID" SortExpression="member_id" ReadOnly="True" />
                                    <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                    <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                    <asp:BoundField DataField="account_status" HeaderText="account_status" SortExpression="account_status" />
                                    <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                                    <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                                    <asp:BoundField DataField="pincode" HeaderText="pincode" SortExpression="pincode" />
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
