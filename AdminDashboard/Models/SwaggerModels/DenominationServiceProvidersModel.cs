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
    /// DenominationServiceProvidersModel
    /// </summary>
    [DataContract]
        public partial class DenominationServiceProvidersModel :  IEquatable<DenominationServiceProvidersModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DenominationServiceProvidersModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="denominationId">denominationId.</param>
        /// <param name="serviceProviderId">serviceProviderId.</param>
        /// <param name="serviceConfigerationId">serviceConfigerationId.</param>
        /// <param name="serviceProviderName">serviceProviderName.</param>
        /// <param name="balance">balance.</param>
        /// <param name="status">status.</param>
        /// <param name="providerCode">providerCode.</param>
        /// <param name="providerAmount">providerAmount.</param>
        /// <param name="oldServiceId">oldServiceId.</param>
        /// <param name="providerHasFees">providerHasFees.</param>
        /// <param name="denominationProviderConfigurationModel">denominationProviderConfigurationModel.</param>
        public DenominationServiceProvidersModel(int? id = default(int?), int? denominationId = default(int?), int? serviceProviderId = default(int?), int? serviceConfigerationId = default(int?), string serviceProviderName = default(string), double? balance = default(double?), bool? status = default(bool?), string providerCode = default(string), double? providerAmount = default(double?), int? oldServiceId = default(int?), bool? providerHasFees = default(bool?), List<DenominationProviderConfigerationModel> denominationProviderConfigurationModel = default(List<DenominationProviderConfigerationModel>))
        {
            this.Id = id;
            this.DenominationId = denominationId;
            this.ServiceProviderId = serviceProviderId;
            this.ServiceConfigerationId = serviceConfigerationId;
            this.ServiceProviderName = serviceProviderName;
            this.Balance = balance;
            this.Status = status;
            this.ProviderCode = providerCode;
            this.ProviderAmount = providerAmount;
            this.OldServiceId = oldServiceId;
            this.ProviderHasFees = providerHasFees;
            this.DenominationProviderConfigurationModel = denominationProviderConfigurationModel;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets DenominationId
        /// </summary>
        [DataMember(Name="denominationId", EmitDefaultValue=false)]
        public int? DenominationId { get; set; }

        /// <summary>
        /// Gets or Sets ServiceProviderId
        /// </summary>
        [DataMember(Name="serviceProviderId", EmitDefaultValue=false)]
        public int? ServiceProviderId { get; set; }

        /// <summary>
        /// Gets or Sets ServiceConfigerationId
        /// </summary>
        [DataMember(Name="serviceConfigerationId", EmitDefaultValue=false)]
        public int? ServiceConfigerationId { get; set; }

        /// <summary>
        /// Gets or Sets ServiceProviderName
        /// </summary>
        [DataMember(Name="serviceProviderName", EmitDefaultValue=false)]
        public string ServiceProviderName { get; set; }

        /// <summary>
        /// Gets or Sets Balance
        /// </summary>
        [DataMember(Name="balance", EmitDefaultValue=false)]
        public double? Balance { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or Sets ProviderCode
        /// </summary>
        [DataMember(Name="providerCode", EmitDefaultValue=false)]
        public string ProviderCode { get; set; }

        /// <summary>
        /// Gets or Sets ProviderAmount
        /// </summary>
        [DataMember(Name="providerAmount", EmitDefaultValue=false)]
        public double? ProviderAmount { get; set; }

        /// <summary>
        /// Gets or Sets OldServiceId
        /// </summary>
        [DataMember(Name="oldServiceId", EmitDefaultValue=false)]
        public int? OldServiceId { get; set; }

        /// <summary>
        /// Gets or Sets ProviderHasFees
        /// </summary>
        [DataMember(Name="providerHasFees", EmitDefaultValue=false)]
        public bool? ProviderHasFees { get; set; }

        /// <summary>
        /// Gets or Sets DenominationProviderConfigurationModel
        /// </summary>
        [DataMember(Name="denominationProviderConfigurationModel", EmitDefaultValue=false)]
        public List<DenominationProviderConfigerationModel> DenominationProviderConfigurationModel { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DenominationServiceProvidersModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DenominationId: ").Append(DenominationId).Append("\n");
            sb.Append("  ServiceProviderId: ").Append(ServiceProviderId).Append("\n");
            sb.Append("  ServiceConfigerationId: ").Append(ServiceConfigerationId).Append("\n");
            sb.Append("  ServiceProviderName: ").Append(ServiceProviderName).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ProviderCode: ").Append(ProviderCode).Append("\n");
            sb.Append("  ProviderAmount: ").Append(ProviderAmount).Append("\n");
            sb.Append("  OldServiceId: ").Append(OldServiceId).Append("\n");
            sb.Append("  ProviderHasFees: ").Append(ProviderHasFees).Append("\n");
            sb.Append("  DenominationProviderConfigurationModel: ").Append(DenominationProviderConfigurationModel).Append("\n");
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
            return this.Equals(input as DenominationServiceProvidersModel);
        }

        /// <summary>
        /// Returns true if DenominationServiceProvidersModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DenominationServiceProvidersModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DenominationServiceProvidersModel input)
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
                    this.DenominationId == input.DenominationId ||
                    (this.DenominationId != null &&
                    this.DenominationId.Equals(input.DenominationId))
                ) && 
                (
                    this.ServiceProviderId == input.ServiceProviderId ||
                    (this.ServiceProviderId != null &&
                    this.ServiceProviderId.Equals(input.ServiceProviderId))
                ) && 
                (
                    this.ServiceConfigerationId == input.ServiceConfigerationId ||
                    (this.ServiceConfigerationId != null &&
                    this.ServiceConfigerationId.Equals(input.ServiceConfigerationId))
                ) && 
                (
                    this.ServiceProviderName == input.ServiceProviderName ||
                    (this.ServiceProviderName != null &&
                    this.ServiceProviderName.Equals(input.ServiceProviderName))
                ) && 
                (
                    this.Balance == input.Balance ||
                    (this.Balance != null &&
                    this.Balance.Equals(input.Balance))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.ProviderCode == input.ProviderCode ||
                    (this.ProviderCode != null &&
                    this.ProviderCode.Equals(input.ProviderCode))
                ) && 
                (
                    this.ProviderAmount == input.ProviderAmount ||
                    (this.ProviderAmount != null &&
                    this.ProviderAmount.Equals(input.ProviderAmount))
                ) && 
                (
                    this.OldServiceId == input.OldServiceId ||
                    (this.OldServiceId != null &&
                    this.OldServiceId.Equals(input.OldServiceId))
                ) && 
                (
                    this.ProviderHasFees == input.ProviderHasFees ||
                    (this.ProviderHasFees != null &&
                    this.ProviderHasFees.Equals(input.ProviderHasFees))
                ) && 
                (
                    this.DenominationProviderConfigurationModel == input.DenominationProviderConfigurationModel ||
                    this.DenominationProviderConfigurationModel != null &&
                    input.DenominationProviderConfigurationModel != null &&
                    this.DenominationProviderConfigurationModel.SequenceEqual(input.DenominationProviderConfigurationModel)
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
                if (this.DenominationId != null)
                    hashCode = hashCode * 59 + this.DenominationId.GetHashCode();
                if (this.ServiceProviderId != null)
                    hashCode = hashCode * 59 + this.ServiceProviderId.GetHashCode();
                if (this.ServiceConfigerationId != null)
                    hashCode = hashCode * 59 + this.ServiceConfigerationId.GetHashCode();
                if (this.ServiceProviderName != null)
                    hashCode = hashCode * 59 + this.ServiceProviderName.GetHashCode();
                if (this.Balance != null)
                    hashCode = hashCode * 59 + this.Balance.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.ProviderCode != null)
                    hashCode = hashCode * 59 + this.ProviderCode.GetHashCode();
                if (this.ProviderAmount != null)
                    hashCode = hashCode * 59 + this.ProviderAmount.GetHashCode();
                if (this.OldServiceId != null)
                    hashCode = hashCode * 59 + this.OldServiceId.GetHashCode();
                if (this.ProviderHasFees != null)
                    hashCode = hashCode * 59 + this.ProviderHasFees.GetHashCode();
                if (this.DenominationProviderConfigurationModel != null)
                    hashCode = hashCode * 59 + this.DenominationProviderConfigurationModel.GetHashCode();
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
