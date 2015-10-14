﻿<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Institution/Site1.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="skulAPI.Institution.staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <table class="mdl-data-table mdl-js-data-table mdl-shadow--2dp" style="float: left;margin:25px">
        <thead>
            <tr>
                <th class="mdl-data-table__cell--non-numeric">Name</th>
                <th>Subject</th>
                <th>Contact</th>
            </tr>
        </thead>
        <tbody id="stuTable" runat="server">
        </tbody>
    </table>
    <!-- Wide card with share menu button -->
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

    <div class="demo-card-wide mdl-card mdl-shadow--2dp" style="float:left;">
        <div class="mdl-card__supporting-text">
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="name" runat="server" />
                <label class="mdl-textfield__label" for="name">Name...</label>
            </div>
            <br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="contact" runat="server"/>
                <label class="mdl-textfield__label" for="contact">Contact No...</label>
            </div>
            <br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="address" runat="server"/>
                <label class="mdl-textfield__label" for="address">Adress...</label>
            </div>
            <br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="date" id="DOB" runat="server"/>
                <label class="mdl-textfield__label" for="DOB">Date Of Birth...</label>
            </div>
            <br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="email" runat="server"/>
                <label class="mdl-textfield__label" for="email">Email...</label>
            </div>
<br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="subject" runat="server"/>
                <label class="mdl-textfield__label" for="subject">Subject...</label>
            </div>

        </div>
        <div class="mdl-card__actions mdl-card--border">
            <asp:Button runat="server" OnClick="addStaff_Click" ID="addStaff" CssClass="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect" Text="Add Staff">
            </asp:Button>
        </div>
    </div>
</asp:Content>
