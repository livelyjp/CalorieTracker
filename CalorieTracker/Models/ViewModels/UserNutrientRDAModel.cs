﻿using System;
using CalorieTracker.Utils.RDA;

namespace CalorieTracker.Models.ViewModels
{
    public class UserNutrientRDAModel
    {
        public UserNutrientRDAModel(RDAUtil rdaUtil)
        {
            UserNutrientRDA = rdaUtil.UserNutrientRDA;
            MaxNutrientRDAValue = Math.Floor(rdaUtil.MaxRDAValue);
            UserNutrientRDAValue = Math.Floor(rdaUtil.UserNutrientRDAValue);
            UserNutrientRDAPercentage = Math.Floor(rdaUtil.UserNutrientRDAPercentage);
        }

        public UserNutrientRDAModel(NutrientRDA nutrientRDA, decimal maxNutrientRDAValue, decimal userNutrientRDAValue,
            decimal userNutrientRDAPercentage)
        {
            UserNutrientRDA = nutrientRDA;
            MaxNutrientRDAValue = maxNutrientRDAValue;
            UserNutrientRDAValue = userNutrientRDAValue;
            UserNutrientRDAPercentage = userNutrientRDAPercentage;
        }

        public NutrientRDA UserNutrientRDA { get; set; }

        public decimal MaxNutrientRDAValue { get; set; }

        public decimal UserNutrientRDAValue { get; set; }

        public decimal UserNutrientRDAPercentage { get; set; }

    }
}