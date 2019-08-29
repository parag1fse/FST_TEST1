using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSWebApp.Models
{
    public class Item
    {


        public string ITCODE { get; set; }
        public string ITDESC { get; set; }
        public Nullable<decimal> ITRATE { get; set; }

        [JsonIgnore]
        public virtual IList<PoDetail> PODETAILs { get; set; }
    }
}