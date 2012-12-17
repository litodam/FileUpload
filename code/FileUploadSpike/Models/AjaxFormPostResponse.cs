using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadSpike.Models
{
    public class AjaxFormPostResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string RedirectUrl { get; set; }

        public object AdditionalData { get; set; }
    }
}