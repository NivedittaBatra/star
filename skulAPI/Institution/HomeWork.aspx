<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Institution/Site1.Master" AutoEventWireup="true" CodeBehind="HomeWork.aspx.cs" Inherits="skulAPI.Institution.HomeWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- Wide card with share menu button -->
    <style>
        .demo-card-wide.mdl-card {
            width: 512px;
        }

        .demo-card-wide > .mdl-card__title {
            color: #fff;
        }

        .demo-card-wide > .mdl-card__menu {
            color: #fff;
        }
    </style>

    <div class="demo-card-wide mdl-card mdl-shadow--2dp">
        <div class="mdl-card__supporting-text">
            <div>
                <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="classes_SelectedIndexChanged" ID="classes"></asp:DropDownList>
            </div>
            <h5 id="homeWork" runat="server"></h5>
        </div>
    </div>
    <div class="demo-card-wide mdl-card mdl-shadow--2dp">
        <div class="mdl-card__supporting-text">
            <div>
                <h5 id="class_" runat="server" style="margin:3px"></h5>
            <h6 id="date_" runat="server" style="margin:0;font-size:14px">Today</h6>
                <div class="mdl-textfield mdl-js-textfield" style="width: 460px">
                    <textarea class="mdl-textfield__input" rows="15" id="detail" runat="server"></textarea>
                    <label class="mdl-textfield__label" for="detail">Enter Homework Here...</label>
                </div>

            </div>
            <div class="mdl-card__actions">
                <asp:LinkButton runat="server" ID="setHW" OnClick="setHW_Click" CssClass="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Give Homework
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
