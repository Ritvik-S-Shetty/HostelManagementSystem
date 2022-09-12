<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminroominventory.aspx.cs" Inherits="WebApplication2.adminroominventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
       <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });

       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();

               reader.onload = function (e) {
                   $('#imgview').attr('src', e.target.result);
               };

               reader.readAsDataURL(input.files[0]);
           }
       }

       </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Room Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" height="150px" width="100px" src="imgs/visitus.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload onchange="readURL(this)" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>Room ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Room Id"></asp:TextBox>
                              <asp:Button class=" form-control btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click"></asp:Button>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9">
                        <label>Room Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Room Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-5">
                        <label>Type</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                         
                               <asp:ListItem Text="Single Non_AC" Value="Single NonAC" /> 
                               <asp:ListItem Text="Single AC" Value="Single AC" />
                           </asp:DropDownList>
                        </div>
                     
                     </div>
                      <div class="col-4">
                        <label>Room Status</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Room Status"></asp:TextBox>
                        </div>
                     </div>
                    
                     <div class="col-md-7">
                        <label>Equipments</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Fan" Value="Fan" />
                              <asp:ListItem Text="Light" Value="Light" />
                              <asp:ListItem Text="AC" Value="AC" />
                              <asp:ListItem Text="Table" Value="Table" />
                              <asp:ListItem Text="Chair" Value="Chair" />
                               <asp:ListItem Text="Bed" Value="Bed" />

                           </asp:ListBox>
                        </div>
                     </div>
                  </div>
                 
               
                  <div class="row">
                     <div class="col-12">
                        <label>Room Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Room Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Room List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">

                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hostelDBConnectionString2 %>" SelectCommand="SELECT * FROM [room_master_tblnew]"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="room_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="room_id" HeaderText="Room ID" ReadOnly="True" SortExpression="room_id" >
                                
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="room_name" HeaderText="Room Name" SortExpression="room_name" />
                                <asp:BoundField DataField="equipments" HeaderText="Equipments" SortExpression="equipments" />
                                <asp:BoundField DataField="type" HeaderText="Room Type" SortExpression="type" />
                                <asp:BoundField DataField="room_status" HeaderText="Status" SortExpression="room_status" />
                                
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
