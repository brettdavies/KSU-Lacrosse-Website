<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">FAQ</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home","","", null, new { title="Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("FAQ", "faq", "about", null, new { title = "FAQ" })%></div>
<h1>Frequently Asked Questions</h1>
<p>Here is a list of common Questions and Answers about KSU Lacrosse:</p>
<p>
    <a href="#answer1">Is KSU Lacrosse a varsity team?</a><br />
    <a href="#answer2">So why should I want to play for KSU Lacrosse?</a><br />
    <a href="#answer3">Are we Recruiting?</a><br />
    <a href="#answer4">What would I have to do to be eligible to play?</a><br />
    <a href="#answer5">What kind of a commitment is needed?</a><br />
    <a href="#answer6">What if I have scheduling conflicts?</a><br />
    <a href="#answer7">How can I join the team?</a><br />
    <a href="#answer8">Who does the team play?</a><br />
    <a href="#answer9">Where do we pracitce/play?</a><br />
    <a href="#answer10">Would I have to play in the fall and spring or could I play just one part of the season?</a><br />
    <a href="#answer11">What is the practice schedule like?</a><br />
    <a href="#answer12">What equipment do I need to provide?</a></p>
<p>
    <a id="answer1" name="answer1"></a>Q: &#8220;Is KSU Lacrosse a varsity team?&#8221;<br />
    A: No. We are a club team. That means that while we get money from the school, not
    all expenses are paid for by the school. As a team we have dues, fundraising, and
    sponserships that support the rest of the team&#8217;s activities.</p>
<p>
    <a id="answer2" name="answer2"></a>Q: &#8220;So why should I want to play for KSU
    Lacrosse?&#8221;<br />
    A: If you played in high school and want to continue your career, than obviously
    come on out. If you&#8217;ve never played before you are still welcome to come out.
    Lacrosse is a great sport for all types of high school athletes, who want to stay
    active and enjoy team sports.</p>
<p>
    <a id="answer3" name="answer3"></a>Q: &#8220;Are we Recruiting?&#8221;<br />
    A: Not in the same way that a varsity team would. We dont have money to give out
    to players and cannot affect an acceptance into the school. But once you are accepted
    to KSU, anyone is allowed to join the team, and we are always welcoming new players.
    Joining the team in the beginning of a semester is preferable to joining the middle
    or the end, but is not required. Send us an email from the Recruitment page if you
    want to know more.</p>
<p>
    <a id="answer4" name="answer4"></a>Q: &#8220;What would I have to do to be eligible
    to play?&#8221;<br />
    A: You have to be a student at Kennesaw State University. This means that you are
    taking atleast 1 (one) class in any semester in which you want to particiapte in
    practices. To play in the league you must be taking 12 hours unless you are in your
    graduating semester in which case you can take less. Also, you must have no more
    than 3 spring semesters spent on any college lacrosse program&#8217;s roster.</p>
<p>
    <a id="answer5" name="answer5"></a>Q: &#8220;What kind of a commitment is needed?&#8221;<br />
    A: We are a serious team, and therefore a commitment from you is required. The dates
    for the next semesters practices will be available before registration, that way
    you can schedule your classes around practice. This will allow us the most possible
    people at practice, without forcing anyone to miss a class.</p>
<p>
    <a id="answer6" name="answer6"></a>Q: &#8220;What if I have scheduling conflicts?&#8220;<br />
    A: Try and work them out in advance. If nothing can be done about it, then send
    an email to the officers explaining why you cant make it. Playing time will depend
    on attendance at team practices and other functions so you should try and make it
    as much as possible.</p>
<p>
    <a id="answer7" name="answer7"></a>Q: &#8220;How can I join the team?&#8221;<br />
    A: You can join the team by showing up to practice with the player registration
    packet filled out, and any gear that you may already own. It might be a good idea
    to get intouch with an officer before hand, but that is not required. We don&#8217;t
    have try-outs.</p>
<p>
    <a id="answer8" name="answer8"></a>Q: &#8220;Who does the team play?&#8221;<br />
    A: We are going to schedule approx. 14 games for the spring against teams in the
    SELC.</p>
<p>
    <a id="answer9" name="answer9"></a>Q: &#8220;Where do we pracitce/play?&#8221;<br />
    A: We are having practice at the intramural field. It is located inbetween the gym
    and the softball field. Home games will either be on the same field or on the varisty
    field at the front of campus.</p>
<p>
    <a id="answer10" name="answer10"></a>Q: &#8220;Would I have to play in the fall
    and spring or could I play just one part of the season?&#8221;<br />
    A: You are allowed to play any semester you wish. The commitment that you make to
    the team only lasts for that semester. If you are thinking about playing the spring
    we encourage you to come out in the fall as well, so that we can get to know you
    better, and you can learn our system and earn more playing time than you would have
    by just coming out in the spring.</p>
<p>
    <a id="answer11" name="answer11"></a>Q: &#8221;What is the practice schedule like?&#8221;<br />
    A: We are practicing from 9-11:30 AM M-F. We will have 3 or 4 practices a week depending
    on Coach Byers work schedule.</p>
<p>
    <a id="answer12" name="answer12"></a>Q: &#8221;What equipment do I need to provide?&#8221;<br />
    A: All equipment needs to be provided by you. If you go though our sponsor, Bagataway
    Lacrosse, then they will give you what you need at cost. All players need to have
    a team helmet in order to play in the games, so talk to one of the officers about
    getting one. If you&#8217;re coming out for a first or second time to practice,
    many players have extra equipment which they can loan you, such as a stick and gloves.
    Once you decide to make the commitment to the team you should get your own equipment.</p>
</asp:Content>