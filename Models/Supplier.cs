using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSWebApp.Models
{
    public class Supplier
    {

        public string SUPLNO { get; set; }
        public string SUPLNAME { get; set; }
        public string SUPLADDR { get; set; }

        [JsonIgnore]
        public virtual IList<PoMaster> POMASTERs { get; set; }
    }
}