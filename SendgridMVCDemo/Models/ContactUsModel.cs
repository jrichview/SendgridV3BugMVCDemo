using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendgridMVCDemo.Models
{
    public class ContactUsModel
    {
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public string EmailSubject { get; set; }
        public string EmailMessage { get; set; }

    }
}