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
    /// DenominationReceiptModel
    /// </summary>
    [DataContract]
        public partial class DenominationReceiptModel :  IEquatable<DenominationReceiptModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DenominationReceiptModel" /> class.
        /// </summary>
        /// <param name="denominationReceiptData">denominationReceiptData.</param>
        /// <param name="denominationReceiptParams">denominationReceiptParams.</param>
        public DenominationReceiptModel(DenominationReceiptDataModel denominationReceiptData = default(DenominationReceiptDataModel), List<DenominationReceiptParamModel> denominationReceiptParams = default(List<DenominationReceiptParamModel>))
        {
            this.DenominationReceiptData = denominationReceiptData;
            this.DenominationReceiptParams = denominationReceiptParams;
        }
        
        /// <summary>
        /// Gets or Sets DenominationReceiptData
        /// </summary>
        [DataMember(Name="denominationReceiptData", EmitDefaultValue=false)]
        public DenominationReceiptDataModel DenominationReceiptData { get; set; }

        /// <summary>
        /// Gets or Sets DenominationReceiptParams
        /// </summary>
        [DataMember(Name="denominationReceiptParams", EmitDefaultValue=false)]
        public List<DenominationReceiptParamModel> DenominationReceiptParams { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DenominationReceiptModel {\n");
            sb.Append("  DenominationReceiptData: ").Append(DenominationReceiptData).Append("\n");
            sb.Append("  DenominationReceiptParams: ").Append(DenominationReceiptParams).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DenominationReceiptModel);
        }

        /// <summary>
        /// Returns true if DenominationReceiptModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DenominationReceiptModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DenominationReceiptModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DenominationReceiptData == input.DenominationReceiptData ||
                    (this.DenominationReceiptData != null &&
                    this.DenominationReceiptData.Equals(input.DenominationReceiptData))
                ) && 
                (
                    this.DenominationReceiptParams == input.DenominationReceiptParams ||
                    this.DenominationReceiptParams != null &&
                    input.DenominationReceiptParams != null &&
                    this.DenominationReceiptParams.SequenceEqual(input.DenominationReceiptParams)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.DenominationReceiptData != null)
                    hashCode = hashCode * 59 + this.DenominationReceiptData.GetHashCode();
                if (this.DenominationReceiptParams != null)
                    hashCode = hashCode * 59 + this.DenominationReceiptParams.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
