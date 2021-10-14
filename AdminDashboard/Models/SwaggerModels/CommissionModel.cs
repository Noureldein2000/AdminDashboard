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
    /// CommissionModel
    /// </summary>
    [DataContract]
        public partial class CommissionModel :  IEquatable<CommissionModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommissionModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="commissionTypeID">commissionTypeID.</param>
        /// <param name="commissionTypeName">commissionTypeName.</param>
        /// <param name="commissionRange">commissionRange.</param>
        /// <param name="commission">commission.</param>
        /// <param name="amountFrom">amountFrom.</param>
        /// <param name="amountTo">amountTo.</param>
        /// <param name="paymentModeID">paymentModeID.</param>
        /// <param name="value">value.</param>
        /// <param name="status">status.</param>
        public CommissionModel(int? id = default(int?), int? commissionTypeID = default(int?), string commissionTypeName = default(string), string commissionRange = default(string), double? commission = default(double?), double? amountFrom = default(double?), double? amountTo = default(double?), int? paymentModeID = default(int?), double? value = default(double?), bool? status = default(bool?))
        {
            this.Id = id;
            this.CommissionTypeID = commissionTypeID;
            this.CommissionTypeName = commissionTypeName;
            this.CommissionRange = commissionRange;
            this.Commission = commission;
            this.AmountFrom = amountFrom;
            this.AmountTo = amountTo;
            this.PaymentModeID = paymentModeID;
            this.Value = value;
            this.Status = status;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets CommissionTypeID
        /// </summary>
        [DataMember(Name="commissionTypeID", EmitDefaultValue=false)]
        public int? CommissionTypeID { get; set; }

        /// <summary>
        /// Gets or Sets CommissionTypeName
        /// </summary>
        [DataMember(Name="commissionTypeName", EmitDefaultValue=false)]
        public string CommissionTypeName { get; set; }

        /// <summary>
        /// Gets or Sets CommissionRange
        /// </summary>
        [DataMember(Name="commissionRange", EmitDefaultValue=false)]
        public string CommissionRange { get; set; }

        /// <summary>
        /// Gets or Sets Commission
        /// </summary>
        [DataMember(Name="commission", EmitDefaultValue=false)]
        public double? Commission { get; set; }

        /// <summary>
        /// Gets or Sets AmountFrom
        /// </summary>
        [DataMember(Name="amountFrom", EmitDefaultValue=false)]
        public double? AmountFrom { get; set; }

        /// <summary>
        /// Gets or Sets AmountTo
        /// </summary>
        [DataMember(Name="amountTo", EmitDefaultValue=false)]
        public double? AmountTo { get; set; }

        /// <summary>
        /// Gets or Sets PaymentModeID
        /// </summary>
        [DataMember(Name="paymentModeID", EmitDefaultValue=false)]
        public int? PaymentModeID { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public double? Value { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public bool? Status { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CommissionModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CommissionTypeID: ").Append(CommissionTypeID).Append("\n");
            sb.Append("  CommissionTypeName: ").Append(CommissionTypeName).Append("\n");
            sb.Append("  CommissionRange: ").Append(CommissionRange).Append("\n");
            sb.Append("  Commission: ").Append(Commission).Append("\n");
            sb.Append("  AmountFrom: ").Append(AmountFrom).Append("\n");
            sb.Append("  AmountTo: ").Append(AmountTo).Append("\n");
            sb.Append("  PaymentModeID: ").Append(PaymentModeID).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as CommissionModel);
        }

        /// <summary>
        /// Returns true if CommissionModel instances are equal
        /// </summary>
        /// <param name="input">Instance of CommissionModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CommissionModel input)
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
                    this.CommissionTypeID == input.CommissionTypeID ||
                    (this.CommissionTypeID != null &&
                    this.CommissionTypeID.Equals(input.CommissionTypeID))
                ) && 
                (
                    this.CommissionTypeName == input.CommissionTypeName ||
                    (this.CommissionTypeName != null &&
                    this.CommissionTypeName.Equals(input.CommissionTypeName))
                ) && 
                (
                    this.CommissionRange == input.CommissionRange ||
                    (this.CommissionRange != null &&
                    this.CommissionRange.Equals(input.CommissionRange))
                ) && 
                (
                    this.Commission == input.Commission ||
                    (this.Commission != null &&
                    this.Commission.Equals(input.Commission))
                ) && 
                (
                    this.AmountFrom == input.AmountFrom ||
                    (this.AmountFrom != null &&
                    this.AmountFrom.Equals(input.AmountFrom))
                ) && 
                (
                    this.AmountTo == input.AmountTo ||
                    (this.AmountTo != null &&
                    this.AmountTo.Equals(input.AmountTo))
                ) && 
                (
                    this.PaymentModeID == input.PaymentModeID ||
                    (this.PaymentModeID != null &&
                    this.PaymentModeID.Equals(input.PaymentModeID))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
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
                if (this.CommissionTypeID != null)
                    hashCode = hashCode * 59 + this.CommissionTypeID.GetHashCode();
                if (this.CommissionTypeName != null)
                    hashCode = hashCode * 59 + this.CommissionTypeName.GetHashCode();
                if (this.CommissionRange != null)
                    hashCode = hashCode * 59 + this.CommissionRange.GetHashCode();
                if (this.Commission != null)
                    hashCode = hashCode * 59 + this.Commission.GetHashCode();
                if (this.AmountFrom != null)
                    hashCode = hashCode * 59 + this.AmountFrom.GetHashCode();
                if (this.AmountTo != null)
                    hashCode = hashCode * 59 + this.AmountTo.GetHashCode();
                if (this.PaymentModeID != null)
                    hashCode = hashCode * 59 + this.PaymentModeID.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
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