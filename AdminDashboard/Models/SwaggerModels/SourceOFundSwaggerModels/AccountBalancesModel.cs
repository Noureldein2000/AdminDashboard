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
    /// AccountBalancesModel
    /// </summary>
    [DataContract]
        public partial class AccountBalancesModel :  IEquatable<AccountBalancesModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBalancesModel" /> class.
        /// </summary>
        /// <param name="totalBalance">totalBalance.</param>
        /// <param name="totalAvailableBalance">totalAvailableBalance.</param>
        /// <param name="balanceType">balanceType.</param>
        /// <param name="balanceTypeId">balanceTypeId.</param>
        public AccountBalancesModel(double? totalBalance = default(double?), double? totalAvailableBalance = default(double?), string balanceType = default(string), int? balanceTypeId = default(int?))
        {
            this.TotalBalance = totalBalance;
            this.TotalAvailableBalance = totalAvailableBalance;
            this.BalanceType = balanceType;
            this.BalanceTypeId = balanceTypeId;
        }
        
        /// <summary>
        /// Gets or Sets TotalBalance
        /// </summary>
        [DataMember(Name="totalBalance", EmitDefaultValue=false)]
        public double? TotalBalance { get; set; }

        /// <summary>
        /// Gets or Sets TotalAvailableBalance
        /// </summary>
        [DataMember(Name="totalAvailableBalance", EmitDefaultValue=false)]
        public double? TotalAvailableBalance { get; set; }

        /// <summary>
        /// Gets or Sets BalanceType
        /// </summary>
        [DataMember(Name="balanceType", EmitDefaultValue=false)]
        public string BalanceType { get; set; }

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
            sb.Append("class AccountBalancesModel {\n");
            sb.Append("  TotalBalance: ").Append(TotalBalance).Append("\n");
            sb.Append("  TotalAvailableBalance: ").Append(TotalAvailableBalance).Append("\n");
            sb.Append("  BalanceType: ").Append(BalanceType).Append("\n");
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
            return this.Equals(input as AccountBalancesModel);
        }

        /// <summary>
        /// Returns true if AccountBalancesModel instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountBalancesModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountBalancesModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.TotalBalance == input.TotalBalance ||
                    (this.TotalBalance != null &&
                    this.TotalBalance.Equals(input.TotalBalance))
                ) && 
                (
                    this.TotalAvailableBalance == input.TotalAvailableBalance ||
                    (this.TotalAvailableBalance != null &&
                    this.TotalAvailableBalance.Equals(input.TotalAvailableBalance))
                ) && 
                (
                    this.BalanceType == input.BalanceType ||
                    (this.BalanceType != null &&
                    this.BalanceType.Equals(input.BalanceType))
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
                if (this.TotalBalance != null)
                    hashCode = hashCode * 59 + this.TotalBalance.GetHashCode();
                if (this.TotalAvailableBalance != null)
                    hashCode = hashCode * 59 + this.TotalAvailableBalance.GetHashCode();
                if (this.BalanceType != null)
                    hashCode = hashCode * 59 + this.BalanceType.GetHashCode();
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
