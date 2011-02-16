<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.Photo.PhotographerModel>>" %>
<br />
<h3>Photos</h3>
<% bool firstp = true; foreach (var photographer in Model) { if (!firstp ) { %> <br /> <% } firstp = false; %>
<p>
<%     bool first = true;
       foreach (var gallery in photographer.PhotoGalleries) {
           if (!first) { %> | <% } first = false; %>
<a href="<%= gallery.GalleryURL %>" title="<%= gallery.GalleryName %> from <%= photographer.Company %>"> <%= gallery.GalleryName %></a>
<% } %>
<br /> from <a href="<%= photographer.URL %>" title="<%= photographer.Company %>"><%= photographer.Name %></a>
</p><% } %>