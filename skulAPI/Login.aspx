<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Login.aspx.cs" Inherits="skulAPI.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/mdl.css" rel="stylesheet" />
    <script src="js/mdl.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="mdl-layout mdl-js-layout mdl-layout--fixed-header">
        <header class="mdl-layout__header" style="z-index:0;height:300px;background-image:url('images/login.jpg');background-position-y:-85px;background-size:cover">
            <div class="mdl-layout__header-row">
                <span class="mdl-layout-title" style="color:black;text-shadow:0px 0px 1px black">Login</span>
                <div class="mdl-layout-spacer"></div>
                <nav class="mdl-navigation mdl-layout--large-screen-only">
                    <a class="mdl-navigation__link" href="">Link</a>
                    <a class="mdl-navigation__link" href="">Link</a>
                    <a class="mdl-navigation__link" href="">Link</a>
                    <a class="mdl-navigation__link" href="">Link</a>
                </nav>
            </div>
        </header>
    </div>
    <main class="mdl-layout__content" style="width:100%;">
        <div class="page-content" style="margin: 0 auto;width:100%">

            <style>
                .demo-card-square.mdl-card {
                    width: 400px;
                    height: 450px;
                }
            </style>

            <div class="demo-card-square mdl-card mdl-shadow--2dp" style="margin: 0 auto;float:none;margin-top:100px">
                <div class="mdl-card__supporting-text">
                    <h4>I am a...</h4>
                    <div class="mdl-tabs mdl-js-tabs mdl-js-ripple-effect">
                        <div class="mdl-tabs__tab-bar">
                            <a href="#starks-panel" class="mdl-tabs__tab is-active">Student</a>
                            <a href="#targaryens-panel" class="mdl-tabs__tab">Teacher</a>
                        </div>
                        <div class="mdl-tabs__panel is-active" id="starks-panel" style="margin-top:20px">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                                <input class="mdl-textfield__input" type="text" id="u1" runat="server"/>
                                <label class="mdl-textfield__label" for="u1">Email...</label>
                            </div>
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label" style="margin-top:20px;margin-bottom:20px">
                                <input class="mdl-textfield__input" type="password" id="p1" runat="server"/>
                                <label class="mdl-textfield__label" for="p1">Password...</label>
                            </div>
                            <asp:Button Text="Log In" ID="loginStudent" UseSubmitBehavior="false" OnClick="loginStudent_Click" runat="server" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--colored" style="width:100%">
                                
                            </asp:Button>
                        </div>
                        <div class="mdl-tabs__panel" id="targaryens-panel" style="margin-top:20px">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                                <input class="mdl-textfield__input" type="text" id="u2" runat="server"/>
                                <label class="mdl-textfield__label" for="u2">Email...</label>
                            </div>
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label" style="margin-top:20px;margin-bottom:20px">
                                <input class="mdl-textfield__input" type="password" id="p2" runat="server"/>
                                <label class="mdl-textfield__label" for="p2">Password...</label>
                            </div>
                            <asp:Button Text="Log In" ID="teacherLogin" UseSubmitBehavior="false" OnClick="teacherLogin_Click" runat="server" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--colored" style="width:100%">
                                
                            </asp:Button>
                        </div>
         
                    </div>
                </div>
            </div>
        </div>
    </main>
    </form>
</body>
</html>
