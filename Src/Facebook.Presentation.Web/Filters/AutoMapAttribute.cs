using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;

namespace Facebook.Presentation.Web.Filters
{
    public class AutoMapAttribute : ActionFilterAttribute
    {
        private readonly Type _sourceType;
        private readonly Type _destType;

        public AutoMapAttribute(Type sourceType, Type destType)
        {
            _sourceType = sourceType;
            _destType = destType;
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model;
            var viewModel = Mapper.Map(model, _sourceType, _destType);

            filterContext.Controller.ViewData.Model = viewModel;
        }

        public Type SourceType
        {
            get { return _sourceType; }
        }

        public Type DestType
        {
            get { return _destType; }
        }
    }
}