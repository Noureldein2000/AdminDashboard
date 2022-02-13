/* 
 * API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = AdminDashboard.SwaggerClientHelpers.SwaggerDateConverter;

namespace AdminDashboard.Models.SwaggerModels
{
    /// <summary>
    /// Defines LookupType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
        public enum LookupType
    {
        /// <summary>
        /// Enum FeesType for value: FeesType
        /// </summary>
        [EnumMember(Value = "FeesType")]
        FeesType = 1,
        /// <summary>
        /// Enum CommissionType for value: CommissionType
        /// </summary>
        [EnumMember(Value = "CommissionType")]
        CommissionType = 2,
        /// <summary>
        /// Enum TaxesType for value: TaxesType
        /// </summary>
        [EnumMember(Value = "TaxesType")]
        TaxesType = 3,
        /// <summary>
        /// Enum ServiceType for value: ServiceType
        /// </summary>
        [EnumMember(Value = "ServiceType")]
        ServiceType = 4    }
}
