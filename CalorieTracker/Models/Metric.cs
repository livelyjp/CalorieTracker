//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Metric
    {
        public Metric()
        {
            this.MetricLogs = new HashSet<MetricLog>();
        }
    
        public int MetricID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    
        public virtual ICollection<MetricLog> MetricLogs { get; set; }
    }
}
