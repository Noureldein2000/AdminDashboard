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

namespace AdminDashboard.Models.SwaggerModels.SourceOFundSwaggerModels
{
    /// <summary>
    /// ManageBalanceDTO
    /// </summary>
    [DataContract]
        public partial class ManageBalanceDTO :  IEquatable<ManageBalanceDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageBalanceDTO" /> class.
        /// </summary>
        /// <param name="fromAccountId">fromAccountId (required).</param>
        /// <param name="toAccountId">toAccountId (required).</param>
        /// <param name="amount">amount (required).</param>
        /// <param name="requestId">requestId.</param>
        /// <param name="transactionId">transactionId.</param>
        /// <param name="balanceTypeId">balanceTypeId.</param>
        public ManageBalanceDTO(int? fromAccountId = default(int?), int? toAccountId = default(int?), double? amount = default(double?), int? requestId = default(int?), int? transactionId = default(int?), int? balanceTypeId = default(int?))
        {
            // to ensure "fromAccountId" is required (not null)
            if (fromAccountId == null)
            {
                throw new InvalidDataException("fromAccountId is a required property for ManageBalanceDTO and cannot be null");
            }
            else
            {
                this.FromAccountId = fromAccountId;
            }
            // to ensure "toAccountId" is required (not null)
            if (toAccountId == null)
            {
                throw new InvalidDataException("toAccountId is a required property for ManageBalanceDTO and cannot be null");
            }
            else
            {
                this.ToAccountId = toAccountId;
            }
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for ManageBalanceDTO and cannot be null");
            }
            else
            {
                this.Amount = amount;
            }
            this.RequestId = requestId;
            this.TransactionId = transactionId;
            this.BalanceTypeId = balanceTypeId;
        }
        
        /// <summary>
        /// Gets or Sets FromAccountId
        /// </summary>
        [DataMember(Name="fromAccountId", EmitDefaultValue=false)]
        public int? FromAccountId { get; set; }

        /// <summary>
        /// Gets or Sets ToAccountId
        /// </summary>
        [DataMember(Name="toAccountId", EmitDefaultValue=false)]
        public int? ToAccountId { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or Sets RequestId
        /// </summary>
        [DataMember(Name="requestId", EmitDefaultValue=false)]
        public int? RequestId { get; set; }

        /// <summary>
        /// Gets or Sets TransactionId
        /// </summary>
        [DataMember(Name="transactionId", EmitDefaultValue=false)]
        public int? TransactionId { get; set; }

        /// <summary>
        /// Gets or Sets BalanceTypeId
        /// </summary>
        [DataMember(Name="balanceTypeId", EmitDefaultValue=false)]
        public int? BalanceTypeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManageBalanceDTO {\n");
            sb.Append("  FromAccountId: ").Append(FromAccountId).Append("\n");
            sb.Append("  ToAccountId: ").Append(ToAccountId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  RequestId: ").Append(RequestId).Append("\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("  BalanceTypeId: ").Append(BalanceTypeId).Append("\n");
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
            return this.Equals(input as ManageBalanceDTO);
        }

        /// <summary>
        /// Returns true if ManageBalanceDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of ManageBalanceDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManageBalanceDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FromAccountId == input.FromAccountId ||
                    (this.FromAccountId != null &&
                    this.FromAccountId.Equals(input.FromAccountId))
                ) && 
                (
                    this.ToAccountId == input.ToAccountId ||
                    (this.ToAccountId != null &&
                    this.ToAccountId.Equals(input.ToAccountId))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.RequestId == input.RequestId ||
                    (this.RequestId != null &&
                    this.RequestId.Equals(input.RequestId))
                ) && 
                (
                    this.TransactionId == input.TransactionId ||
                    (this.TransactionId != null &&
                    this.TransactionId.Equals(input.TransactionId))
                ) && 
                (
                    this.BalanceTypeId == input.BalanceTypeId ||
                    (this.BalanceTypeId != null &&
                    this.BalanceTypeId.Equals(input.BalanceTypeId))
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
                if (this.FromAccountId != null)
                    hashCode = hashCode * 59 + this.FromAccountId.GetHashCode();
                if (this.ToAccountId != null)
                    hashCode = hashCode * 59 + this.ToAccountId.GetHashCode();
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.RequestId != null)
                    hashCode = hashCode * 59 + this.RequestId.GetHashCode();
                if (this.TransactionId != null)
                    hashCode = hashCode * 59 + this.TransactionId.GetHashCode();
                if (this.BalanceTypeId != null)
                    hashCode = hashCode * 59 + this.BalanceTypeId.GetHashCode();
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
