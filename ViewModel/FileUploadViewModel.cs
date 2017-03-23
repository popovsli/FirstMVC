using BusinessEntities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModel
{
    public class FileUploadViewModel : EmployeeListViewModel
    {
        [FileUploadValidation]
        public HttpPostedFileBase fileUpload { get; set; }
    }
}