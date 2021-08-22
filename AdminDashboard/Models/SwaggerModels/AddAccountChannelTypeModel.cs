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
    /// AddAccountChannelTypeModel
    /// </summary>
    [DataContract]
        public partial class AddAccountChannelTypeModel :  IEquatable<AddAccountChannelTypeModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddAccountChannelTypeModel" /> class.
        /// </summary>
        /// <param name="accountID">accountID (required).</param>
        /// <param name="channelTypeID">channelTypeID (required).</param>
        /// <param name="hasLimitedAccess">hasLimitedAccess.</param>
        /// <param name="expirationPeriod">expirationPeriod (required).</param>
        public AddAccountChannelTypeModel(int? accountID = default(int?), int? channelTypeID = default(int?), bool? hasLimitedAccess = default(bool?), int? expirationPeriod = default(int?))
        {
            // to ensure "accountID" is required (not null)
            if (accountID == null)
            {
                throw new InvalidDataException("accountID is a required property for AddAccountChannelTypeModel and cannot be null");
            }
            else
            {
                this.AccountID = accountID;
            }
            // to ensure "channelTypeID" is required (not null)
            if (channelTypeID == null)
            {
                throw new InvalidDataException("channelTypeID is a required property for AddAccountChannelTypeModel and cannot be null");
            }
            else
            {
                this.ChannelTypeID = channelTypeID;
            }
            // to ensure "expirationPeriod" is required (not null)
            if (expirationPeriod == null)
            {
                throw new InvalidDataException("expirationPeriod is a required property for AddAccountChannelTypeModel and cannot be null");
            }
            else
            {
                this.ExpirationPeriod = expirationPeriod;
            }
            this.HasLimitedAccess = hasLimitedAccess;
        }
        
        /// <summary>
        /// Gets or Sets AccountID
        /// </summary>
        [DataMember(Name="accountID", EmitDefaultValue=false)]
        public int? AccountID { get; set; }

        /// <summary>
        /// Gets or Sets ChannelTypeID
        /// </summary>
        [DataMember(Name="channelTypeID", EmitDefaultValue=false)]
        public int? ChannelTypeID { get; set; }

        /// <summary>
        /// Gets or Sets HasLimitedAccess
        /// </summary>
        [DataMember(Name="hasLimitedAccess", EmitDefaultValue=false)]
        public bool? HasLimitedAccess { get; set; }

        /// <summary>
        /// Gets or Sets ExpirationPeriod
        /// </summary>
        [DataMember(Name="expirationPeriod", EmitDefaultValue=false)]
        public int? ExpirationPeriod { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddAccountChannelTypeModel {\n");
            sb.Append("  AccountID: ").Append(AccountID).Append("\n");
            sb.Append("  ChannelTypeID: ").Append(ChannelTypeID).Append("\n");
            sb.Append("  HasLimitedAccess: ").Append(HasLimitedAccess).Append("\n");
            sb.Append("  ExpirationPeriod: ").Append(ExpirationPeriod).Append("\n");
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
            return this.Equals(input as AddAccountChannelTypeModel);
        }

        /// <summary>
        /// Returns true if AddAccountChannelTypeModel instances are equal
        /// </summary>
        /// <param name="input">Instance of AddAccountChannelTypeModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddAccountChannelTypeModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccountID == input.AccountID ||
                    (this.AccountID != null &&
                    this.AccountID.Equals(input.AccountID))
                ) && 
                (
                    this.ChannelTypeID == input.ChannelTypeID ||
                    (this.ChannelTypeID != null &&
                    this.ChannelTypeID.Equals(input.ChannelTypeID))
                ) && 
                (
                    this.HasLimitedAccess == input.HasLimitedAccess ||
                    (this.HasLimitedAccess != null &&
                    this.HasLimitedAccess.Equals(input.HasLimitedAccess))
                ) && 
                (
                    this.ExpirationPeriod == input.ExpirationPeriod ||
                    (this.ExpirationPeriod != null &&
                    this.ExpirationPeriod.Equals(input.ExpirationPeriod))
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
                if (this.AccountID != null)
                    hashCode = hashCode * 59 + this.AccountID.GetHashCode();
                if (this.ChannelTypeID != null)
                    hashCode = hashCode * 59 + this.ChannelTypeID.GetHashCode();
                if (this.HasLimitedAccess != null)
                    hashCode = hashCode * 59 + this.HasLimitedAccess.GetHashCode();
                if (this.ExpirationPeriod != null)
                    hashCode = hashCode * 59 + this.ExpirationPeriod.GetHashCode();
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