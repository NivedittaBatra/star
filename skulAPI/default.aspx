<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Async="true" Inherits="skulAPI._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="Introducing Lollipop, a sweet new take on Android." />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>EdJourn</title>
    <!-- Page styles -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:regular,bold,italic,thin,light,bolditalic,black,medium&amp;lang=en" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link rel="stylesheet" href="https://storage.googleapis.com/code.getmdl.io/1.0.0/material.min.css" />
    <link rel="stylesheet" href="styles.css" />
    <style>@font-face{font-family:crayonFont;src:url('fonts/Crayons.ttf')}
        #view-source {
            position: fixed;
            display: block;
            right: 0;
            bottom: 0;
            margin-right: 40px;
            margin-bottom: 40px;
            z-index: 900;
        }

        @media screen and (max-width: 1067px) {
            .android-wear-band {
                background-size: 50%;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mdl-layout mdl-js-layout mdl-layout--fixed-header">
            <div class="android-header mdl-layout__header mdl-layout__header--waterfall">
                <div class="mdl-layout__header-row">
                    <span class="android-title mdl-layout-title">
                        <img class="android-logo-image" src="images/android-logo.png">
                    </span>
                    <!-- Add spacer, to align navigation to the right in desktop -->
                    <div class="android-header-spacer mdl-layout-spacer"></div>
                    <div class="android-search-box mdl-textfield mdl-js-textfield mdl-textfield--expandable mdl-textfield--floating-label mdl-textfield--align-right mdl-textfield--full-width">
                        <label class="mdl-button mdl-js-button mdl-button--icon" for="search-field">
                            <i class="material-icons">search</i>
                        </label>
                        <div class="mdl-textfield__expandable-holder">
                            <input class="mdl-textfield__input" type="text" id="search-field" />
                        </div>
                    </div>
                    <!-- Navigation -->
                    <div class="android-navigation-container">
                        <nav class="android-navigation mdl-navigation">
                            <a class="mdl-navigation__link mdl-typography--text-uppercase" href="">Get Started</a>
                            <a class="mdl-navigation__link mdl-typography--text-uppercase" href="">Queries</a>
                        </nav>
                    </div>
                    <button class="android-more-button mdl-button mdl-js-button mdl-button--icon mdl-js-ripple-effect" id="more-button">
                        <i class="material-icons">more_vert</i>
                    </button>
                    <ul class="mdl-menu mdl-js-menu mdl-menu--bottom-right mdl-js-ripple-effect" for="more-button">
                        <li class="mdl-menu__item">Enlist All Schools</li>
                    </ul>
                    <span class="android-mobile-title mdl-layout-title">
                        <img class="android-logo-image" src="images/android-logo.png">
                    </span>
                </div>
            </div>

            <div class="android-drawer mdl-layout__drawer">
                <span class="mdl-layout-title">
                    <img class="android-logo-image" src="images/android-logo-white.png">
                </span>
                <nav class="mdl-navigation">
                    <a class="mdl-navigation__link">More Features are coming soon..</a>
                </nav>
            </div>

            <div class="android-content mdl-layout__content">
                <a name="top"></a>
                <div class="android-be-together-section mdl-typography--text-center">
                    <div class="android-font android-slogan">Is your school smart yet?</div>
                    <div class="android-font android-sub-slogan">we make schools better, smarter and easy!</div>
                    <div class="android-font android-create-character">
                        <a href="" style="color: whitesmoke; text-shadow: 0px 0px 10px black">make your school <i>smarter</i></a>
                    </div>

                    <a href="#screens">
                        <button class="android-fab mdl-button mdl-button--colored mdl-js-button mdl-button--fab mdl-js-ripple-effect">
                            <i class="material-icons">expand_more</i>
                        </button>
                    </a>
                </div>
                <div class="android-screen-section mdl-typography--text-center">
                    <a name="screens"></a>
                    <div class="mdl-typography--display-1-color-contrast">Providing a wide host of features</div>
                    <style>
                        td{width:25%;}
                    </style>
                    <div class="android-screens">
                        <table style="width:100%">
                            <tbody>
                                <tr style="text-align:center">
                                    <td><img src="images/hw_icon.jpg" height="200"/></td>
                                    <td><img src="images/attendanceicon.jpg" height="200"/></td>
                                    <td><img src="images/event.ico" height="200"/></td>
                                    <td>FREE</td>
                                </tr>
                                <tr style="font-size:20px;color:goldenrod;text-align:center">
                                    <td>Homework</td>
                                    <td>Attendance</td>
                                    <td>Events</td>
                                    <td>FREE</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <style>#stats{margin:0 20px;color:whitesmoke;padding-top:100px}.secondaryStat{font-size:34px;font-weight:400}</style>
                <div class="android-wear-section">
                    <div id="stats">
                        <table style="width:100%">
                            <tbody>
                                <tr style="font-family:crayonFont;font-size:60px;color:whitesmoke;font-weight:600;text-align:center;height:110px;">
                                    <td>3 <span class="secondaryStat">Schools</span></td>
                                    <td>3000+ <span class="secondaryStat">Students</span></td>
                                    <td>5 <span class="secondaryStat">Services</span></td>
                                </tr>
                                <tr style="text-align:center;">
                                    <td><img src="images/hw_icon.jpg" height="200"/></td>
                                    <td><img src="images/attendanceicon.jpg" height="200"/></td>
                                    <td><img src="images/event.ico" height="200"/></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="android-wear-band">
                        <div class="android-wear-band-text">
                            <div class="mdl-typography--display-2 mdl-typography--font-thin">The best of Google built in</div>
                            <p class="mdl-typography--headline mdl-typography--font-thin">
                                Android works perfectly with your favourite apps like Google Maps,
                            Calendar and YouTube.
                            </p>
                            <p>
                                <a class="mdl-typography--font-regular mdl-typography--text-uppercase android-alt-link" href="">See what's new in the Play Store&nbsp;<i class="material-icons">chevron_right</i>
                                </a>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="android-customized-section">
                    <div class="android-customized-section-text">
                        <div class="mdl-typography--font-light mdl-typography--display-1-color-contrast">Make <span id="mySchool">my school </span>smart</div>
                        <p class="mdl-typography--font-light">
                            Put the stuff that you care about right on your home screen: the latest news, the weather or a stream of your recent photos.
                        <br />
                            <a href="" class="android-link mdl-typography--font-light">Customise your phone</a>
                        </p>
                    </div>
                    <div class="android-customized-section-image" style="background: none">
                        <div class="mdl-textfield mdl-js-textfield">
                            <input class="mdl-textfield__input" type="text" id="schoolName" runat="server" />
                            <label class="mdl-textfield__label" for="schoolName">Name of School</label>
                        </div>
                        <br />
                        <div class="mdl-textfield mdl-js-textfield">
                            <input class="mdl-textfield__input" type="text" id="address" runat="server" />
                            <label class="mdl-textfield__label" for="address">Address</label>
                        </div>
                        <br />
                        <div class="mdl-textfield mdl-js-textfield">
                            <input class="mdl-textfield__input" type="text" id="contact" runat="server" />
                            <label class="mdl-textfield__label" for="contact">Contact</label>
                        </div>
                        <br />
                        <div class="mdl-textfield mdl-js-textfield">
                            <input class="mdl-textfield__input" type="text" id="email" runat="server" />
                            <label class="mdl-textfield__label" for="email">Email</label>
                        </div>
                        <br />
                        <div class="mdl-textfield mdl-js-textfield">
                            <input class="mdl-textfield__input" type="text" id="name" runat="server" />
                            <label class="mdl-textfield__label" for="contact">Your Name</label>
                        </div>
                        <br />
                        <asp:LinkButton runat="server" ID="addSchool" OnClick="addSchool_Click" class="mdl-button mdl-js-button mdl-button--raised mdl-button--colored">
                        I want my school to be smart!
                        </asp:LinkButton>

                    </div>
                </div>
                <div class="android-more-section" style="display: none;">
                    <div class="android-section-title mdl-typography--display-1-color-contrast">More from Android</div>
                    <div class="android-card-container mdl-grid">
                        <div class="mdl-cell mdl-cell--3-col mdl-cell--4-col-tablet mdl-cell--4-col-phone mdl-card mdl-shadow--3dp">
                            <div class="mdl-card__media">
                                <img src="images/more-from-1.png">
                            </div>
                            <div class="mdl-card__title">
                                <h4 class="mdl-card__title-text">Get going on Android</h4>
                            </div>
                            <div class="mdl-card__supporting-text">
                                <span class="mdl-typography--font-light mdl-typography--subhead">Four tips to make your switch to Android quick and easy</span>
                            </div>
                            <div class="mdl-card__actions">
                                <a class="android-link mdl-button mdl-js-button mdl-typography--text-uppercase" href="">Make the switch
                                <i class="material-icons">chevron_right</i>
                                </a>
                            </div>
                        </div>

                        <div class="mdl-cell mdl-cell--3-col mdl-cell--4-col-tablet mdl-cell--4-col-phone mdl-card mdl-shadow--3dp">
                            <div class="mdl-card__media">
                                <img src="images/more-from-4.png">
                            </div>
                            <div class="mdl-card__title">
                                <h4 class="mdl-card__title-text">Create your own Android character</h4>
                            </div>
                            <div class="mdl-card__supporting-text">
                                <span class="mdl-typography--font-light mdl-typography--subhead">Turn the little green Android mascot into you, your friends, anyone!</span>
                            </div>
                            <div class="mdl-card__actions">
                                <a class="android-link mdl-button mdl-js-button mdl-typography--text-uppercase" href="">androidify.com
                                <i class="material-icons">chevron_right</i>
                                </a>
                            </div>
                        </div>

                        <div class="mdl-cell mdl-cell--3-col mdl-cell--4-col-tablet mdl-cell--4-col-phone mdl-card mdl-shadow--3dp">
                            <div class="mdl-card__media">
                                <img src="images/more-from-2.png">
                            </div>
                            <div class="mdl-card__title">
                                <h4 class="mdl-card__title-text">Get a clean customisable home screen</h4>
                            </div>
                            <div class="mdl-card__supporting-text">
                                <span class="mdl-typography--font-light mdl-typography--subhead">A clean, simple, customisable home screen that comes with the power of Google Now: Traffic alerts, weather and much more, just a swipe away.</span>
                            </div>
                            <div class="mdl-card__actions">
                                <a class="android-link mdl-button mdl-js-button mdl-typography--text-uppercase" href="">Download now
                                <i class="material-icons">chevron_right</i>
                                </a>
                            </div>
                        </div>

                        <div class="mdl-cell mdl-cell--3-col mdl-cell--4-col-tablet mdl-cell--4-col-phone mdl-card mdl-shadow--3dp">
                            <div class="mdl-card__media">
                                <img src="images/more-from-3.png">
                            </div>
                            <div class="mdl-card__title">
                                <h4 class="mdl-card__title-text">Millions to choose from</h4>
                            </div>
                            <div class="mdl-card__supporting-text">
                                <span class="mdl-typography--font-light mdl-typography--subhead">Hail a taxi, find a recipe, run through a temple – Google Play has all the apps and games that let you make your Android device uniquely yours.</span>
                            </div>
                            <div class="mdl-card__actions">
                                <a class="android-link mdl-button mdl-js-button mdl-typography--text-uppercase" href="">Find apps
                                <i class="material-icons">chevron_right</i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <style>
                    .mdl-mega-footer--social-btn {
                        float: left;
                        margin-right: 20px;
                    }
                </style>
                <footer class="android-footer mdl-mega-footer">
                    <div class="mdl-mega-footer--top-section">
                        <div class="mdl-mega-footer--left-section">
                            <a class="mdl-mega-footer--social-btn" href="#" style="display: block; background-image: url('https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Facebook_logo_36x36.svg/36px-Facebook_logo_36x36.svg.png')"></a>
                            &nbsp;
                        <a class="mdl-mega-footer--social-btn" href="#" style="display: block; background-image: url('http://www.brentcarerscentre.org.uk/wp-content/uploads/2013/04/Young-Carers-Page-Twitter-Logo-image-36-x-36.png')"></a>
                            &nbsp;
                        <a class="mdl-mega-footer--social-btn" href="#" style="background: none; display: block; background-image: url('http://www.liberateyourtime.com/wp-content/uploads/2013/01/Gmail-icon-36x36.png')"></a>
                        </div>
                        <div class="mdl-mega-footer--right-section">
                            <a class="mdl-typography--font-light" href="#top">Back to Top
                            <i class="material-icons">expand_less</i>
                            </a>
                        </div>
                    </div>

                    <div class="mdl-mega-footer--middle-section">
                        <p class="mdl-typography--font-light">© 2015 Webeley Technologies</p>
                        <p class="mdl-typography--font-light">Some features and devices may not be available in all areas</p>
                    </div>

                    <div class="mdl-mega-footer--bottom-section">
                        <a style="display:none" class="android-link android-link-menu mdl-typography--font-light" id="version-dropdown">Versions
                        <i class="material-icons">arrow_drop_up</i>
                        </a>
                        <ul class="mdl-menu mdl-js-menu mdl-menu--top-left mdl-js-ripple-effect" for="version-dropdown">
                            <li class="mdl-menu__item">5.0<br />
                                Lollipop</li>
                            <li class="mdl-menu__item">4.4 KitKat</li>
                            <li class="mdl-menu__item">4.3 Jelly Bean</li>
                            <li class="mdl-menu__item">Android History</li>
                        </ul>
                        <a class="android-link mdl-typography--font-light" href="">Feedback</a>
                        <a class="android-link mdl-typography--font-light" href="">Blog</a>
                        <a class="android-link mdl-typography--font-light" href="">Privacy Policy</a>
                    </div>

                </footer>
            </div>
        </div>
        <a href="Login.aspx" target="_blank" id="view-source" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-color--accent mdl-color-text--accent-contrast">Login</a>
        <script src="js/mdl.js"></script>

    </form>
</body>
</html>
