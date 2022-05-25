using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Store.Models.ViewsInfo;
using Store.Models;
using Microsoft.AspNetCore.Mvc;
namespace Store.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkerHelper : TagHelper
    {
        
        private IUrlHelperFactory _urlHelperFactory;

        public PageLinkerHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext _ViewContext { get; set; }
        
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(_ViewContext);
            
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                PageUrlValues["productPage"] = i;
                TagBuilder tag = new TagBuilder("a");

                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage
                    ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString() + " ");

                result.InnerHtml.AppendHtml(tag);

            }
            output.Content.AppendHtml(result.InnerHtml);


        }
    }
}
