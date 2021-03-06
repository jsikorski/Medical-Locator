﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MedicalLocator.WebFront.Helpers
{
    public static class HtmlHelperFormsExtensions
    {
        public static MvcHtmlString FieldFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            var fieldInnerHtml = new MvcHtmlString(
                htmlHelper.LabelFor(expression).ToString() + 
                htmlHelper.EditorFor(expression) + 
                htmlHelper.ValidationMessageFor(expression));
            
            return GetFieldHtmlString(fieldInnerHtml);
        }

        public static MvcHtmlString PassFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            var passwordInnerHtml = new MvcHtmlString(
                htmlHelper.LabelFor(expression).ToString() +
                htmlHelper.PasswordFor(expression) +
                htmlHelper.ValidationMessageFor(expression));

            return GetFieldHtmlString(passwordInnerHtml);
        }

        public static MvcHtmlString ComboBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            var comboxBoxInnderHtml = new MvcHtmlString(
                htmlHelper.LabelFor(expression).ToString() + 
                htmlHelper.DropDownListFor(expression, selectList) +
                htmlHelper.ValidationMessageFor(expression));

            return GetFieldHtmlString(comboxBoxInnderHtml);
        }

        public static MvcHtmlString NamedCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
            string name, Expression<Func<TModel, bool>> expression)
        {
            var namedCheckBoxContent = new MvcHtmlString(htmlHelper.CheckBoxFor(expression) + name);
            return GetFieldHtmlString(namedCheckBoxContent);
        }

        private static MvcHtmlString GetFieldHtmlString(MvcHtmlString fieldInnerHtml)
        {
            var fieldDivBuilder = new TagBuilder("div");
            fieldDivBuilder.AddCssClass("field_block");
            fieldDivBuilder.InnerHtml += fieldInnerHtml;
            return new MvcHtmlString(fieldDivBuilder.ToString());
        }
    }
}