<%@ Page Title="" Language="C#" MasterPageFile="~/Institution/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="skulAPI.Institution._default1" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
                    <style>
                        .demo-card-event.mdl-card {
                            width: 256px;
                            height: 256px;
                            background: #3E4EB8;
                        }

                        .demo-card-event > .mdl-card__actions {
                            border-color: rgba(255, 255, 255, 0.2);
                        }

                        .demo-card-event > .mdl-card__title {
                            align-items: flex-start;
                        }

                            .demo-card-event > .mdl-card__title > h4 {
                                margin-top: 0;
                            }

                        .demo-card-event > .mdl-card__actions {
                            display: flex;
                            box-sizing: border-box;
                            align-items: center;
                        }

                            .demo-card-event > .mdl-card__title,
                            .demo-card-event > .mdl-card__actions,
                            .demo-card-event > .mdl-card__actions > .mdl-button {
                                color: #fff;
                            }
                    </style>

                    <div class="demo-card-event mdl-card mdl-shadow--2dp">
                        <div class="mdl-card__title mdl-card--expand">
                            <p style="line-height:50px;font-size:32px;"><span id="stuAtt" runat="server" style="font-size:60px">345</span><br />
                            Students</p>
                        </div>
                        <div class="mdl-card__actions mdl-card--border">
                            <a class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Attendance
                            </a>
                            <div class="mdl-layout-spacer"></div>
                            <i class="material-icons">person</i>
                        </div>
                    </div>
                    <div class="demo-card-event mdl-card mdl-shadow--2dp">
                        <div class="mdl-card__title mdl-card--expand">
                            <p style="line-height:50px;font-size:32px;"><span id="staAtt" runat="server" style="font-size:60px">345</span><br />
                            Staff</p>
                        </div>
                        <div class="mdl-card__actions mdl-card--border">
                            <a class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Attendance
                            </a>
                            <div class="mdl-layout-spacer"></div>
                            <i class="material-icons">person</i>
                        </div>
                    </div>
                    <div class="demo-card-event mdl-card mdl-shadow--2dp">
                        <div class="mdl-card__title mdl-card--expand">
                            <p style="line-height:50px;font-size:32px;"><span id="eventsCount" runat="server" style="font-size:60px">345</span><br />
                            Events</p>
                        </div>
                        <div class="mdl-card__actions mdl-card--border">
                            <a class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Events
                            </a>
                            <div class="mdl-layout-spacer"></div>
                            <i class="material-icons">event</i>
                        </div>
                    </div>
</asp:Content>
