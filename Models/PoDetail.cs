using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSWebApp.Models
{
    public class PoDetail
    {
        public string PONO { get; set; }
        public string ITCODE { get; set; }
        public Nullable<int> QTY { get; set; }

        public Item ITEM { get; set; }
        [JsonIgnore]
        public PoMaster POMASTER { get; set; }
    }
}