using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MedicalLocator.WebFront.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString FieldFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var editorDivBuilder = new TagBuilder("div");
            editorDivBuilder.AddCssClass("field_block");
            editorDivBuilder.InnerHtml += htmlHelper.LabelFor(expression);
            editorDivBuilder.InnerHtml += htmlHelper.EditorFor(expression);
            return new MvcHtmlString(editorDivBuilder.ToString());
        }
    }
}