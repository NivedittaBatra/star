<%@ Page Title="" Language="C#" MasterPageFile="~/StudentsPage/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="skulAPI.StudentsPage._default" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #body_days_txt {
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <table class="mdl-data-table mdl-js-data-table mdl-shadow--2dp" style="float: left; margin-top: 25px;">
        <thead>
            <tr>
                <th colspan="2"><b style="float: left; font-size: 16px">Attendance</b></th>
            </tr>
            <tr>
                <th>
                    <asp:TextBox ID="days_txt" AutoPostBack="false" Text="5" runat="server" /></th>
                <th>
                    <asp:Button ID="changeDays" Text="Submit" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--colored" OnClick="changeDays_Click" runat="server" /></th>
            </tr>
            <tr>
                <th class="mdl-data-table__cell--non-numeric">Date</th>
                <th>Attendance</th>
            </tr>
        </thead>
        <tbody runat="server" id="attList">
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
            background: url('../assets/demos/welcome_card.jpg') center / cover;
        }

        .demo-card-wide > .mdl-card__menu {
            color: #fff;
        }

        #body_getHw {
            float: right;
        }
    </style>

    <div class="demo-card-wide mdl-card mdl-shadow--2dp" style="float: left;">
        <div class="mdl-card__supporting-text">
            <input type="date" id="getDate" runat="server" /><asp:LinkButton ID="getHw" OnClick="getHw_Click" runat="server" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--colored">Get Homework</asp:LinkButton><br />
            <div runat="server" style="margin-top: 25px;" id="hw_txt">dsfbmdngbskjd</div>
        </div>
    </div>
    <table class="mdl-data-table mdl-js-data-table mdl-shadow--2dp" style="margin:25px;float:left">
        <thead>
            <tr>
                <th>Upcoming events</th>
                <th></th>
            </tr>
            <tr>
                <th>Event</th>
                <th>Date</th>
            </tr>
        </thead>
        <tbody id="eventsList" runat="server">
        </tbody>
    </table>
</asp:Content>
