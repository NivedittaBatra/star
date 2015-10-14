<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Institution/Site1.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="skulAPI.Institution.Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
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
        <div class="mdl-card__supporting-text" style="color:slategrey">
            <div>
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <input class="mdl-textfield__input" runat="server" type="text" id="title" />
                    <label class="mdl-textfield__label" for="title">Title...</label>
                </div>
                <input type="date" id="dateOfEvent" runat="server"/>
                <div class="mdl-textfield mdl-js-textfield" style="width: 460px">
                    <textarea class="mdl-textfield__input" rows="15" id="detail" runat="server"></textarea>
                    <label class="mdl-textfield__label" for="detail">Enter details here....</label>
                </div>

            </div>
            <div class="mdl-card__actions">
                <asp:LinkButton runat="server" ID="createEvent" OnClick="createEvent_Click" CssClass="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">Create Event
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <!-- Event card -->
    <style>
        .demo-card-event.mdl-card {
            width: auto;
            min-width: 256px;
            height: auto;
            min-height: 256px;
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

            .demo-card-event > .mdl-card__title, .mdl-card__supporting-text,
            .demo-card-event > .mdl-card__actions,
            .demo-card-event > .mdl-card__actions > .mdl-button {
                color: #fff;
            }
    </style>

    <div id="eventsContainer" runat="server">
    </div>
</asp:Content>
