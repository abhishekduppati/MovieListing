using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieListing.Models
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string height)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            builder.MergeAttribute("height", height);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
    //The above ‘Image’ function has the ‘MvcHtmlString’ type and will accept a four-parameter helper (helper type ‘image’), 
    //src (image path), altText (alternative text) and height (height of image) and will return a ‘MvcHtmlString’ type.

}