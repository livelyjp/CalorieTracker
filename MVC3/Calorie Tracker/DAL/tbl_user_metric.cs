//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calorie_Tracker.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_user_metric
    {
        public tbl_user_metric()
        {
            this.tbl_user_information = new HashSet<tbl_user_information>();
            this.tbl_user_target = new HashSet<tbl_user_target>();
        }
    
        public string user_metric_id { get; set; }
        public string user_metric_name { get; set; }
    
        public virtual ICollection<tbl_user_information> tbl_user_information { get; set; }
        public virtual ICollection<tbl_user_target> tbl_user_target { get; set; }
    }
}
