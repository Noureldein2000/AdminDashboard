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
    /// DenominationCommissionModel
    /// </summary>
    [DataContract]
        public partial class DenominationCommissionModel :  IEquatable<DenominationCommissionModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DenominationCommissionModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="commissionId">commissionId.</param>
        /// <param name="commissionValue">commissionValue.</param>
        /// <param name="paymentModeId">paymentModeId.</param>
        /// <param name="paymentMode">paymentMode.</param>
        /// <param name="commissionTypeId">commissionTypeId.</param>
        /// <param name="commissionTypeName">commissionTypeName.</param>
        /// <param name="denominationId">denominationId.</param>
        /// <param name="denominationFullName">denominationFullName.</param>
        /// <param name="creationDate">creationDate.</param>
        public DenominationCommissionModel(int? id = default(int?), int? commissionId = default(int?), double? commissionValue = default(double?), int? paymentModeId = default(int?), string paymentMode = default(string), int? commissionTypeId = default(int?), string commissionTypeName = default(string), int? denominationId = default(int?), string denominationFullName = default(string), DateTime? creationDate = default(DateTime?))
        {
            this.Id = id;
            this.CommissionId = commissionId;
            this.CommissionValue = commissionValue;
            this.PaymentModeId = paymentModeId;
            this.PaymentMode = paymentMode;
            this.CommissionTypeId = commissionTypeId;
            this.CommissionTypeName = commissionTypeName;
            this.DenominationId = denominationId;
            this.DenominationFullName = denominationFullName;
            this.CreationDate = creationDate;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets CommissionId
        /// </summary>
        [DataMember(Name="commissionId", EmitDefaultValue=false)]
        public int? CommissionId { get; set; }

        /// <summary>
        /// Gets or Sets CommissionValue
        /// </summary>
        [DataMember(Name="commissionValue", EmitDefaultValue=false)]
        public double? CommissionValue { get; set; }

        /// <summary>
        /// Gets or Sets PaymentModeId
        /// </summary>
        [DataMember(Name="paymentModeId", EmitDefaultValue=false)]
        public int? PaymentModeId { get; set; }

        /// <summary>
        /// Gets or Sets PaymentMode
        /// </summary>
        [DataMember(Name="paymentMode", EmitDefaultValue=false)]
        public string PaymentMode { get; set; }

        /// <summary>
        /// Gets or Sets CommissionTypeId
        /// </summary>
        [DataMember(Name="commissionTypeId", EmitDefaultValue=false)]
        public int? CommissionTypeId { get; set; }

        /// <summary>
        /// Gets or Sets CommissionTypeName
        /// </summary>
        [DataMember(Name="commissionTypeName", EmitDefaultValue=false)]
        public string CommissionTypeName { get; set; }

        /// <summary>
        /// Gets or Sets DenominationId
        /// </summary>
        [DataMember(Name="denominationId", EmitDefaultValue=false)]
        public int? DenominationId { get; set; }

        /// <summary>
        /// Gets or Sets DenominationFullName
        /// </summary>
        [DataMember(Name="denominationFullName", EmitDefaultValue=false)]
        public string DenominationFullName { get; set; }

        /// <summary>
        /// Gets or Sets CreationDate
        /// </summary>
        [DataMember(Name="creationDate", EmitDefaultValue=false)]
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DenominationCommissionModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CommissionId: ").Append(CommissionId).Append("\n");
            sb.Append("  CommissionValue: ").Append(CommissionValue).Append("\n");
            sb.Append("  PaymentModeId: ").Append(PaymentModeId).Append("\n");
            sb.Append("  PaymentMode: ").Append(PaymentMode).Append("\n");
            sb.Append("  CommissionTypeId: ").Append(CommissionTypeId).Append("\n");
            sb.Append("  CommissionTypeName: ").Append(CommissionTypeName).Append("\n");
            sb.Append("  DenominationId: ").Append(DenominationId).Append("\n");
            sb.Append("  DenominationFullName: ").Append(DenominationFullName).Append("\n");
            sb.Append("  CreationDate: ").Append(CreationDate).Append("\n");
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
            return this.Equals(input as DenominationCommissionModel);
        }

        /// <summary>
        /// Returns true if DenominationCommissionModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DenominationCommissionModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DenominationCommissionModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.CommissionId == input.CommissionId ||
                    (this.CommissionId != null &&
                    this.CommissionId.Equals(input.CommissionId))
                ) && 
                (
                    this.CommissionValue == input.CommissionValue ||
                    (this.CommissionValue != null &&
                    this.CommissionValue.Equals(input.CommissionValue))
                ) && 
                (
                    this.PaymentModeId == input.PaymentModeId ||
                    (this.PaymentModeId != null &&
                    this.PaymentModeId.Equals(input.PaymentModeId))
                ) && 
                (
                    this.PaymentMode == input.PaymentMode ||
                    (this.PaymentMode != null &&
                    this.PaymentMode.Equals(input.PaymentMode))
                ) && 
                (
                    this.CommissionTypeId == input.CommissionTypeId ||
                    (this.CommissionTypeId != null &&
                    this.CommissionTypeId.Equals(input.CommissionTypeId))
                ) && 
                (
                    this.CommissionTypeName == input.CommissionTypeName ||
                    (this.CommissionTypeName != null &&
                    this.CommissionTypeName.Equals(input.CommissionTypeName))
                ) && 
                (
                    this.DenominationId == input.DenominationId ||
                    (this.DenominationId != null &&
                    this.DenominationId.Equals(input.DenominationId))
                ) && 
                (
                    this.DenominationFullName == input.DenominationFullName ||
                    (this.DenominationFullName != null &&
                    this.DenominationFullName.Equals(input.DenominationFullName))
                ) && 
                (
                    this.CreationDate == input.CreationDate ||
                    (this.CreationDate != null &&
                    this.CreationDate.Equals(input.CreationDate))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.CommissionId != null)
                    hashCode = hashCode * 59 + this.CommissionId.GetHashCode();
                if (this.CommissionValue != null)
                    hashCode = hashCode * 59 + this.CommissionValue.GetHashCode();
                if (this.PaymentModeId != null)
                    hashCode = hashCode * 59 + this.PaymentModeId.GetHashCode();
                if (this.PaymentMode != null)
                    hashCode = hashCode * 59 + this.PaymentMode.GetHashCode();
                if (this.CommissionTypeId != null)
                    hashCode = hashCode * 59 + this.CommissionTypeId.GetHashCode();
                if (this.CommissionTypeName != null)
                    hashCode = hashCode * 59 + this.CommissionTypeName.GetHashCode();
                if (this.DenominationId != null)
                    hashCode = hashCode * 59 + this.DenominationId.GetHashCode();
                if (this.DenominationFullName != null)
                    hashCode = hashCode * 59 + this.DenominationFullName.GetHashCode();
                if (this.CreationDate != null)
                    hashCode = hashCode * 59 + this.CreationDate.GetHashCode();
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