<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="WebApplication2.aboutus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .About-us {
	  width: 100%;
	  text-align: center;
	  background-color: #ccc;
	  margin-top: 30px;
	  margin-bottom: 30px;
	}
	#heading{
	  color: red;
	  font-size: 35px;
	}
	#test {
	  border-radius: 50%;
	}
	
	#para{
	  font-size: 20px;
	} 
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="About-us">
    <h1 id="heading"> About Us </h1>
    
	<img id="test" src="imgs/hostelicon.png">
	<p id="para">Our mission is to empower young Students to be the inventors and creators.</p>
	<hr>
	<p>In a world where so much is being done for technology and so little for the environment, education is not even a part of most discussions.</p>
    <p>We at Studytonight believe that by widening the reach of education, by making it freely available, so much can be achieved.</p>
    <p>And this journey started in 2013 when a young boy thought "wouldn't it be great, to have a website, with simple tutorials for programming languages, just like a friend would teach you!", and Studytonight was born.</p>
   <h3> follow us on </h3>
   <a href="#" class="fa fa-facebook"></a> 
   <a href="#" class="fa fa-twitter"></a> 
   <a href="#" class="fa fa-linkedin"></a> 
  </div>
</asp:Content>
