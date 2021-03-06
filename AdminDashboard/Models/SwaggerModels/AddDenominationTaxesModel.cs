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
    /// AddDenominationTaxesModel
    /// </summary>
    [DataContract]
        public partial class AddDenominationTaxesModel :  IEquatable<AddDenominationTaxesModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddDenominationTaxesModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="taxId">taxId.</param>
        /// <param name="denominationId">denominationId.</param>
        public AddDenominationTaxesModel(int? id = default(int?), int? taxId = default(int?), int? denominationId = default(int?))
        {
            this.Id = id;
            this.TaxId = taxId;
            this.DenominationId = denominationId;
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
        /// Gets or Sets DenominationId
        /// </summary>
        [DataMember(Name="denominationId", EmitDefaultValue=false)]
        public int? DenominationId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddDenominationTaxesModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TaxId: ").Append(TaxId).Append("\n");
            sb.Append("  DenominationId: ").Append(DenominationId).Append("\n");
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
            return this.Equals(input as AddDenominationTaxesModel);
        }

        /// <summary>
        /// Returns true if AddDenominationTaxesModel instances are equal
        /// </summary>
        /// <param name="input">Instance of AddDenominationTaxesModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddDenominationTaxesModel input)
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
                    this.DenominationId == input.DenominationId ||
                    (this.DenominationId != null &&
                    this.DenominationId.Equals(input.DenominationId))
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
                if (this.DenominationId != null)
                    hashCode = hashCode * 59 + this.DenominationId.GetHashCode();
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
