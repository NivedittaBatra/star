<%@ Page Title="" Language="C#" MasterPageFile="~/Institution/Site1.Master" AutoEventWireup="true" CodeBehind="Classes.aspx.cs" Inherits="skulAPI.Institution.Classes" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
      <table class="mdl-data-table mdl-js-data-table mdl-shadow--2dp" style="float: left;margin:25px">
        <thead>
            <tr>
                <th class="mdl-data-table__cell--non-numeric">Standard</th>
                <th>Section</th>
            </tr>
        </thead>
        <tbody id="classTable" runat="server">
        </tbody>
    </table>
     <style>
        .demo-card-wide.mdl-card {
            width: 512px;
        }

        .demo-card-wide > .mdl-card__title {
            color: #fff;
            height: 176px;
        }

        .demo-card-wide > .mdl-card__menu {
            color: #fff;
        }
    </style>

    <div class="demo-card-wide mdl-card mdl-shadow--2dp" style="float:left">
        <div class="mdl-card__supporting-text">
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="standard" runat="server" />
                <label class="mdl-textfield__label" for="name">Standard...</label>
            </div>
            <br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="section" runat="server"/>
                <label class="mdl-textfield__label" for="admnNo">Section...</label>
            </div>
        </div>
        <div class="mdl-card__actions mdl-card--border">
            <asp:Button runat="server" ID="addClass" OnClick="addClass_Click" CssClass="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect" Text="Add CLass">
            </asp:Button>
        </div>
    </div>
</asp:Content>
