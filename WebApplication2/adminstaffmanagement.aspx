<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminstaffmanagement.aspx.cs" Inherits="WebApplication2.adminstaffmanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container" >
        <div class="row" >
            <div class="col-md-5 ">
                <div class="card" >
                    <div class="card-body" >
              

                   <div class="row">
                     <div class="col">
                        <center>
                            <h3>Staff Details</h3>
                        </center>
                     </div>
                  </div>
                   
                   <div class="row">
                        <div class="col">
                        <center>
                           <img width="100px" src="imgs/writer.png"/>
                        </center>
                        </div>
                     </div>
                   
                     <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                     </div>
                      

                       
                     
                   <div class="row">
                     <div class="col-md-4">
                           <label>Staff Id</label>
                         <div class="form-group">
                             <div class="input-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="staff id"></asp:TextBox>
                                    <asp:Button ID="Button4" class="btn btn-primary"  runat="server" Text="Go" OnClick="Button4_Click"/>
                             </div>
                        

                        </div>
                     </div>
                      <div class="col-md-8">
                         <label>Staff Name</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="staff name"></asp:TextBox>
                        </div>
                     </div>

                        <div class="col-md-12">
                         <label>Staff Job</label>
                         <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="staff job"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                
                    <div class="row">
                        <div class="col-4">
                            <asp:Button ID="Button1" CssClass="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" />
                        </div>

                        <div class="col-4">
                            <asp:Button ID="Button2" CssClass="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button2_Click" />
                        </div>

                        <div class="col-4">
                            <asp:Button ID="Button3" CssClass="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button3_Click" />
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
                            <h3>Staff List</h3>
                        </center>
                     </div>
                  </div>

                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                     </div>
                    
                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hostelDBConnectionString %>" SelectCommand="SELECT * FROM [staff_master_tbl]" ></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" class=" table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="staff_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                   
                                    <asp:BoundField DataField="staff_id" HeaderText="Staff ID" ReadOnly="True" SortExpression="staff_id" />
                                    <asp:BoundField DataField="staff_name" HeaderText="Staff Name" SortExpression="staff_name" />
                                    <asp:BoundField DataField="staff_work" HeaderText="Work" SortExpression="staff_work" />
                                   
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
