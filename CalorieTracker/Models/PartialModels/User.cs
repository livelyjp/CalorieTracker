﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.MetaData;
using CalorieTracker.Models.ViewModels;
using CTDataGenerator.Utils;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (UserMetaData))]
    public partial class User
    {
        public User(RegisterModel registerModel)
        {
            DOB = registerModel.DateOfBirth;
            Gender = registerModel.Gender;
            var passwordHasher = new PasswordHasher(registerModel.Password);
            PasswordHash = passwordHasher.PasswordHash;
            PasswordSalt = passwordHasher.PasswordSalt;
            Admin = false;
            CreationTimestamp = DateTime.Now;
            ActivityLevelType = 0;
            Personality = 0;

            ActivityLogs = new HashSet<ActivityLog>();
            FoodLogs = new HashSet<FoodLog>();
            MetricLogs = new HashSet<MetricLog>();
        }
    }
}