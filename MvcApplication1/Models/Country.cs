using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class Country
    {
        public List<SelectListItem> Countrylist { get; set; }

        public string CountryCode { get; set; }

        public string Descr { get; set; }
    }
}