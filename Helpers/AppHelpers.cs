using System.Web.Mvc;
using System.Web.Routing;
using System.Text.RegularExpressions;
using System;

namespace KSULax.Helpers
{
    /// <summary>
    /// Main Application Functions
    /// </summary>
    public static class KSULaxHelper
    {
        /// <summary>
        /// Takes a string and returns a 300 character (max) string with all html removed.
        /// </summary>
        /// <param name="desc">string to turn into a description</param>
        /// <returns></returns>
        public static string formatDesc(this HtmlHelper helper, string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                //replace all HTML tags with a space
                desc = Regex.Replace(desc, @"<(.|\n)*?>", " ");

                //replace HTML non-breaking space with a space
                desc = desc.Replace("&nbsp;", " ").Replace("&nbsp", " ");

                //remove extra whitespace
                desc = Regex.Replace(desc, @"\s+", " ");

                desc = desc.Trim();
                desc = desc.Substring(0, (desc.Length < 300) ? desc.Length : 300).Trim();
            }

            return desc;
        }

        public static string formatDate(this HtmlHelper helper, DateTime date)
        {
            return helper.Encode(date.ToString("MMMM dd, yyyy"));
        }
    }

    public static class ImageHelper
    {
        public static string Image(this HtmlHelper helper, string id, string url, string alternateText)
        {
            return Image(helper, id, url, alternateText, null);
        }

        public static string Image(this HtmlHelper helper, string id, string url, string alternateText, object htmlAttributes)
        {
            // Instantiate a UrlHelper 
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            // Create tag builder
            var builder = new TagBuilder("img");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("src", urlHelper.Content(url));
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag
            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }

    public static class URLHelper
    {
        public static string URL(this HtmlHelper helper, string id, string url, string alternateText)
        {
            return URL(helper, id, url, alternateText, null);
        }

        public static string URL(this HtmlHelper helper, string id, string url, string alternateText, object htmlAttributes)
        {
            // Instantiate a UrlHelper 
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            // Create tag builder
            var builder = new TagBuilder("a");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("src", urlHelper.Content(url));
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag
            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}