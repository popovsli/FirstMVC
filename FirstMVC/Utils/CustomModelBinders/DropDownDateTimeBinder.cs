using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Utils.CustomModelBinders
{
    /// <summary>
    /// Override default model binder
    /// </summary>
    public class DropDownDateTimeBinder : DefaultModelBinder
    {
        private List<string> DateTimeTypes = new List<string> { "BirthDate", "StartDate", "EndDate" };

        protected override void BindProperty(ControllerContext contContext, ModelBindingContext bindContext, PropertyDescriptor propDesc)
        {
            if (DateTimeTypes.Contains(propDesc.Name))
            {
                if (!string.IsNullOrEmpty(contContext.HttpContext.Request.Form[propDesc.Name + "Year"]))
                {
                    DateTime dt = new DateTime(int.Parse(
                    contContext.HttpContext.Request.Form[propDesc.Name
                    + "Year"]),
                    int.Parse(contContext.HttpContext.Request.Form[propDesc.Name +
                    "Month"]),
                    int.Parse(contContext.HttpContext.Request.Form[propDesc.Name +
                    "Day"]));
                    propDesc.SetValue(bindContext.Model, dt);
                    return;
                }
            }
            base.BindProperty(contContext, bindContext, propDesc);
        }
    }
}