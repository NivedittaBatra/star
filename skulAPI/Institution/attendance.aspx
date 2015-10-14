<%@ Page Title="" Language="C#" MasterPageFile="~/Institution/Site1.Master" AutoEventWireup="true" CodeBehind="attendance.aspx.cs" Inherits="skulAPI.Institution.attendance" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/jquery.jqplot.min.css" rel="stylesheet" />
    <script src="../js/jquery.jqplot.min.js"></script>
    <script src="../js/jqplot.dateAxisRenderer.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <style>
        .demo-card-wide.mdl-card {
            width: 95%;
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
            <div id="chart1"></div>
        </div>
        <div class="mdl-card__actions mdl-card--border">
            <a href="MarkAttendance.aspx" class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Mark Attendance
            </a>
        </div>
        <div class="mdl-card__menu">
            <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect">
                <i class="material-icons">share</i>
            </button>
        </div>
    </div>
    <div class="demo-card-wide mdl-card mdl-shadow--2dp">
        <div class="mdl-card__supporting-text">
            <div id="chart2"></div>
            <!--Lorem ipsum dolor sit amet, consectetur adipiscing elit.
    Mauris sagittis pellentesque lacus eleifend lacinia...-->
        </div>
        <div class="mdl-card__actions mdl-card--border">
            <a href="MarkAttendanceForStaff.aspx" class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Mark Attendance
            </a>
        </div>
        <div class="mdl-card__menu">
            <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect">
                <i class="material-icons">share</i>
            </button>
        </div>
    </div>
</asp:Content>
