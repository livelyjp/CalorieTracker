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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;
    using Calorie_Tracker.Validators;

    public partial class tbl_user
    {
        public tbl_user()
        {
            this.tbl_food_log = new HashSet<tbl_food_log>();
            this.tbl_user_information = new HashSet<tbl_user_information>();
            this.tbl_user_target = new HashSet<tbl_user_target>();
        }

        [HiddenInput(DisplayValue = false)]
        public string user_id { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Provide A Valid Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailValidator]
        public string user_email { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Provide A Valid Name")]
        public string user_first_name { get; set; }
        [Display(Name = "Second Name")]
        [Required(ErrorMessage = "Please Provide A Valid Name")]
        public string user_second_name { get; set; }
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Please Provide A Valid Date Of Birth")]
        //[DateOfBirthValidator]
        public string user_dob { get; set; }
        public string user_password_salt { get; set; }
        [Display(Name = "Created Date")]
        public string user_creation_date { get; set; }
        public string user_password_hash { get; set; }
    
        public virtual ICollection<tbl_food_log> tbl_food_log { get; set; }
        public virtual ICollection<tbl_user_information> tbl_user_information { get; set; }
        public virtual ICollection<tbl_user_target> tbl_user_target { get; set; }
    }
}
