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
    /// AccountModel
    /// </summary>
    [DataContract]
        public partial class AccountModel :  IEquatable<AccountModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="ownerName">ownerName.</param>
        /// <param name="accountName">accountName.</param>
        /// <param name="mobile">mobile.</param>
        /// <param name="address">address.</param>
        /// <param name="email">email.</param>
        /// <param name="nationalID">nationalID.</param>
        /// <param name="commercialRegistrationNo">commercialRegistrationNo.</param>
        /// <param name="taxNo">taxNo.</param>
        /// <param name="activityID">activityID.</param>
        /// <param name="activityName">activityName.</param>
        /// <param name="creationDate">creationDate.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="accountTypeProfileID">accountTypeProfileID.</param>
        /// <param name="regionID">regionID.</param>
        /// <param name="governerateID">governerateID.</param>
        /// <param name="entityID">entityID.</param>
        /// <param name="parentID">parentID.</param>
        /// <param name="status">status.</param>
        public AccountModel(int? id = default(int?), string ownerName = default(string), string accountName = default(string), string mobile = default(string), string address = default(string), string email = default(string), string nationalID = default(string), string commercialRegistrationNo = default(string), string taxNo = default(string), int? activityID = default(int?), string activityName = default(string), DateTime? creationDate = default(DateTime?), int? createdBy = default(int?), int? updatedBy = default(int?), int? accountTypeProfileID = default(int?), int? regionID = default(int?), int? governerateID = default(int?), int? entityID = default(int?), int? parentID = default(int?), bool? status = default(bool?))
        {
            this.Id = id;
            this.OwnerName = ownerName;
            this.AccountName = accountName;
            this.Mobile = mobile;
            this.Address = address;
            this.Email = email;
            this.NationalID = nationalID;
            this.CommercialRegistrationNo = commercialRegistrationNo;
            this.TaxNo = taxNo;
            this.ActivityID = activityID;
            this.ActivityName = activityName;
            this.CreationDate = creationDate;
            this.CreatedBy = createdBy;
            this.UpdatedBy = updatedBy;
            this.AccountTypeProfileID = accountTypeProfileID;
            this.RegionID = regionID;
            this.GovernerateID = governerateID;
            this.EntityID = entityID;
            this.ParentID = parentID;
            this.Status = status;
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
        /// Gets or Sets ActivityName
        /// </summary>
        [DataMember(Name="activityName", EmitDefaultValue=false)]
        public string ActivityName { get; set; }

        /// <summary>
        /// Gets or Sets CreationDate
        /// </summary>
        [DataMember(Name="creationDate", EmitDefaultValue=false)]
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedBy
        /// </summary>
        [DataMember(Name="updatedBy", EmitDefaultValue=false)]
        public int? UpdatedBy { get; set; }

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
        /// Gets or Sets GovernerateID
        /// </summary>
        [DataMember(Name="governerateID", EmitDefaultValue=false)]
        public int? GovernerateID { get; set; }

        /// <summary>
        /// Gets or Sets EntityID
        /// </summary>
        [DataMember(Name="entityID", EmitDefaultValue=false)]
        public int? EntityID { get; set; }

        /// <summary>
        /// Gets or Sets ParentID
        /// </summary>
        [DataMember(Name="parentID", EmitDefaultValue=false)]
        public int? ParentID { get; set; }

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
            sb.Append("class AccountModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  OwnerName: ").Append(OwnerName).Append("\n");
            sb.Append("  AccountName: ").Append(AccountName).Append("\n");
            sb.Append("  Mobile: ").Append(Mobile).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  NationalID: ").Append(NationalID).Append("\n");
            sb.Append("  CommercialRegistrationNo: ").Append(CommercialRegistrationNo).Append("\n");
            sb.Append("  TaxNo: ").Append(TaxNo).Append("\n");
            sb.Append("  ActivityID: ").Append(ActivityID).Append("\n");
            sb.Append("  ActivityName: ").Append(ActivityName).Append("\n");
            sb.Append("  CreationDate: ").Append(CreationDate).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  AccountTypeProfileID: ").Append(AccountTypeProfileID).Append("\n");
            sb.Append("  RegionID: ").Append(RegionID).Append("\n");
            sb.Append("  GovernerateID: ").Append(GovernerateID).Append("\n");
            sb.Append("  EntityID: ").Append(EntityID).Append("\n");
            sb.Append("  ParentID: ").Append(ParentID).Append("\n");
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
            return this.Equals(input as AccountModel);
        }

        /// <summary>
        /// Returns true if AccountModel instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountModel input)
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
                    this.ActivityName == input.ActivityName ||
                    (this.ActivityName != null &&
                    this.ActivityName.Equals(input.ActivityName))
                ) && 
                (
                    this.CreationDate == input.CreationDate ||
                    (this.CreationDate != null &&
                    this.CreationDate.Equals(input.CreationDate))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.UpdatedBy == input.UpdatedBy ||
                    (this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(input.UpdatedBy))
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
                    this.GovernerateID == input.GovernerateID ||
                    (this.GovernerateID != null &&
                    this.GovernerateID.Equals(input.GovernerateID))
                ) && 
                (
                    this.EntityID == input.EntityID ||
                    (this.EntityID != null &&
                    this.EntityID.Equals(input.EntityID))
                ) && 
                (
                    this.ParentID == input.ParentID ||
                    (this.ParentID != null &&
                    this.ParentID.Equals(input.ParentID))
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
                if (this.OwnerName != null)
                    hashCode = hashCode * 59 + this.OwnerName.GetHashCode();
                if (this.AccountName != null)
                    hashCode = hashCode * 59 + this.AccountName.GetHashCode();
                if (this.Mobile != null)
                    hashCode = hashCode * 59 + this.Mobile.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
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
                if (this.ActivityName != null)
                    hashCode = hashCode * 59 + this.ActivityName.GetHashCode();
                if (this.CreationDate != null)
                    hashCode = hashCode * 59 + this.CreationDate.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                if (this.AccountTypeProfileID != null)
                    hashCode = hashCode * 59 + this.AccountTypeProfileID.GetHashCode();
                if (this.RegionID != null)
                    hashCode = hashCode * 59 + this.RegionID.GetHashCode();
                if (this.GovernerateID != null)
                    hashCode = hashCode * 59 + this.GovernerateID.GetHashCode();
                if (this.EntityID != null)
                    hashCode = hashCode * 59 + this.EntityID.GetHashCode();
                if (this.ParentID != null)
                    hashCode = hashCode * 59 + this.ParentID.GetHashCode();
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
