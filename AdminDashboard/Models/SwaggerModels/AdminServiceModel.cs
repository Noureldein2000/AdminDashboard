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
    /// AdminServiceModel
    /// </summary>
    [DataContract]
        public partial class AdminServiceModel :  IEquatable<AdminServiceModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminServiceModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="arName">arName.</param>
        /// <param name="status">status.</param>
        /// <param name="serviceTypeID">serviceTypeID.</param>
        /// <param name="serviceTypeName">serviceTypeName.</param>
        /// <param name="code">code.</param>
        /// <param name="serviceEntityID">serviceEntityID.</param>
        /// <param name="serviceEntityName">serviceEntityName.</param>
        /// <param name="serviceCategoryID">serviceCategoryID.</param>
        /// <param name="serviceCategoryName">serviceCategoryName.</param>
        /// <param name="pathClass">pathClass.</param>
        /// <param name="classType">classType.</param>
        /// <param name="creationDate">creationDate.</param>
        public AdminServiceModel(int? id = default(int?), string name = default(string), string arName = default(string), bool? status = default(bool?), int? serviceTypeID = default(int?), string serviceTypeName = default(string), string code = default(string), int? serviceEntityID = default(int?), string serviceEntityName = default(string), int? serviceCategoryID = default(int?), string serviceCategoryName = default(string), string pathClass = default(string), ServiceClassType classType = default(ServiceClassType), DateTime? creationDate = default(DateTime?))
        {
            this.Id = id;
            this.Name = name;
            this.ArName = arName;
            this.Status = status;
            this.ServiceTypeID = serviceTypeID;
            this.ServiceTypeName = serviceTypeName;
            this.Code = code;
            this.ServiceEntityID = serviceEntityID;
            this.ServiceEntityName = serviceEntityName;
            this.ServiceCategoryID = serviceCategoryID;
            this.ServiceCategoryName = serviceCategoryName;
            this.PathClass = pathClass;
            this.ClassType = classType;
            this.CreationDate = creationDate;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ArName
        /// </summary>
        [DataMember(Name="arName", EmitDefaultValue=false)]
        public string ArName { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or Sets ServiceTypeID
        /// </summary>
        [DataMember(Name="serviceTypeID", EmitDefaultValue=false)]
        public int? ServiceTypeID { get; set; }

        /// <summary>
        /// Gets or Sets ServiceTypeName
        /// </summary>
        [DataMember(Name="serviceTypeName", EmitDefaultValue=false)]
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or Sets ServiceEntityID
        /// </summary>
        [DataMember(Name="serviceEntityID", EmitDefaultValue=false)]
        public int? ServiceEntityID { get; set; }

        /// <summary>
        /// Gets or Sets ServiceEntityName
        /// </summary>
        [DataMember(Name="serviceEntityName", EmitDefaultValue=false)]
        public string ServiceEntityName { get; set; }

        /// <summary>
        /// Gets or Sets ServiceCategoryID
        /// </summary>
        [DataMember(Name="serviceCategoryID", EmitDefaultValue=false)]
        public int? ServiceCategoryID { get; set; }

        /// <summary>
        /// Gets or Sets ServiceCategoryName
        /// </summary>
        [DataMember(Name="serviceCategoryName", EmitDefaultValue=false)]
        public string ServiceCategoryName { get; set; }

        /// <summary>
        /// Gets or Sets PathClass
        /// </summary>
        [DataMember(Name="pathClass", EmitDefaultValue=false)]
        public string PathClass { get; set; }

        /// <summary>
        /// Gets or Sets ClassType
        /// </summary>
        [DataMember(Name="classType", EmitDefaultValue=false)]
        public ServiceClassType ClassType { get; set; }

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
            sb.Append("class AdminServiceModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ArName: ").Append(ArName).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ServiceTypeID: ").Append(ServiceTypeID).Append("\n");
            sb.Append("  ServiceTypeName: ").Append(ServiceTypeName).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  ServiceEntityID: ").Append(ServiceEntityID).Append("\n");
            sb.Append("  ServiceEntityName: ").Append(ServiceEntityName).Append("\n");
            sb.Append("  ServiceCategoryID: ").Append(ServiceCategoryID).Append("\n");
            sb.Append("  ServiceCategoryName: ").Append(ServiceCategoryName).Append("\n");
            sb.Append("  PathClass: ").Append(PathClass).Append("\n");
            sb.Append("  ClassType: ").Append(ClassType).Append("\n");
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
            return this.Equals(input as AdminServiceModel);
        }

        /// <summary>
        /// Returns true if AdminServiceModel instances are equal
        /// </summary>
        /// <param name="input">Instance of AdminServiceModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AdminServiceModel input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ArName == input.ArName ||
                    (this.ArName != null &&
                    this.ArName.Equals(input.ArName))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.ServiceTypeID == input.ServiceTypeID ||
                    (this.ServiceTypeID != null &&
                    this.ServiceTypeID.Equals(input.ServiceTypeID))
                ) && 
                (
                    this.ServiceTypeName == input.ServiceTypeName ||
                    (this.ServiceTypeName != null &&
                    this.ServiceTypeName.Equals(input.ServiceTypeName))
                ) && 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.ServiceEntityID == input.ServiceEntityID ||
                    (this.ServiceEntityID != null &&
                    this.ServiceEntityID.Equals(input.ServiceEntityID))
                ) && 
                (
                    this.ServiceEntityName == input.ServiceEntityName ||
                    (this.ServiceEntityName != null &&
                    this.ServiceEntityName.Equals(input.ServiceEntityName))
                ) && 
                (
                    this.ServiceCategoryID == input.ServiceCategoryID ||
                    (this.ServiceCategoryID != null &&
                    this.ServiceCategoryID.Equals(input.ServiceCategoryID))
                ) && 
                (
                    this.ServiceCategoryName == input.ServiceCategoryName ||
                    (this.ServiceCategoryName != null &&
                    this.ServiceCategoryName.Equals(input.ServiceCategoryName))
                ) && 
                (
                    this.PathClass == input.PathClass ||
                    (this.PathClass != null &&
                    this.PathClass.Equals(input.PathClass))
                ) && 
                (
                    this.ClassType == input.ClassType ||
                    (this.ClassType != null &&
                    this.ClassType.Equals(input.ClassType))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.ArName != null)
                    hashCode = hashCode * 59 + this.ArName.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.ServiceTypeID != null)
                    hashCode = hashCode * 59 + this.ServiceTypeID.GetHashCode();
                if (this.ServiceTypeName != null)
                    hashCode = hashCode * 59 + this.ServiceTypeName.GetHashCode();
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.ServiceEntityID != null)
                    hashCode = hashCode * 59 + this.ServiceEntityID.GetHashCode();
                if (this.ServiceEntityName != null)
                    hashCode = hashCode * 59 + this.ServiceEntityName.GetHashCode();
                if (this.ServiceCategoryID != null)
                    hashCode = hashCode * 59 + this.ServiceCategoryID.GetHashCode();
                if (this.ServiceCategoryName != null)
                    hashCode = hashCode * 59 + this.ServiceCategoryName.GetHashCode();
                if (this.PathClass != null)
                    hashCode = hashCode * 59 + this.PathClass.GetHashCode();
                if (this.ClassType != null)
                    hashCode = hashCode * 59 + this.ClassType.GetHashCode();
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
