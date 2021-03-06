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
    /// AddChannelModel
    /// </summary>
    [DataContract]
        public partial class AddChannelModel :  IEquatable<AddChannelModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddChannelModel" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="channelTypeID">channelTypeID.</param>
        /// <param name="channelOwnerID">channelOwnerID.</param>
        /// <param name="serial">serial.</param>
        /// <param name="paymentMethodID">paymentMethodID.</param>
        /// <param name="value">value.</param>
        /// <param name="status">status.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="accountId">accountId.</param>
        public AddChannelModel(string name = default(string), int? channelTypeID = default(int?), int? channelOwnerID = default(int?), string serial = default(string), int? paymentMethodID = default(int?), string value = default(string), bool? status = default(bool?), int? createdBy = default(int?), int? accountId = default(int?))
        {
            this.Name = name;
            this.ChannelTypeID = channelTypeID;
            this.ChannelOwnerID = channelOwnerID;
            this.Serial = serial;
            this.PaymentMethodID = paymentMethodID;
            this.Value = value;
            this.Status = status;
            this.CreatedBy = createdBy;
            this.AccountId = accountId;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ChannelTypeID
        /// </summary>
        [DataMember(Name="channelTypeID", EmitDefaultValue=false)]
        public int? ChannelTypeID { get; set; }

        /// <summary>
        /// Gets or Sets ChannelOwnerID
        /// </summary>
        [DataMember(Name="channelOwnerID", EmitDefaultValue=false)]
        public int? ChannelOwnerID { get; set; }

        /// <summary>
        /// Gets or Sets Serial
        /// </summary>
        [DataMember(Name="serial", EmitDefaultValue=false)]
        public string Serial { get; set; }

        /// <summary>
        /// Gets or Sets PaymentMethodID
        /// </summary>
        [DataMember(Name="paymentMethodID", EmitDefaultValue=false)]
        public int? PaymentMethodID { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets AccountId
        /// </summary>
        [DataMember(Name="accountId", EmitDefaultValue=false)]
        public int? AccountId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddChannelModel {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ChannelTypeID: ").Append(ChannelTypeID).Append("\n");
            sb.Append("  ChannelOwnerID: ").Append(ChannelOwnerID).Append("\n");
            sb.Append("  Serial: ").Append(Serial).Append("\n");
            sb.Append("  PaymentMethodID: ").Append(PaymentMethodID).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
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
            return this.Equals(input as AddChannelModel);
        }

        /// <summary>
        /// Returns true if AddChannelModel instances are equal
        /// </summary>
        /// <param name="input">Instance of AddChannelModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddChannelModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ChannelTypeID == input.ChannelTypeID ||
                    (this.ChannelTypeID != null &&
                    this.ChannelTypeID.Equals(input.ChannelTypeID))
                ) && 
                (
                    this.ChannelOwnerID == input.ChannelOwnerID ||
                    (this.ChannelOwnerID != null &&
                    this.ChannelOwnerID.Equals(input.ChannelOwnerID))
                ) && 
                (
                    this.Serial == input.Serial ||
                    (this.Serial != null &&
                    this.Serial.Equals(input.Serial))
                ) && 
                (
                    this.PaymentMethodID == input.PaymentMethodID ||
                    (this.PaymentMethodID != null &&
                    this.PaymentMethodID.Equals(input.PaymentMethodID))
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
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.ChannelTypeID != null)
                    hashCode = hashCode * 59 + this.ChannelTypeID.GetHashCode();
                if (this.ChannelOwnerID != null)
                    hashCode = hashCode * 59 + this.ChannelOwnerID.GetHashCode();
                if (this.Serial != null)
                    hashCode = hashCode * 59 + this.Serial.GetHashCode();
                if (this.PaymentMethodID != null)
                    hashCode = hashCode * 59 + this.PaymentMethodID.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.AccountId != null)
                    hashCode = hashCode * 59 + this.AccountId.GetHashCode();
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
