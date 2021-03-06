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
    /// FeesModel
    /// </summary>
    [DataContract]
        public partial class FeesModel :  IEquatable<FeesModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeesModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="feesTypeID">feesTypeID.</param>
        /// <param name="feesTypeName">feesTypeName.</param>
        /// <param name="fees">fees.</param>
        /// <param name="feeRange">feeRange.</param>
        /// <param name="amountFrom">amountFrom.</param>
        /// <param name="amountTo">amountTo.</param>
        /// <param name="paymentModeID">paymentModeID.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="paymentModeName">paymentModeName.</param>
        /// <param name="value">value.</param>
        /// <param name="status">status.</param>
        /// <param name="startDate">startDate.</param>
        /// <param name="endDate">endDate.</param>
        public FeesModel(int? id = default(int?), int? feesTypeID = default(int?), string feesTypeName = default(string), double? fees = default(double?), string feeRange = default(string), double? amountFrom = default(double?), double? amountTo = default(double?), int? paymentModeID = default(int?), int? createdBy = default(int?), string paymentModeName = default(string), double? value = default(double?), bool? status = default(bool?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?))
        {
            this.Id = id;
            this.FeesTypeID = feesTypeID;
            this.FeesTypeName = feesTypeName;
            this.Fees = fees;
            this.FeeRange = feeRange;
            this.AmountFrom = amountFrom;
            this.AmountTo = amountTo;
            this.PaymentModeID = paymentModeID;
            this.CreatedBy = createdBy;
            this.PaymentModeName = paymentModeName;
            this.Value = value;
            this.Status = status;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets FeesTypeID
        /// </summary>
        [DataMember(Name="feesTypeID", EmitDefaultValue=false)]
        public int? FeesTypeID { get; set; }

        /// <summary>
        /// Gets or Sets FeesTypeName
        /// </summary>
        [DataMember(Name="feesTypeName", EmitDefaultValue=false)]
        public string FeesTypeName { get; set; }

        /// <summary>
        /// Gets or Sets Fees
        /// </summary>
        [DataMember(Name="fees", EmitDefaultValue=false)]
        public double? Fees { get; set; }

        /// <summary>
        /// Gets or Sets FeeRange
        /// </summary>
        [DataMember(Name="feeRange", EmitDefaultValue=false)]
        public string FeeRange { get; set; }

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
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets PaymentModeName
        /// </summary>
        [DataMember(Name="paymentModeName", EmitDefaultValue=false)]
        public string PaymentModeName { get; set; }

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
        /// Gets or Sets StartDate
        /// </summary>
        [DataMember(Name="startDate", EmitDefaultValue=false)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        [DataMember(Name="endDate", EmitDefaultValue=false)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FeesModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FeesTypeID: ").Append(FeesTypeID).Append("\n");
            sb.Append("  FeesTypeName: ").Append(FeesTypeName).Append("\n");
            sb.Append("  Fees: ").Append(Fees).Append("\n");
            sb.Append("  FeeRange: ").Append(FeeRange).Append("\n");
            sb.Append("  AmountFrom: ").Append(AmountFrom).Append("\n");
            sb.Append("  AmountTo: ").Append(AmountTo).Append("\n");
            sb.Append("  PaymentModeID: ").Append(PaymentModeID).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  PaymentModeName: ").Append(PaymentModeName).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
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
            return this.Equals(input as FeesModel);
        }

        /// <summary>
        /// Returns true if FeesModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FeesModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FeesModel input)
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
                    this.FeesTypeID == input.FeesTypeID ||
                    (this.FeesTypeID != null &&
                    this.FeesTypeID.Equals(input.FeesTypeID))
                ) && 
                (
                    this.FeesTypeName == input.FeesTypeName ||
                    (this.FeesTypeName != null &&
                    this.FeesTypeName.Equals(input.FeesTypeName))
                ) && 
                (
                    this.Fees == input.Fees ||
                    (this.Fees != null &&
                    this.Fees.Equals(input.Fees))
                ) && 
                (
                    this.FeeRange == input.FeeRange ||
                    (this.FeeRange != null &&
                    this.FeeRange.Equals(input.FeeRange))
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
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.PaymentModeName == input.PaymentModeName ||
                    (this.PaymentModeName != null &&
                    this.PaymentModeName.Equals(input.PaymentModeName))
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
                ) && 
                (
                    this.StartDate == input.StartDate ||
                    (this.StartDate != null &&
                    this.StartDate.Equals(input.StartDate))
                ) && 
                (
                    this.EndDate == input.EndDate ||
                    (this.EndDate != null &&
                    this.EndDate.Equals(input.EndDate))
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
                if (this.FeesTypeID != null)
                    hashCode = hashCode * 59 + this.FeesTypeID.GetHashCode();
                if (this.FeesTypeName != null)
                    hashCode = hashCode * 59 + this.FeesTypeName.GetHashCode();
                if (this.Fees != null)
                    hashCode = hashCode * 59 + this.Fees.GetHashCode();
                if (this.FeeRange != null)
                    hashCode = hashCode * 59 + this.FeeRange.GetHashCode();
                if (this.AmountFrom != null)
                    hashCode = hashCode * 59 + this.AmountFrom.GetHashCode();
                if (this.AmountTo != null)
                    hashCode = hashCode * 59 + this.AmountTo.GetHashCode();
                if (this.PaymentModeID != null)
                    hashCode = hashCode * 59 + this.PaymentModeID.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.PaymentModeName != null)
                    hashCode = hashCode * 59 + this.PaymentModeName.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
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
