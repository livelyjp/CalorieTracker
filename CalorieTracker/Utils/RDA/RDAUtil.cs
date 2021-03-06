﻿using System;
using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.RDA
{
    public class RDAUtil
    {
        private readonly Nutrient _nutrient;
        private readonly User _user;
        private TimeSpan _currentTimeSpan;

        private decimal _maxRDAValue;
        private NutrientRDA _userNutrientRDA;
        private decimal _userNutrientRDAPercentage;
        private decimal _userNutrientRDAValue;


        public RDAUtil(User user, Nutrient nutrient, TimeSpan currentTimeSpan)
        {
            _user = user;
            _nutrient = nutrient;
            _currentTimeSpan = currentTimeSpan;
            StartCalculation();
        }

        public decimal UserNutrientRDAValue
        {
            get { return _userNutrientRDAValue; }
            set { _userNutrientRDAValue = value; }
        }

        public decimal MaxRDAValue
        {
            get { return _maxRDAValue; }
            set { _maxRDAValue = value; }
        }

        public decimal UserNutrientRDAPercentage
        {
            get { return _userNutrientRDAPercentage; }
            set { _userNutrientRDAPercentage = value; }
        }

        public NutrientRDA UserNutrientRDA
        {
            get { return _userNutrientRDA; }
            set { _userNutrientRDA = value; }
        }

        public TimeSpan CurrentTimeSpan
        {
            get { return _currentTimeSpan; }
            set { _currentTimeSpan = value; }
        }

        public User User
        {
            get { return _user; }
        }

        public Nutrient Nutrient
        {
            get { return _nutrient; }
        }

        public decimal GetRDAValueForTimespan()
        {
            _maxRDAValue = _userNutrientRDA.Value*_currentTimeSpan.Days;
            return _maxRDAValue;
        }

        private void StartCalculation()
        {
            _userNutrientRDA = NutrientRDAUtil.GetNutrientRDAForUser(_user, _nutrient);
            if (_userNutrientRDA != null)
            {
                _userNutrientRDAValue = GetUserNutrientValueCount();
                _userNutrientRDAPercentage = (_userNutrientRDAValue/GetRDAValueForTimespan())*100;
            }
        }

        private decimal GetUserNutrientValueCount()
        {
            decimal nutrientValueCount = 0;
            if (_userNutrientRDA != null)
            {
                DateTime earliestLogDateTime = DateTime.Now.AddDays(-_currentTimeSpan.Days);

                List<FoodLog> userFoodLogs =
                    _user.UserFoodLogs.Where(fL => fL.CreationTimestamp.CompareTo(earliestLogDateTime) > 0).ToList();
                //Get all food logs for the user that since before this timespan

                for (int i = 0; i < userFoodLogs.Count(); i++)
                {
                    FoodLog foodLog = userFoodLogs.ElementAt(i);
                    FoodNutritionLogs foodNutritionLog = foodLog.Food.FoodNutritionLogs.FirstOrDefault(
                        fNL => fNL.NurtientID == _userNutrientRDA.NutrientID);
                    if (foodNutritionLog != null) nutrientValueCount += foodNutritionLog.Value;
                }
            }
            return nutrientValueCount;
        }
    }
}