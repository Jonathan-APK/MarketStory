<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newsfeed.aspx.cs" Inherits="MarketStory.newsfeed" %>
<%@ Register Src="~/Controls/post.ascx" TagName="Post1" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <style type="text/css">
            <!--
            .drop-area {
                width: 100px;
                height: 25px;
                border: 1px solid #999;
                text-align: center;
                padding: 10px;
                cursor: pointer;
            }

            #thumbnail img {
                width: 100px;
                height: 100px;
                margin: 5px;
            }

            canvas {
                border: 1px solid red;
            }
        
            -->
        </style>

    </head>
    <body>

        <div class="divPost">
            <table class="table" align="center">
                <tr>
                    <td class="td" width="100%">
                        <asp:TextBox ID="textPost" runat="server" EnableViewState="false" Style="margin-top: 10px" Height="50px"
                            Width="554px" TextMode="MultiLine"></asp:TextBox>
                         <br />                       
                     
                      
                        
                        <p align="right" style="margin-top: 5px;">

                            <asp:ImageButton src="/Images/post.png" ID="btnPost" runat="server" OnClick="Button1_Click"/>
                        </p>


                        <uc1:Post1 ID="Post1" runat="server" />

                    </td>
                </tr>
            </table>
        </div>
        <div class="divborder">
        </div>
        <div class="divcontent">
        </div>

    </body>
    </html>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
