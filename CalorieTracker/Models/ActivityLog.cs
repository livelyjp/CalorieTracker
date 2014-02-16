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
    
    public partial class ActivityLog
    {
        public int ActivityLogID { get; set; }
        public int ActivityID { get; set; }
        public int UserID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.TimeSpan Duration { get; set; }
        public decimal Distance { get; set; }
        public string Title { get; set; }
        public decimal Accent { get; set; }
        public int HeartRate { get; set; }
        public string Notes { get; set; }
        public string FileURL { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
    }
}
