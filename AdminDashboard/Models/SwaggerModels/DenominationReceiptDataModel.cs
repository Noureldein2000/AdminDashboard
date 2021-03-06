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
    /// DenominationReceiptDataModel
    /// </summary>
    [DataContract]
        public partial class DenominationReceiptDataModel :  IEquatable<DenominationReceiptDataModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DenominationReceiptDataModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="denominationID">denominationID.</param>
        /// <param name="title">title.</param>
        /// <param name="disclaimer">disclaimer.</param>
        /// <param name="footer">footer.</param>
        public DenominationReceiptDataModel(int? id = default(int?), int? denominationID = default(int?), string title = default(string), string disclaimer = default(string), string footer = default(string))
        {
            this.Id = id;
            this.DenominationID = denominationID;
            this.Title = title;
            this.Disclaimer = disclaimer;
            this.Footer = footer;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets DenominationID
        /// </summary>
        [DataMember(Name="denominationID", EmitDefaultValue=false)]
        public int? DenominationID { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Disclaimer
        /// </summary>
        [DataMember(Name="disclaimer", EmitDefaultValue=false)]
        public string Disclaimer { get; set; }

        /// <summary>
        /// Gets or Sets Footer
        /// </summary>
        [DataMember(Name="footer", EmitDefaultValue=false)]
        public string Footer { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DenominationReceiptDataModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DenominationID: ").Append(DenominationID).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Disclaimer: ").Append(Disclaimer).Append("\n");
            sb.Append("  Footer: ").Append(Footer).Append("\n");
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
            return this.Equals(input as DenominationReceiptDataModel);
        }

        /// <summary>
        /// Returns true if DenominationReceiptDataModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DenominationReceiptDataModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DenominationReceiptDataModel input)
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
                    this.DenominationID == input.DenominationID ||
                    (this.DenominationID != null &&
                    this.DenominationID.Equals(input.DenominationID))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Disclaimer == input.Disclaimer ||
                    (this.Disclaimer != null &&
                    this.Disclaimer.Equals(input.Disclaimer))
                ) && 
                (
                    this.Footer == input.Footer ||
                    (this.Footer != null &&
                    this.Footer.Equals(input.Footer))
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
                if (this.DenominationID != null)
                    hashCode = hashCode * 59 + this.DenominationID.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Disclaimer != null)
                    hashCode = hashCode * 59 + this.Disclaimer.GetHashCode();
                if (this.Footer != null)
                    hashCode = hashCode * 59 + this.Footer.GetHashCode();
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
