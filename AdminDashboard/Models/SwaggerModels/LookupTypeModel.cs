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
    /// LookupTypeModel
    /// </summary>
    [DataContract]
        public partial class LookupTypeModel :  IEquatable<LookupTypeModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupTypeModel" /> class.
        /// </summary>
        /// <param name="generalLookups">generalLookups.</param>
        public LookupTypeModel(List<GeneralLookupTypeModel> generalLookups = default(List<GeneralLookupTypeModel>))
        {
            this.GeneralLookups = generalLookups;
        }
        
        /// <summary>
        /// Gets or Sets GeneralLookups
        /// </summary>
        [DataMember(Name="generalLookups", EmitDefaultValue=false)]
        public List<GeneralLookupTypeModel> GeneralLookups { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LookupTypeModel {\n");
            sb.Append("  GeneralLookups: ").Append(GeneralLookups).Append("\n");
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
            return this.Equals(input as LookupTypeModel);
        }

        /// <summary>
        /// Returns true if LookupTypeModel instances are equal
        /// </summary>
        /// <param name="input">Instance of LookupTypeModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LookupTypeModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.GeneralLookups == input.GeneralLookups ||
                    this.GeneralLookups != null &&
                    input.GeneralLookups != null &&
                    this.GeneralLookups.SequenceEqual(input.GeneralLookups)
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
                if (this.GeneralLookups != null)
                    hashCode = hashCode * 59 + this.GeneralLookups.GetHashCode();
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