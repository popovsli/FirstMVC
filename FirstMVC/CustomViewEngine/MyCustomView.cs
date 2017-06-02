using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.CustomViewEngine
{
    public class MyCustomView : IView
    {
        private string _viewPhysicalPath;

        public MyCustomView(string ViewPhysicalPath)
        {
            _viewPhysicalPath = ViewPhysicalPath;
        }
        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            string rawcontents = File.ReadAllText(_viewPhysicalPath);
            string parsedcontents = Parse(rawcontents, viewContext.ViewData);
            writer.Write(parsedcontents);
        }

        public string Parse(string contents, ViewDataDictionary viewdata)
        {
            return Regex.Replace(contents, "\\{(.+)\\}", m => GetMatch(m, viewdata));
        }

        public virtual string GetMatch(Match m, ViewDataDictionary viewdata)
        {
            if (m.Success)
            {
                string key = m.Result("$1");
                if (viewdata.ContainsKey(key))
                {
                    return viewdata[key].ToString();
                }
            }
            return string.Empty;
        }
    }
}