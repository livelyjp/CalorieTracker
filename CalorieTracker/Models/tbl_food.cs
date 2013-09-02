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
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Web.Mvc;
    using CalorieTracker.Validators;
    using CalorieTracker.Models.Accounts;
    using CalorieTracker.Utilities;
    
    public partial class tbl_food
    {
        public tbl_food()
        {
            this.tbl_food_log = new HashSet<tbl_food_log>();
            this.tbl_food1 = new HashSet<tbl_food>();
        }

        [HiddenInput]
        public string food_id { get; set; }
        [HiddenInput]
        public string food_parent_id { get; set; }
        [Display(Name = "Meal Title")]
        public string food_name { get; set; }
        [Display(Name = "Quantity")]
        public Nullable<double> food_quantity { get; set; }
        [Display(Name = "Carbohydrate")]
        public Nullable<double> food_carbohydrates { get; set; }
        [Display(Name = "Protien")]
        public Nullable<double> food_protein { get; set; }
        [Display(Name = "Fat")]
        public Nullable<double> food_fat { get; set; }
    
        public virtual ICollection<tbl_food_log> tbl_food_log { get; set; }
        public virtual ICollection<tbl_food> tbl_food1 { get; set; }
        public virtual tbl_food tbl_food2 { get; set; }
    }
}
