﻿using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.MetaData;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (MetricMetaData))]
    public partial class Metric
    {
    }
}