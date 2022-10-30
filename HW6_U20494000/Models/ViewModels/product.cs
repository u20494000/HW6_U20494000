using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6_U20494000.Models.ViewModels
{
    public class product
    {
        public int productName { get; set; }
        public List<product> products { get; set; }
    }
}