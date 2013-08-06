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
    using System.Web.Mvc;
    using Calorie_Tracker.Connection;
    using Calorie_Tracker.Utilities;
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
        //[DateOfBirthValidator] Reinstate later
        public string user_dob { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Please Provide A Valid Date Of Birth")]
        public DateTime user_dob_datetime
        {
            get
            {
                if (user_dob == null) return DateTime.Now;
                else return DateTime.ParseExact(user_dob, "ddMMyyyy", null);
            }
        }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter A Password")]
        public string user_password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Confirm Password")]
        [Compare("user_password", ErrorMessage = "Passwords must match")]
        public string user_passwordConfim { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string user_password_salt { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string user_password_hash { get; set; }

        [Display(Name = "Created Date")]
        public string user_creation_date { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime user_created_datetime
        {
            get
            {
                if (user_creation_date == null) return DateTime.Now;
                else return DateTime.ParseExact(user_creation_date, "ddMMyyyyHHmmss", null);
            }
        }

        [Display(Name = "Remember Me")]
        public bool user_remember_me { get; set; }

        public virtual ICollection<tbl_food_log> tbl_food_log { get; set; }
        public virtual ICollection<tbl_user_information> tbl_user_information { get; set; }
        public virtual ICollection<tbl_user_target> tbl_user_target { get; set; }

        /// <summary>
        /// Is User Object Valid For Logon
        /// </summary>
        /// <param name="_email">User Email Address</param>
        /// <param name="_password">User Password</param>
        /// <returns>If It Is Valid Or Not</returns>
        public bool IsValid(string _email, string _password)
        {
            //TODO remove if not used
            DataConnection connection = new DataConnection("SELECT * FROM tbl_user WHERE user_email = ?", typeof(tbl_user));
            connection.AddParameter(_email);
            tbl_user[] dbItem = (tbl_user[])connection.ExecuteQuery();
            //Get User Object Back
            if (dbItem.Length == 1)
            {
                string dbSalt = string.Empty;
                string dbHash = string.Empty;
                if (PasswordHasher.IsPasswordValid(dbItem[0].user_password_hash, dbItem[0].user_password_salt, _password)) return true; //Is Inputed Pass Same As Ours
            }
            return false;
        }

        /// <summary>
        /// Is the User Object Valid For Signup
        /// </summary>
        /// <param name="_email">Email Address</param>
        /// <returns>If Valid Or Not</returns>
        public bool IsValid(string _email)
        {
            //TODO remove if not used
            DataConnection connection = new DataConnection("SELECT user_email FROM tbl_user WHERE user_email = ?", typeof(tbl_user));
            connection.AddParameter(_email);
            if (connection.Exists) return true; //User Doesnt Exist
            return false;
        }

        /// <summary>
        /// Does This User Exist By Email Address
        /// </summary>
        /// <param name="_email">User Email Address</param>
        /// <returns>If It Exists Or Not</returns>
        public bool validEmail(string _email)
        {
            //TODO remove if not used
            DataConnection connection = new DataConnection("SELECT user_email FROM tbl_user WHERE user_email = ?", typeof(tbl_user));
            connection.AddParameter(_email);
            return connection.Exists;
        }
    }
}
