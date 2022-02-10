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

namespace AdminDashboard.Models.SwaggerModels
{
    /// <summary>
    /// DenominationTaxesModel
    /// </summary>
    [DataContract]
        public partial class DenominationTaxesModel :  IEquatable<DenominationTaxesModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DenominationTaxesModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="taxId">taxId.</param>
        /// <param name="taxValue">taxValue.</param>
        /// <param name="paymentModeId">paymentModeId.</param>
        /// <param name="paymentMode">paymentMode.</param>
        /// <param name="taxTypeId">taxTypeId.</param>
        /// <param name="taxTypeName">taxTypeName.</param>
        /// <param name="denominationId">denominationId.</param>
        /// <param name="range">range.</param>
        /// <param name="creationDate">creationDate.</param>
        public DenominationTaxesModel(int? id = default(int?), int? taxId = default(int?), double? taxValue = default(double?), int? paymentModeId = default(int?), string paymentMode = default(string), int? taxTypeId = default(int?), string taxTypeName = default(string), int? denominationId = default(int?), string range = default(string), DateTime? creationDate = default(DateTime?))
        {
            this.Id = id;
            this.TaxId = taxId;
            this.TaxValue = taxValue;
            this.PaymentModeId = paymentModeId;
            this.PaymentMode = paymentMode;
            this.TaxTypeId = taxTypeId;
            this.TaxTypeName = taxTypeName;
            this.DenominationId = denominationId;
            this.Range = range;
            this.CreationDate = creationDate;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets TaxId
        /// </summary>
        [DataMember(Name="taxId", EmitDefaultValue=false)]
        public int? TaxId { get; set; }

        /// <summary>
        /// Gets or Sets TaxValue
        /// </summary>
        [DataMember(Name="taxValue", EmitDefaultValue=false)]
        public double? TaxValue { get; set; }

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
        /// Gets or Sets TaxTypeId
        /// </summary>
        [DataMember(Name="taxTypeId", EmitDefaultValue=false)]
        public int? TaxTypeId { get; set; }

        /// <summary>
        /// Gets or Sets TaxTypeName
        /// </summary>
        [DataMember(Name="taxTypeName", EmitDefaultValue=false)]
        public string TaxTypeName { get; set; }

        /// <summary>
        /// Gets or Sets DenominationId
        /// </summary>
        [DataMember(Name="denominationId", EmitDefaultValue=false)]
        public int? DenominationId { get; set; }

        /// <summary>
        /// Gets or Sets Range
        /// </summary>
        [DataMember(Name="range", EmitDefaultValue=false)]
        public string Range { get; set; }

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
            sb.Append("class DenominationTaxesModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TaxId: ").Append(TaxId).Append("\n");
            sb.Append("  TaxValue: ").Append(TaxValue).Append("\n");
            sb.Append("  PaymentModeId: ").Append(PaymentModeId).Append("\n");
            sb.Append("  PaymentMode: ").Append(PaymentMode).Append("\n");
            sb.Append("  TaxTypeId: ").Append(TaxTypeId).Append("\n");
            sb.Append("  TaxTypeName: ").Append(TaxTypeName).Append("\n");
            sb.Append("  DenominationId: ").Append(DenominationId).Append("\n");
            sb.Append("  Range: ").Append(Range).Append("\n");
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
            return this.Equals(input as DenominationTaxesModel);
        }

        /// <summary>
        /// Returns true if DenominationTaxesModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DenominationTaxesModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DenominationTaxesModel input)
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
                    this.TaxId == input.TaxId ||
                    (this.TaxId != null &&
                    this.TaxId.Equals(input.TaxId))
                ) && 
                (
                    this.TaxValue == input.TaxValue ||
                    (this.TaxValue != null &&
                    this.TaxValue.Equals(input.TaxValue))
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
                    this.TaxTypeId == input.TaxTypeId ||
                    (this.TaxTypeId != null &&
                    this.TaxTypeId.Equals(input.TaxTypeId))
                ) && 
                (
                    this.TaxTypeName == input.TaxTypeName ||
                    (this.TaxTypeName != null &&
                    this.TaxTypeName.Equals(input.TaxTypeName))
                ) && 
                (
                    this.DenominationId == input.DenominationId ||
                    (this.DenominationId != null &&
                    this.DenominationId.Equals(input.DenominationId))
                ) && 
                (
                    this.Range == input.Range ||
                    (this.Range != null &&
                    this.Range.Equals(input.Range))
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
                if (this.TaxId != null)
                    hashCode = hashCode * 59 + this.TaxId.GetHashCode();
                if (this.TaxValue != null)
                    hashCode = hashCode * 59 + this.TaxValue.GetHashCode();
                if (this.PaymentModeId != null)
                    hashCode = hashCode * 59 + this.PaymentModeId.GetHashCode();
                if (this.PaymentMode != null)
                    hashCode = hashCode * 59 + this.PaymentMode.GetHashCode();
                if (this.TaxTypeId != null)
                    hashCode = hashCode * 59 + this.TaxTypeId.GetHashCode();
                if (this.TaxTypeName != null)
                    hashCode = hashCode * 59 + this.TaxTypeName.GetHashCode();
                if (this.DenominationId != null)
                    hashCode = hashCode * 59 + this.DenominationId.GetHashCode();
                if (this.Range != null)
                    hashCode = hashCode * 59 + this.Range.GetHashCode();
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
