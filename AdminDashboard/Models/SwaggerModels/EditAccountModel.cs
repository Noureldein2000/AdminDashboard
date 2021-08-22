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
    /// EditAccountModel
    /// </summary>
    [DataContract]
        public partial class EditAccountModel :  IEquatable<EditAccountModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditAccountModel" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="ownerName">ownerName.</param>
        /// <param name="accountName">accountName.</param>
        /// <param name="mobile">mobile.</param>
        /// <param name="address">address.</param>
        /// <param name="latitude">latitude.</param>
        /// <param name="longitude">longitude.</param>
        /// <param name="email">email.</param>
        /// <param name="nationalID">nationalID.</param>
        /// <param name="commercialRegistrationNo">commercialRegistrationNo.</param>
        /// <param name="taxNo">taxNo.</param>
        /// <param name="activityID">activityID.</param>
        /// <param name="accountTypeProfileID">accountTypeProfileID.</param>
        /// <param name="regionID">regionID.</param>
        /// <param name="entityID">entityID.</param>
        public EditAccountModel(int? id = default(int?), string ownerName = default(string), string accountName = default(string), string mobile = default(string), string address = default(string), string latitude = default(string), string longitude = default(string), string email = default(string), string nationalID = default(string), string commercialRegistrationNo = default(string), string taxNo = default(string), int? activityID = default(int?), int? accountTypeProfileID = default(int?), int? regionID = default(int?), int? entityID = default(int?))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for EditAccountModel and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            this.OwnerName = ownerName;
            this.AccountName = accountName;
            this.Mobile = mobile;
            this.Address = address;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Email = email;
            this.NationalID = nationalID;
            this.CommercialRegistrationNo = commercialRegistrationNo;
            this.TaxNo = taxNo;
            this.ActivityID = activityID;
            this.AccountTypeProfileID = accountTypeProfileID;
            this.RegionID = regionID;
            this.EntityID = entityID;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets OwnerName
        /// </summary>
        [DataMember(Name="ownerName", EmitDefaultValue=false)]
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or Sets AccountName
        /// </summary>
        [DataMember(Name="accountName", EmitDefaultValue=false)]
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or Sets Mobile
        /// </summary>
        [DataMember(Name="mobile", EmitDefaultValue=false)]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Latitude
        /// </summary>
        [DataMember(Name="latitude", EmitDefaultValue=false)]
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>
        [DataMember(Name="longitude", EmitDefaultValue=false)]
        public string Longitude { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets NationalID
        /// </summary>
        [DataMember(Name="nationalID", EmitDefaultValue=false)]
        public string NationalID { get; set; }

        /// <summary>
        /// Gets or Sets CommercialRegistrationNo
        /// </summary>
        [DataMember(Name="commercialRegistrationNo", EmitDefaultValue=false)]
        public string CommercialRegistrationNo { get; set; }

        /// <summary>
        /// Gets or Sets TaxNo
        /// </summary>
        [DataMember(Name="taxNo", EmitDefaultValue=false)]
        public string TaxNo { get; set; }

        /// <summary>
        /// Gets or Sets ActivityID
        /// </summary>
        [DataMember(Name="activityID", EmitDefaultValue=false)]
        public int? ActivityID { get; set; }

        /// <summary>
        /// Gets or Sets AccountTypeProfileID
        /// </summary>
        [DataMember(Name="accountTypeProfileID", EmitDefaultValue=false)]
        public int? AccountTypeProfileID { get; set; }

        /// <summary>
        /// Gets or Sets RegionID
        /// </summary>
        [DataMember(Name="regionID", EmitDefaultValue=false)]
        public int? RegionID { get; set; }

        /// <summary>
        /// Gets or Sets EntityID
        /// </summary>
        [DataMember(Name="entityID", EmitDefaultValue=false)]
        public int? EntityID { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EditAccountModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  OwnerName: ").Append(OwnerName).Append("\n");
            sb.Append("  AccountName: ").Append(AccountName).Append("\n");
            sb.Append("  Mobile: ").Append(Mobile).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Latitude: ").Append(Latitude).Append("\n");
            sb.Append("  Longitude: ").Append(Longitude).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  NationalID: ").Append(NationalID).Append("\n");
            sb.Append("  CommercialRegistrationNo: ").Append(CommercialRegistrationNo).Append("\n");
            sb.Append("  TaxNo: ").Append(TaxNo).Append("\n");
            sb.Append("  ActivityID: ").Append(ActivityID).Append("\n");
            sb.Append("  AccountTypeProfileID: ").Append(AccountTypeProfileID).Append("\n");
            sb.Append("  RegionID: ").Append(RegionID).Append("\n");
            sb.Append("  EntityID: ").Append(EntityID).Append("\n");
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
            return this.Equals(input as EditAccountModel);
        }

        /// <summary>
        /// Returns true if EditAccountModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EditAccountModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EditAccountModel input)
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
                    this.OwnerName == input.OwnerName ||
                    (this.OwnerName != null &&
                    this.OwnerName.Equals(input.OwnerName))
                ) && 
                (
                    this.AccountName == input.AccountName ||
                    (this.AccountName != null &&
                    this.AccountName.Equals(input.AccountName))
                ) && 
                (
                    this.Mobile == input.Mobile ||
                    (this.Mobile != null &&
                    this.Mobile.Equals(input.Mobile))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Latitude == input.Latitude ||
                    (this.Latitude != null &&
                    this.Latitude.Equals(input.Latitude))
                ) && 
                (
                    this.Longitude == input.Longitude ||
                    (this.Longitude != null &&
                    this.Longitude.Equals(input.Longitude))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.NationalID == input.NationalID ||
                    (this.NationalID != null &&
                    this.NationalID.Equals(input.NationalID))
                ) && 
                (
                    this.CommercialRegistrationNo == input.CommercialRegistrationNo ||
                    (this.CommercialRegistrationNo != null &&
                    this.CommercialRegistrationNo.Equals(input.CommercialRegistrationNo))
                ) && 
                (
                    this.TaxNo == input.TaxNo ||
                    (this.TaxNo != null &&
                    this.TaxNo.Equals(input.TaxNo))
                ) && 
                (
                    this.ActivityID == input.ActivityID ||
                    (this.ActivityID != null &&
                    this.ActivityID.Equals(input.ActivityID))
                ) && 
                (
                    this.AccountTypeProfileID == input.AccountTypeProfileID ||
                    (this.AccountTypeProfileID != null &&
                    this.AccountTypeProfileID.Equals(input.AccountTypeProfileID))
                ) && 
                (
                    this.RegionID == input.RegionID ||
                    (this.RegionID != null &&
                    this.RegionID.Equals(input.RegionID))
                ) && 
                (
                    this.EntityID == input.EntityID ||
                    (this.EntityID != null &&
                    this.EntityID.Equals(input.EntityID))
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
                if (this.OwnerName != null)
                    hashCode = hashCode * 59 + this.OwnerName.GetHashCode();
                if (this.AccountName != null)
                    hashCode = hashCode * 59 + this.AccountName.GetHashCode();
                if (this.Mobile != null)
                    hashCode = hashCode * 59 + this.Mobile.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Latitude != null)
                    hashCode = hashCode * 59 + this.Latitude.GetHashCode();
                if (this.Longitude != null)
                    hashCode = hashCode * 59 + this.Longitude.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.NationalID != null)
                    hashCode = hashCode * 59 + this.NationalID.GetHashCode();
                if (this.CommercialRegistrationNo != null)
                    hashCode = hashCode * 59 + this.CommercialRegistrationNo.GetHashCode();
                if (this.TaxNo != null)
                    hashCode = hashCode * 59 + this.TaxNo.GetHashCode();
                if (this.ActivityID != null)
                    hashCode = hashCode * 59 + this.ActivityID.GetHashCode();
                if (this.AccountTypeProfileID != null)
                    hashCode = hashCode * 59 + this.AccountTypeProfileID.GetHashCode();
                if (this.RegionID != null)
                    hashCode = hashCode * 59 + this.RegionID.GetHashCode();
                if (this.EntityID != null)
                    hashCode = hashCode * 59 + this.EntityID.GetHashCode();
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