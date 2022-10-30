//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HW6_U20494000.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class order_items
    {
       
        public int order_id { get; set; }
        public int item_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal list_price { get; set; }
        public decimal discount { get; set; }

        public decimal grandTotal { get; set; }

        public DateTime date { get; set; }
        public string product_name { get; set; }
        public decimal _total;
        public decimal Total { get { return _total = list_price * quantity; } set { this._total = value; } }
    
        public virtual product product { get; set; }
        public virtual order order { get; set; }
    }
}
