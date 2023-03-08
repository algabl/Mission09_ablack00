using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission09_ablack00.Models.ViewModels;

namespace Mission09_ablack00.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        
        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        
        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public string PageClassDisabled { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            TagBuilder prevTb = new TagBuilder("a");
            if (PageModel.CurrentPage == 1)
            {
                if (PageClassesEnabled)
                {
                    prevTb.AddCssClass(PageClassDisabled);
                }
            }
            else
            {
                prevTb.Attributes["href"] = uh.Action(PageAction, new { pageNum = PageModel.CurrentPage - 1});
            }
            if (PageClassesEnabled)
            {
                prevTb.AddCssClass(PageClass);
                prevTb.AddCssClass(PageClassNormal);
            }
            
            prevTb.InnerHtml.Append("Previous");
            final.InnerHtml.AppendHtml(prevTb);
            
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }
            
            TagBuilder nextTb = new TagBuilder("a");
            if (PageModel.CurrentPage == PageModel.TotalPages)
            {
                if (PageClassesEnabled)
                {
                    nextTb.AddCssClass(PageClassDisabled);
                }
                    
            }
            else
            {
                nextTb.Attributes["href"] = uh.Action(PageAction, new { pageNum = PageModel.CurrentPage + 1 });
            }
            if (PageClassesEnabled)
            {
                nextTb.AddCssClass(PageClass);
                nextTb.AddCssClass(PageClassNormal);
            }
            nextTb.InnerHtml.Append("Next");
            final.InnerHtml.AppendHtml(nextTb);

            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}