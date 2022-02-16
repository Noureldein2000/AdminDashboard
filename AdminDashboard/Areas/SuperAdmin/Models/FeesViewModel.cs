﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdminDashboard.Helper;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class FeesViewModel
    {
        public int ID { get; set; }
        [Required]
        [EnumDataType(typeof(FeesType), ErrorMessage = "You Should choose a Fee Type")]
        public FeesType FeesTypeID { get; set; }
        public string FeesTypeName { get; set; }
        public decimal Fees { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal AmountFrom { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal AmountTo { get; set; }
        [Required]
        [EnumDataType(typeof(PaymentMode), ErrorMessage = "You Should choose a Mode")]
        public PaymentMode PaymentModeID { get; set; }
        public int CreatedBy { get; set; }
        public string PaymentModeName { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Value { get; set; }
        public bool Status { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
    }
}
