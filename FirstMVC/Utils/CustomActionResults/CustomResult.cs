using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.CustomActionResults
{
    public class CustomResult<T> : ActionResult
    {
        string result;

        public T Data { private get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            using (FileStream oFileStream = new FileStream("C://a", FileMode.Open))
            {
                using (FileStream cFileStream = File.Create(
                Guid.NewGuid().ToString() + ".gz"))
                {
                    using (GZipStream compressionStream =
                    new GZipStream(cFileStream, CompressionMode.Compress))
                    {
                        oFileStream.CopyTo(compressionStream);
                        StreamReader reader = new StreamReader(compressionStream);
                        result = reader.ReadToEnd();
                    }
                }
            }
            context.HttpContext.Response.Write(result);
        }
    }
}