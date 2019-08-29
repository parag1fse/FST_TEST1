using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSWebApp.Models
{
    public class PoMaster
    {

        public string PONO { get; set; }
        public Nullable<System.DateTime> PODATE { get; set; }
        public string SUPLNO { get; set; }

        //[JsonIgnore]
        public List<PoDetail> PODETAILs { get; set; }
        public Supplier SUPPLIER { get; set; }
    }
}