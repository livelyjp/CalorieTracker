//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_food_log
    {
        public string food_log_id { get; set; }
        public int food_log_food_id { get; set; }
        public int food_log_user_id { get; set; }
        public decimal food_log_quantity { get; set; }
        public System.DateTime food_log_creation_timestamp { get; set; }
    
        public virtual tbl_food tbl_food { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}
