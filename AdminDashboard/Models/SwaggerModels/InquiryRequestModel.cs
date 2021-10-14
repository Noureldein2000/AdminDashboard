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
    /// InquiryRequestModel
    /// </summary>
    [DataContract]
        public partial class InquiryRequestModel :  IEquatable<InquiryRequestModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InquiryRequestModel" /> class.
        /// </summary>
        /// <param name="billingAccount">billingAccount.</param>
        /// <param name="version">version.</param>
        /// <param name="serviceListVersion">serviceListVersion.</param>
        /// <param name="data">data.</param>
        public InquiryRequestModel(string billingAccount = default(string), string version = default(string), string serviceListVersion = default(string), List<DataModel> data = default(List<DataModel>))
        {
            this.BillingAccount = billingAccount;
            this.Version = version;
            this.ServiceListVersion = serviceListVersion;
            this.Data = data;
        }
        
        /// <summary>
        /// Gets or Sets BillingAccount
        /// </summary>
        [DataMember(Name="billingAccount", EmitDefaultValue=false)]
        public string BillingAccount { get; set; }

        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public string Version { get; set; }

        /// <summary>
        /// Gets or Sets ServiceListVersion
        /// </summary>
        [DataMember(Name="serviceListVersion", EmitDefaultValue=false)]
        public string ServiceListVersion { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public List<DataModel> Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InquiryRequestModel {\n");
            sb.Append("  BillingAccount: ").Append(BillingAccount).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  ServiceListVersion: ").Append(ServiceListVersion).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
            return this.Equals(input as InquiryRequestModel);
        }

        /// <summary>
        /// Returns true if InquiryRequestModel instances are equal
        /// </summary>
        /// <param name="input">Instance of InquiryRequestModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InquiryRequestModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BillingAccount == input.BillingAccount ||
                    (this.BillingAccount != null &&
                    this.BillingAccount.Equals(input.BillingAccount))
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) && 
                (
                    this.ServiceListVersion == input.ServiceListVersion ||
                    (this.ServiceListVersion != null &&
                    this.ServiceListVersion.Equals(input.ServiceListVersion))
                ) && 
                (
                    this.Data == input.Data ||
                    this.Data != null &&
                    input.Data != null &&
                    this.Data.SequenceEqual(input.Data)
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
                if (this.BillingAccount != null)
                    hashCode = hashCode * 59 + this.BillingAccount.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.ServiceListVersion != null)
                    hashCode = hashCode * 59 + this.ServiceListVersion.GetHashCode();
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
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