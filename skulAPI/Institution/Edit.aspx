<%@ Page Title="" Language="C#" MasterPageFile="~/Institution/Site1.Master" Async="true" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="skulAPI.Institution.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <style>
        .demo-card-wide.mdl-card {
            width: 512px;
        }

        .demo-card-wide > .mdl-card__title {
            color: #fff;
            height: 176px;
            background: url('../assets/demos/welcome_card.jpg') center / cover;
        }

        .demo-card-wide > .mdl-card__menu {
            color: #fff;
        }
    </style>

    <div class="demo-card-wide mdl-card mdl-shadow--2dp">
        <div class="mdl-card__supporting-text">
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="name" runat="server" />
                <label class="mdl-textfield__label" for="name">Name</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="location" runat="server" />
                <label class="mdl-textfield__label" for="location">Location</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="contact" runat="server" />
                <label class="mdl-textfield__label" for="contact">Contact</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="email" runat="server" />
                <label class="mdl-textfield__label" for="email">Email</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <label class="mdl-textfield__label" for="pass">Password</label>
                <input class="mdl-textfield__input" type="text" id="pass" runat="server" />
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input class="mdl-textfield__input" type="text" id="pass2" runat="server"/>
                <label class="mdl-textfield__label" for="pass2">Confirm Password</label>
            </div>
        </div>
        <div class="mdl-card__actions mdl-card--border">
            <asp:LinkButton runat="server" ID="updateInsti" OnClick="updateInsti_Click" CssClass="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Update
            </asp:LinkButton>
        </div>
    </div>
</asp:Content>
