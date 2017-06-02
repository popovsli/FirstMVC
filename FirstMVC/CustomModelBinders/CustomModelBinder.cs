using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.CustomModelBinders
{
    /// <summary>
    /// Create custom model binder
    /// </summary>
    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return null;
        }
    }
}