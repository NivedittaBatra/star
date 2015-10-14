<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Institution/Site1.Master" AutoEventWireup="true" CodeBehind="MarkAttendanceForStaff.aspx.cs" Inherits="skulAPI.Institution.MarkAttendanceForStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            margin: 25px;
            float: left;
        }#body_calcAtt{position:absolute;right:30px;bottom:30px;}
    </style>
    <script>
        $(document).ready(function () {
            $("#body_calcAtt").on("click", function () {
                var elements = $(".is-selected");
                var l = elements.length;
                $("#body_KonKonPresent").val("");
                for (var i = 0; i < l; ++i) {
                    $("#body_KonKonPresent").val($("#body_KonKonPresent").val() + "~" + $(elements[i]).attr("name"));
                }
                //$("#body_KonKosnPresent").val($("#body_KonKosnPresent").val() + "~" + $(this).attr("name"));
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <table class="mdl-data-table mdl-js-data-table mdl-data-table--selectable mdl-shadow--2dp">
        <thead>
            <tr>
                <th class="mdl-data-table__cell--non-numeric">Name</th>
                <th>Contact</th>
                <th>Subject</th>
            </tr>
        </thead>
        <tbody id="stuTable" runat="server">
        </tbody>
    </table>
    <asp:LinkButton ID="calcAtt" OnClick="calcAtt_Click" runat="server" CssClass="mdl-button mdl-js-button mdl-button--fab mdl-button--colored">
  <i class="material-icons">add</i>
    </asp:LinkButton>
    <input type="text" id="KonKonPresent" runat="server" style="display: none" />
</asp:Content>
